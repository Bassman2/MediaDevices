namespace MediaDevices;

partial class MediaDevice
{
    #region IPortableDeviceManager

    internal string? friendlyName;

    public string? FriendlyName
    {
        get => friendlyName;
        set
        {
            NotConnectedException.ThrowIfNotConnected(this);
            ArgumentNullException.ThrowIfNullOrEmpty(value, nameof(value));
            ThreadSafeWorkerException.ThrowIfNotOutside();
            friendlyName = mainWorker.SetFriendlyName(this, value);
        }
    }

    /// <summary>
    /// Description of the portable mediaDevice.
    /// </summary>
    /// <remarks>Readable when not connected.</remarks>
    public string? Description { get; internal set; }

    /// <summary>
    /// Manufacturer of the portable mediaDevice.
    /// </summary>
    /// <remarks>Readable when not connected.</remarks>
    public string? Manufacturer { get; internal set; }
       
    #endregion

    #region IPortableDevice

    /// <summary>
    /// PnP mediaDevice ID
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? PnPDeviceID { get; internal set; }
    

    #endregion

    #region IPortableDeviceValues

    /// <summary>
    /// Sync partner of the mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? SyncPartner { get; internal set; }
    
    /// <summary>
    /// Firmware version of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? FirmwareVersion { get; internal set; }
    

    /// <summary>
    /// Battery level of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public int? PowerLevel { get; internal set; }
    
    /// <summary>
    /// Power source of the mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public PowerSource? PowerSource { get; internal set; }

    /// <summary>
    /// Protocol of the mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? Protocol { get; internal set; }
    
    /// <summary>
    /// Model of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? Model { get; internal set; }
    
    /// <summary>
    /// Serial number of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? SerialNumber { get; internal set; }
    
    /// <summary>
    /// Supports non consumable.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public bool? SupportsNonConsumable { get; internal set; }
    
    /// <summary>
    /// Date and time of the media mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DateTime? DateTime { get; internal set; }
    
    /// <summary>
    /// Supported formats are ordered.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public bool? SupportedFormatsAreOrdered { get; internal set; }
   
    /// <summary>
    /// Device type of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DeviceType? DeviceType { get; internal set; }
    
    /// <summary>
    /// Network Identifier
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public ulong? NetworkIdentifier { get; internal set; }
   
    /// <summary>
    /// Functional unique id od the media mediaDevice
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public byte[]? FunctionalUniqueId { get; internal set; }
    
    /// <summary>
    /// Model unique id od the media mediaDevice
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public byte[]? ModelUniqueId { get; internal set; }
    
    /// <summary>
    /// Device transport.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DeviceTransport? Transport { get; internal set; }
   
    /// <summary>
    /// Use mediaDevice stage
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DeviceTransport? UseDeviceStage { get; internal set; }
    
    #endregion
}
