using MediaDevices.ProtocolStack;
using MediaDevices.WindowsPortableDevices;
using System.Globalization;

namespace MediaDevices.Internals;

internal static partial class DeviceFactory
{
    private static readonly ThreadSafeWorker worker = ThreadSafeWorker.Instance;



    public static IEnumerable<MediaDevice> GetDevices()
    {
#pragma warning disable CA1416 // Validate platform compatibility
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return worker.InvokeEnumerable<MediaDevice>(() => GetWindowsDevices());
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return worker.InvokeEnumerable<MediaDevice>(() => GetLinuxDevices());
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return worker.InvokeEnumerable<MediaDevice>(() => GetMacOSDevices());
        }
#pragma warning restore CA1416 // Validate platform compatibility
        throw new NotSupportedException("OS not supported!");
    }

    #region Windows

    private static IPortableDeviceManager? deviceManager;

    [SupportedOSPlatform("windows")]
    public static IEnumerable<MediaDevice> GetWindowsDevices()
    {
        deviceManager ??= ComHelper.CreateInstance<IPortableDeviceManager>();

        int err = deviceManager.RefreshDeviceList();
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.RefreshDeviceList));

        // get number of devices
        int count = 0;
        err = deviceManager.GetDevices(null, ref count);
        MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.GetDevices));

        if (count == 0)
        {
            return [];
        }
        else
        {
            // get mediaDevice IDs
            var deviceIds = new string[count];
            err = deviceManager.GetDevices(deviceIds, ref count);
            MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceManager), nameof(IPortableDeviceManager.GetDevices));
            return deviceIds.Select(d =>
            {
                IDevice device = new WpdDevice(deviceManager, d);
                return device.MediaDevice;
            });
        }
    }

    #endregion

    #region Linux

    private const string linuxUsbDir = "/sys/bus/usb/devices/";

    [SupportedOSPlatform("linux")]
    public static IEnumerable<MediaDevice> GetLinuxDevices()
    {
        if (!Directory.Exists(linuxUsbDir))
        {
            throw new Exception($"{linuxUsbDir} does not exists. Does it really run on Linux?");
        }

        int foundCount = 0;

        // Iterate through all directories in the USB subsystem
        foreach (var devPath in Directory.GetDirectories(linuxUsbDir))
        {
            // We primarily look for interface directories (e.g. "1-1:1.0")
            // These contain class definitions for the respective protocol
            if (!devPath.Contains(':')) continue;

            string bInterfaceClass = ReadSysfsFile(Path.Combine(devPath, "bInterfaceClass"));
            string bInterfaceSubClass = ReadSysfsFile(Path.Combine(devPath, "bInterfaceSubClass"));
            string bInterfaceProtocol = ReadSysfsFile(Path.Combine(devPath, "bInterfaceProtocol"));

            Debug.WriteLine($"Path: {devPath}, bInterfaceClass: {bInterfaceClass}, bInterfaceSubClass: {bInterfaceSubClass}, bInterfaceProtocol: {bInterfaceProtocol}");

            bool isMtpOrPtp = false;

            // 1. Standard PTP/MTP filter via USB interface class (06/01/01)
            if (bInterfaceClass == "06" && bInterfaceSubClass == "01" && bInterfaceProtocol == "01")
            {
                isMtpOrPtp = true;
                Debug.WriteLine("MTP/PTP");
            }
            // 2. Fallback for vendor-specific Android MTP modes (class ff)
            else if (bInterfaceClass == "ff")
            {
                // For "ff", additionally check the interface name attribute
                string interfaceName = ReadSysfsFile(Path.Combine(devPath, "interface")).ToLower();
                if (interfaceName.Contains("mtp") || interfaceName.Contains("android"))
                {
                    isMtpOrPtp = true;
                    Debug.WriteLine("Android MTP/PTP");

                }
            }

            if (isMtpOrPtp)
            {
                foundCount++;

                FileInfo fileInfo = new(devPath);
                string relativeTarget = fileInfo.LinkTarget!;

                // The parent directory contains global device info (manufacturer, IDs)
                //string relativeTarget = Directory.GetParent(devPath)?.FullName ?? devPath;

                string absoluteTarget = Path.GetFullPath(Path.Combine(fileInfo.DirectoryName!, relativeTarget));

                string parentDir = Directory.GetParent(absoluteTarget)?.FullName ?? devPath;

                ushort idVendor = ReadSysfsFileUInt16(parentDir, "idVendor");
                ushort idProduct = ReadSysfsFileUInt16(parentDir, "idProduct");
                string manufacturer = ReadSysfsFileString(parentDir, "manufacturer");
                string product = ReadSysfsFileString(parentDir, "product");
                string serial = ReadSysfsFileString(parentDir, "serial");

                ushort busNumStr = ReadSysfsFileUInt16(parentDir, "busnum");
                ushort devNumStr = ReadSysfsFileUInt16(parentDir, "devnum");

                string bInterfaceNumberPath = Path.Combine(parentDir, "bInterfaceNumber");

                uint epIn = 0;
                uint epOut = 0;
                uint epInterruptIn = 0;

                foreach (string epDir in Directory.GetDirectories(parentDir, "ep_*"))
                {
                    string epName = Path.GetFileName(epDir); // z.B. "ep_81"
                    string addressHex = epName.Replace("ep_", ""); // "81"
                    uint epAddress = uint.Parse(addressHex, NumberStyles.HexNumber);

                    // MTP-Standard verwendet Kontroll-Endpunkte (0) nicht für Bulk/Interrupt
                    if ((epAddress & 0x7F) == 0) continue;

                    string typePath = Path.Combine(epDir, "type");
                    string directionPath = Path.Combine(epDir, "direction");

                    if (File.Exists(typePath) && File.Exists(directionPath))
                    {
                        string type = File.ReadAllText(typePath).Trim().ToLower();      // bulk, interrupt, control
                        string direction = File.ReadAllText(directionPath).Trim().ToLower(); // in, out

                        if (type == "bulk")
                        {
                            if (direction == "in")
                            {
                                epIn = epAddress;
                            }
                            else if (direction == "out")
                            {
                                epOut = epAddress;
                            }
                        }
                        else if (type == "interrupt" && direction == "in")
                        {
                            epInterruptIn = epAddress;
                        }
                    }
                }



                Debug.WriteLine($"  Manufacturer: {manufacturer}");
                Debug.WriteLine($"  Product:      {product}");
                Debug.WriteLine($"  Vendor ID:    0x{idVendor}");
                Debug.WriteLine($"  Product ID:   0x{idProduct}");
                Debug.WriteLine($"  Serial No.:   {serial}");
                Debug.WriteLine($"  Class type:   Class {bInterfaceClass}, Subclass {bInterfaceSubClass}");

                //ushort manufacturerId = ushort.Parse(idVendor, NumberStyles.HexNumber);
                //ushort deviceId = ushort.Parse(idProduct, NumberStyles.HexNumber);

                

                var device = new ApplicationLayer(new TransportLayerLinux(devPath, 0, 0, 0, 0), devPath, idVendor, idProduct); 
                yield return device.MediaDevice;

                //yield return new MediaDevice(devPath, product, product, manufacturer, $"Vendor ID: 0x{idVendor}, Product ID: 0x{idProduct}, Serial No.: {serial} Class type: Class {bInterfaceClass}, Subclass {bInterfaceSubClass}");

                ////Console.WriteLine($"Device #{foundCount} found at interface: {Path.GetFileName(devPath)}");
                ////Console.WriteLine($"  Manufacturer: {manufacturer}");
                ////Console.WriteLine($"  Product:      {product}");
                ////Console.WriteLine($"  Vendor ID:    0x{idVendor}");
                ////Console.WriteLine($"  Product ID:   0x{idProduct}");
                ////Console.WriteLine($"  Serial No.:   {serial}");
                ////Console.WriteLine($"  Class type:   Class {bInterfaceClass}, Subclass {bInterfaceSubClass}");
                ////Console.WriteLine("---------------------------------------");
            }
        }
    }

    private static ushort ReadSysfsFileUInt16(string path, string name)
        => Convert.ToUInt16(File.ReadAllText(Path.Combine(path, name)).Trim(), 16);

    private static string ReadSysfsFileString(string path, string name)
        => File.ReadAllText(Path.Combine(path, name)).Trim();
        
        /*
     root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat bMaxPower
500mA
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat bcdDevice
0400
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat configuration
Conf 1
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat descriptors
@�`h    ���     �$�

                        $$$$�

�       �B
�root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat dev
189:1
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat devnum
2
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat devpath
1
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat idProduct
6860
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat idVendor
04e8
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat ltm_capable
no
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat manufacturer
SAMSUNG
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat product
SAMSUNG_Android
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat version
 2.00
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat serial
R58M81NACKB
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat maxchild
0
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat quirks
0x0
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat urbnum
16
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat uevent
MAJOR=189
MINOR=1
DEVNAME=bus/usb/001/002
DEVTYPE=usb_device
DRIVER=usb
PRODUCT=4e8/6860/400
TYPE=0/0/0
BUSNUM=001
DEVNUM=002
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat tx_lanes
1
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat speed
480
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat serial
R58M81NACKB
root@Notebook:/sys/devices/platform/vhci_hcd.0/usb1/1-1# cat remove
cat: remove: Permission denied* 
     * 
    */

    [SupportedOSPlatform("linux")]
    private static string ReadSysfsFile(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path).Trim();
            }
        }
        catch
        {
            // Ignore if access rights are missing or the device has been disconnected.
        }
        return string.Empty;
    }

    #endregion

    #region MacOS

    [SupportedOSPlatform("macos")]
    public static IEnumerable<MediaDevice> GetMacOSDevices()
    {
        IntPtr matchingDict = IOServiceMatching("IOUSBDevice");
        if (matchingDict == IntPtr.Zero) yield break;

        if (IOServiceGetMatchingServices(IntPtr.Zero, matchingDict, out uint iterator) != 0) yield break;

        uint deviceEntry;
        while ((deviceEntry = IOIteratorNext(iterator)) != 0)
        {
            // Read USB class properties
            int deviceClass = GetMacOsIntProperty(deviceEntry, "bDeviceClass");
            int deviceSubClass = GetMacOsIntProperty(deviceEntry, "bDeviceSubClass");

            string name = GetMacOsStringProperty(deviceEntry, "USB Product Name") ?? "Unbekanntes Gerät";

            // PTP/MTP devices often use class 6 (Still Image) at device or interface level
            // Since IOKit uses tree structures, searching for class 6 covers most cameras/smartphones
            if (deviceClass == 0x06 || name.Contains("MTP", StringComparison.OrdinalIgnoreCase))
            {
                ushort vid = (ushort)GetMacOsIntProperty(deviceEntry, "idVendor");
                ushort pid = (ushort)GetMacOsIntProperty(deviceEntry, "idProduct");
                string vendor = GetMacOsStringProperty(deviceEntry, "USB Vendor Name") ?? "";

                var device = new ApplicationLayer(new TransportLayerMacOS(), "", vid, pid); // deviceManager, d);
                yield return device.MediaDevice;

                //yield return new MediaDevice("", name, name, vendor, $"Vendor ID: 0x{vid:X4}, Product ID: 0x{pid:X4}");

                //Console.WriteLine($"Device found: {name}");
                //Console.WriteLine($"  Manufacturer: {vendor}");
                //Console.WriteLine($"  Vendor ID:    0x{vid:X4}");
                //Console.WriteLine($"  Product ID:   0x{pid:X4}");
                //Console.WriteLine("---------------------------------------");
            }

            IOObjectRelease(deviceEntry);
        }
        IOObjectRelease(iterator);
    }

    

    [SupportedOSPlatform("macos")]
    private static int GetMacOsIntProperty(uint entry, string key)
    {
        IntPtr keyPtr = CFStringCreateWithCString(IntPtr.Zero, key, 0);
        IntPtr valPtr = IORegistryEntryCreateCFProperty(entry, keyPtr, IntPtr.Zero, 0);

        // Simplified conversion for demonstration purposes
        // In production, CFNumberGetValue should be used here
        int result = 0;
        if (valPtr != IntPtr.Zero) { /* Extract value */ }

        return result;
    }

    [SupportedOSPlatform("macos")]
    private static string? GetMacOsStringProperty(uint entry, string key)
    {
        // Reads a CFString attribute from the IOKit object
        return null; // Dummy return for structural overview
    }
    
    [LibraryImport("/System/Library/Frameworks/CoreFoundation.framework/CoreFoundation", StringMarshalling = StringMarshalling.Utf8)]
    private static partial IntPtr CFStringCreateWithCString(IntPtr alloc, string cStr, uint encoding);

    [LibraryImport("/System/Library/Frameworks/IOKit.framework/IOKit", StringMarshalling = StringMarshalling.Utf8)]
    private static partial IntPtr IOServiceMatching(string name);

    [LibraryImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
    private static partial int IOServiceGetMatchingServices(IntPtr masterPort, IntPtr matching, out uint iterator);

    [LibraryImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
    private static partial uint IOIteratorNext(uint iterator);

    [LibraryImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
    private static partial IntPtr IORegistryEntryCreateCFProperty(uint entry, IntPtr key, IntPtr allocator, uint options);

    [LibraryImport("/System/Library/Frameworks/IOKit.framework/IOKit")]
    private static partial int IOObjectRelease(uint obj);

    #endregion

}
