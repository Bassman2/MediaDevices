//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace MediaDevices.AbstractionLayer;

//[SupportedOSPlatform("windows")]
//internal class MtpDeviceWindows : IMtpDevice
//{
//    public string DeviceId { get; }
//    public string FriendlyName { get; private set; } = "Windows WPD Device";
//    public string Manufacturer { get; private set; } = "Unknown";

//    private dynamic? _wpdDeviceInstance;

//    public MtpDeviceWindows(string windowsDeviceId)
//    {
//        DeviceId = windowsDeviceId;
//    }

//    public void Dispose()

//    public void Connect()
//    {
//        // Dynamic/Reflection initialization over standard COM object structure GUIDs
//        Type? portableDeviceType = Type.GetTypeFromProgID("PortableDeviceTypes.PortableDeviceValues");
//        if (portableDeviceType == null) throw new PlatformNotSupportedException("WPD COM Interface layout missing.");

//        Console.WriteLine($"[WPD] Binding structural client context connection to device {DeviceId}...");
//        // Inside real windows system context: 
//        // _wpdDeviceInstance = Activator.CreateInstance(Type.GetTypeFromProgID("PortableDeviceClass.PortableDevice"));
//        // _wpdDeviceInstance.Connect(DeviceId, clientInformation);
//    }

//    public void Disconnect() => _wpdDeviceInstance?.Close();
//}
