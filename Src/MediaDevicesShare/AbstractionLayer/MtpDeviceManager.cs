//namespace MediaDevices.AbstractionLayer;

//internal static class MtpDeviceManager
//{
//    public static List<IMtpDevice> DiscoverDevices()
//    {
//        var availableDevices = new List<IMtpDevice>();

//        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
//        {
//            Console.WriteLine("[Platform Factory] Initializing Windows WPD API Discovery Context...");
//            // Loop through PortableDeviceManager class devices collection
//            // availableDevices.Add(new WindowsWpdDevice(wpdDeviceId));
//            availableDevices.Add(new WindowsWpdDevice(@"\\?\usb#vid_04e8&pid_6860#..."));
//        }
//        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
//        {
//            Console.WriteLine("[Platform Factory] Initializing Cross-Platform Native LibUsb Stack Pipeline...");
//            foreach (LibUsbDotNet.Main.UsbRegistry usbReg in LibUsbDotNet.UsbDevice.AllDevices)
//            {
//                // Filter down to common MTP interface profiles or Class ID 6 (Still Image Devices)
//                if (usbReg.Vid != 0x0000)
//                {
//                    availableDevices.Add(new UnixMtpDevice(usbReg));
//                }
//            }
//        }

//        return availableDevices;
//    }
//}
