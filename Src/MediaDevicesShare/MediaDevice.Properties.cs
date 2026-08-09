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
            friendlyName = mainWorker.Invoke(() => ProtocolHandler.SetFriendlyName(this, value));
        }
    }

    /// <summary>
    /// Description of the portable mediaDevice.
    /// </summary>
    /// <remarks>Readable when not connected.</remarks>
    public string? Description { get; internal set; } = null;

    /// <summary>
    /// Manufacturer of the portable mediaDevice.
    /// </summary>
    /// <remarks>Readable when not connected.</remarks>
    public string? Manufacturer { get; internal set; } = null;

    #endregion

    #region IPortableDevice

    /// <summary>
    /// PnP mediaDevice ID
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? PnPDeviceID { get; internal set; } = null;

    /// <summary>
    /// Name of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    
    #endregion

    #region IPortableDeviceValues

   

    public string? Name { get; internal set; } = null;




    // Usefull


    /// <summary>
    /// Sync partner of the mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? SyncPartner { get; internal set; } = null;

    /// <summary>
    /// Firmware version of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? FirmwareVersion { get; internal set; } = null;
        
    /// <summary>
    /// Battery level of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public uint? PowerLevel { get; internal set; } = null;

    /// <summary>
    /// Power source of the mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public PowerSource? PowerSource { get; internal set; } = null;

    /// <summary>
    /// Protocol of the mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? Protocol { get; internal set; } = null;

    /// <summary>
    /// Model of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? Model { get; internal set; } = null;

    /// <summary>
    /// Serial number of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? SerialNumber { get; internal set; } = null;

    /// <summary>
    /// Supports non consumable.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public bool? SupportsNonConsumable { get; internal set; } = null;

    /// <summary>
    /// Date and time of the media mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DateTime? DateTime { get; internal set; } = null;


    public string[]? SupportedDrmSchemes { get; internal set; } = null;

    /// <summary>
    /// Supported formats are ordered.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public bool? SupportedFormatsAreOrdered { get; internal set; } = null;

    /// <summary>
    /// Device type of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DeviceType? DeviceType { get; internal set; } = null;

    

    /// <summary>
    /// Device transport.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DeviceTransport? Transport { get; internal set; } = null;

    /// <summary>
    /// Use mediaDevice stage
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DeviceTransport? UseDeviceStage { get; internal set; } = null;



#if DEBUG

    public string? Id { get; internal set; } = null;

    public string? ParentId { get; internal set; } = null;

    public ContentType? ContentType { get; internal set; } = null;

    public string? PersistentUniqueId { get; internal set; } = null;

    public ObjectFormat? ObjectFormat { get; internal set; } = null;

    public bool? IsHidden { get; internal set; } = null;

    public bool? CanDelete { get; internal set; } = null;

    public string? ContainerFunctionalObjectId { get; internal set; } = null;

    public FunctionalCategory? FunctionalObjectCategory { get; internal set; } = null;

    /// <summary>
    /// Network Identifier
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public ulong? NetworkIdentifier { get; internal set; } = null;

    /// <summary>
    /// Functional unique id od the media mediaDevice
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public uint? FunctionalUniqueId { get; internal set; } = null;

    /// <summary>
    /// Model unique id od the media mediaDevice
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public uint? ModelUniqueId { get; internal set; } = null;

    public string? EdpItentifier { get; internal set; } = null;


#endif

    #endregion
}
