using MediaDevices.WindowsPortableDevices;

namespace MediaDevices.Internals;

internal static class DeviceFactory
{
    private static readonly ThreadSafeWorker worker = ThreadSafeWorker.Instance;


    
    public static IEnumerable<MediaDevice> GetDevices()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return worker.InvokeEnumerable<MediaDevice>(() =>  GetWindowsDevices());
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return worker.InvokeEnumerable<MediaDevice>(() =>  []);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return worker.InvokeEnumerable<MediaDevice>(() =>  []);
        }
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
            return deviceIds.Select(d => new MediaDevice(new WpdDevice(deviceManager, d)));
        }
    }
}
