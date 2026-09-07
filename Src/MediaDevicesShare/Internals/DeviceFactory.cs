using MediaDevices.ProtocolStack;
using MediaDevices.WindowsPortableDevices;

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

    private const string linuxUsbDir = "/sys/bus/usb/devices/";

    [SupportedOSPlatform("linux")]
    public static IEnumerable<MediaDevice> GetLinuxDevices()
    {
        if (!Directory.Exists(linuxUsbDir))
        {
            Console.WriteLine("Fehler: /sys/bus/usb/devices/ existiert nicht. Läuft das Programm auf Linux?");
            yield break; ;
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

            bool isMtpOrPtp = false;

            // 1. Standard PTP/MTP filter via USB interface class (06/01/01)
            if (bInterfaceClass == "06" && bInterfaceSubClass == "01" && bInterfaceProtocol == "01")
            {
                isMtpOrPtp = true;
            }
            // 2. Fallback for vendor-specific Android MTP modes (class ff)
            else if (bInterfaceClass == "ff")
            {
                // For "ff", additionally check the interface name attribute
                string interfaceName = ReadSysfsFile(Path.Combine(devPath, "interface")).ToLower();
                if (interfaceName.Contains("mtp") || interfaceName.Contains("android"))
                {
                    isMtpOrPtp = true;
                }
            }

            if (isMtpOrPtp)
            {
                foundCount++;

                // The parent directory contains global device info (manufacturer, IDs)
                string parentDir = Directory.GetParent(devPath)?.FullName ?? devPath;

                string idVendor = ReadSysfsFile(Path.Combine(parentDir, "idVendor"));
                string idProduct = ReadSysfsFile(Path.Combine(parentDir, "idProduct"));
                string manufacturer = ReadSysfsFile(Path.Combine(parentDir, "manufacturer"));
                string product = ReadSysfsFile(Path.Combine(parentDir, "product"));
                string serial = ReadSysfsFile(Path.Combine(parentDir, "serial"));


                var device = new ApplicationLayer(new TransportLayerLinux()); // deviceManager, d);
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
                int vid = GetMacOsIntProperty(deviceEntry, "idVendor");
                int pid = GetMacOsIntProperty(deviceEntry, "idProduct");
                string vendor = GetMacOsStringProperty(deviceEntry, "USB Vendor Name") ?? "";

                var device = new ApplicationLayer(new TransportLayerMacOS()); // deviceManager, d);
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

    #region Helper

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

    #endregion

    #region LibraryImport

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
