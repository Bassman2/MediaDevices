using System;
using System.Collections.Generic;
using System.Text;

namespace MediaDevices;

partial class MediaDevice
{
    #region Static

    /*
    private static readonly IPortableDeviceManager deviceManager;
    private static readonly IPortableDeviceServiceManager serviceManager;

    
    private static List<MediaDevice> devices;
    private static List<MediaDevice> privateDevices;

    //static MediaDevice()
    //{
    //    try
    //    {
    //        deviceManager = (IPortableDeviceManager)new PortableDeviceManager();
    //        serviceManager = (IPortableDeviceServiceManager)deviceManager;

    //        //var x = new MediaDevMgr();
    //        //var f = new MediaDevMgrClassFactory();
    //        //IWMDeviceManager3 devManager = (IWMDeviceManager3)f;


    //        //devManager.GetRevision(out var revision);
    //        //devManager.GetDeviceCount(out var count);
    //        //devManager.EnumDevices2(out var e);
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex.ToString());
    //    }

    //    // #define WMDM_E_NOTCERTIFIED                     0x80045005L
    //}

    /// <summary>
    /// Returns an enumerable collection of currently available portable devices.
    /// </summary>
    /// <returns>>An enumerable collection of portable devices currently available.</returns>
    public static IEnumerable<MediaDevice> GetDevices()
    {
        deviceManager.RefreshDeviceList();

        // get number of devices
        uint count = 0;
        deviceManager.GetDevices(null, ref count);

        if (count == 0)
        {
            return new List<MediaDevice>();
        }

        // get mediaDevice IDs
        var deviceIds = new string[count];
        deviceManager.GetDevices(deviceIds, ref count);

        if (devices == null)
        {
            devices = deviceIds.Select(d => new MediaDevice(d)).ToList();
        }
        else
        {
            UpdateDeviceList(devices, deviceIds);
        }
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

    //public static IEnumerable<MediaDevice> GetDevices(FunctionalCategory category)
    //{
    //    if (category == FunctionalCategory.All)
    //    {
    //        return GetDevices();
    //    }

    //    var devices = GetDevices();

    //    var dev = devices.FirstOrDefault();

    //    dev.deviceCapabilities
    //}

    /// <summary>
    /// Returns an enumerable collection of currently available private portable devices.
    /// </summary>
    /// <returns>>An enumerable collection of private portable devices currently available.</returns>
    public static IEnumerable<MediaDevice> GetPrivateDevices()
    {
        deviceManager.RefreshDeviceList();

        // get number of devices
        uint count = 0;
        deviceManager.GetPrivateDevices(null, ref count);

        if (count == 0)
        {
            return new List<MediaDevice>();
        }

        // get mediaDevice IDs
        var deviceIds = new string[count];
        deviceManager.GetPrivateDevices(deviceIds, ref count);

        if (privateDevices == null)
        {
            privateDevices = deviceIds.Select(d => new MediaDevice(d)).ToList();
        }
        else
        {
            UpdateDeviceList(privateDevices, deviceIds);
        }
        return privateDevices;
    }
    */

    /// <summary>
    /// Returns an enumerable collection of currently available portable devices.
    /// </summary>
    /// <returns>>An enumerable collection of portable devices currently available.</returns>
    public static IEnumerable<MediaDevice> GetDevices()
    {
        return MediaDeviceManager.Instance.GetDevices();
    }

    /// <summary>
    /// Returns an enumerable collection of private portable devices.
    /// </summary>
    /// <remarks>
    /// Private devices are typically those with restricted access or special permissions required.
    /// </remarks>
    /// <returns>An enumerable collection of private portable devices.</returns>
    public static IEnumerable<MediaDevice> GetPrivateDevices()
    {
        return MediaDeviceManager.Instance.GetPrivateDevices();
    }

    #endregion

}
