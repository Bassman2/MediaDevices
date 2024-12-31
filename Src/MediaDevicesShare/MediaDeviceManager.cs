namespace MediaDevices;

/// <summary>
/// Represents a portable device manager.
/// </summary>
public sealed class MediaDeviceManager : IDisposable
{
    private static MediaDeviceManager? instance = new();

    private readonly STAThread staThread;
    private readonly IPortableDeviceManager? deviceManager;
    private readonly IPortableDeviceServiceManager? serviceManager;
    private List<MediaDevice>? devices;
    private List<MediaDevice>? privateDevices;

    /// <summary>
    /// Singleton instance from MediaDeviceManager.
    /// </summary>
    public static MediaDeviceManager Instance => instance  ?? throw new Exception("MediaDeviceManager already closed");

    private MediaDeviceManager() 
    {
        this.staThread = new STAThread();

        try
        {
            deviceManager = staThread.Run<IPortableDeviceManager>(() => (IPortableDeviceManager)new PortableDeviceManager());
            //serviceManager = staThread.Run<IPortableDeviceServiceManager>(() => (IPortableDeviceServiceManager)deviceManager);
            serviceManager = DeviceManager as IPortableDeviceServiceManager;
        }
        catch (Exception ex)
        {
            Trace.TraceError(ex.ToString());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Dispose()
    {
        Close();
    }

    /// <summary>
    /// Close MediaDeviceManager
    /// </summary>
    public void Close()
    {
        staThread.Run(() =>
        {
            int r1 = Marshal.ReleaseComObject(ServiceManager!);
            int r2 = Marshal.ReleaseComObject(DeviceManager!);
        });
        staThread.Close();
        staThread.Dispose();
        instance = null;
    }

    internal IPortableDeviceManager? DeviceManager => this.deviceManager;
    internal IPortableDeviceServiceManager? ServiceManager => this.serviceManager;

    /// <summary>
    /// Returns an enumerable collection of currently available portable devices.
    /// </summary>
    /// <returns>>An enumerable collection of portable devices currently available.</returns>
    public IEnumerable<MediaDevice>? GetDevices(Devices deviceType = Devices.Public)
    {
        staThread.Run(() =>
        {
            deviceManager!.RefreshDeviceList();

            // get number of devices
            uint count = 0;
            deviceManager.GetDevices(null, ref count);

            if (count == 0)
            {
                devices = [];
            }
            else
            {
                // get device IDs
                var deviceIds = new string[count];
                DeviceManager!.GetDevices(deviceIds, ref count);

                if (devices == null)
                {
                    devices = deviceIds.Select(d => new MediaDevice(d)).ToList();
                }
                else
                {
                    UpdateDeviceList(devices, deviceIds);
                }
            }

            // get number of devices
            count = 0;
            deviceManager.GetPrivateDevices(null, ref count);

            if (count == 0)
            {
                privateDevices = [];
            }
            else
            {

                // get device IDs
                var deviceIds = new string[count];
                DeviceManager!.GetPrivateDevices(deviceIds, ref count);

                if (privateDevices == null)
                {
                    privateDevices = deviceIds.Select(d => new MediaDevice(d)).ToList();
                }
                else
                {
                    UpdateDeviceList(privateDevices, deviceIds);
                }
            }
        });
        return devices;
    }

    private static void UpdateDeviceList(List<MediaDevice> deviceList, string[] deviceIdList)
    {
        var idList = deviceIdList.ToList();

        // remove
        var remove = deviceList.Where(d => !idList.Contains(d.DeviceId)).Select(d => d.DeviceId).ToList();
        deviceList.RemoveAll(d => remove.Contains(d.DeviceId));

        // add
        var add = idList.Where(id => !deviceList.Select(d => d.DeviceId).Contains(id)).ToList();
        deviceList.AddRange(add.Select(id => new MediaDevice(id)));
    }

    internal void Run(Action action) => this.staThread.Run(action);

    internal T? Run<T>(Func<T> func) => this.staThread.Run<T>(func);
}
