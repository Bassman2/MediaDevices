namespace MediaDevices;

/// <summary>
/// Hints Service class
/// </summary>
public class MediaDeviceServiceHints : MediaDeviceService
{
    internal MediaDeviceServiceHints(IDevice device, string serviceId) : base(device, serviceId)
    {

    }

    /// <summary>
    /// Update service
    /// </summary>
    protected override void Update()
    {
        // no properties
    }

    
    
}
