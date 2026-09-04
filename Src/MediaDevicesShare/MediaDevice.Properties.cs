namespace MediaDevices;

partial class MediaDevice
{
    /// <summary>
    /// Interface Path of the portable mediaDevice.
    /// </summary>
    /// <remarks>Readable when not connected.</remarks>
    public string InterfacePath { get; private set; } = "";

    public ManufacturerId ManufacturerId { get; private set; } = 0;
    public ushort DeviceId { get; private set; } = 0;

    /// <summary>
    /// Is portable mediaDevice connected.
    /// </summary>
    public bool IsConnected { get; internal set; }

    /// <summary>
    /// Select if path is case sensitive or not. Default is not. 
    /// </summary>
    public bool IsCaseSensitive { get; set; } = false;


    #region IPortableDeviceManager

    internal string? friendlyName;

    /// <summary>
    /// Gets or sets the user-visible friendly name of the device.
    /// </summary>
    /// <remarks>
    /// Setting the property will perform the change via the device protocol handler.
    /// The setter validates connection state, non-null/empty input, and enforces thread-safety
    /// by delegating work to the main worker thread.
    /// The backing field is updated with the value returned from <c>WpdDevice.SetFriendlyName</c>.
    /// </remarks>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    /// <exception cref="System.ArgumentNullException">Thrown when <paramref name="value"/> is null or empty.</exception>
    public string? FriendlyName
    {
        get => friendlyName;
        set
        {
            //NotConnectedException.ThrowIfNotConnected(this);
            //ArgumentNullException.ThrowIfNullOrEmpty(value, nameof(value));
            //ThreadSafeWorkerException.ThrowIfNotOutside();
            //friendlyName = worker.Invoke(() => device.SetFriendlyName(this, value));
        }
    }

    /// <summary>
    /// Gets a value indicating whether the device's friendly name can be edited.
    /// </summary>
    /// <remarks>
    /// This property reflects whether the connected device exposes a writable friendly name.
    /// </remarks>
    /// <value>
    /// <c>true</c> if the device supports editing its friendly name; otherwise, <c>false</c>.
    /// The default value is <c>false</c>.
    /// </value>
    public bool IsFriendlyNameEditable { get; internal set; } = false;

    /// <summary>
    /// A short description of the portable device.
    /// </summary>
    /// <remarks>
    /// This property is populated from the device and is readable even when not connected.
    /// It may be <c>null</c> when the device does not provide a description.
    /// </remarks>
    public string? Description { get; internal set; } = null;

    /// <summary>
    /// The manufacturer name reported by the portable device.
    /// </summary>
    /// <remarks>
    /// Readable when not connected. May be <c>null</c> if not provided by the device.
    /// </remarks>
    public string? Manufacturer { get; internal set; } = null;

    #endregion

    #region IPortableDevice

    /// <summary>
    /// The Plug and Play (PnP) device identifier for the device.
    /// </summary>
    /// <remarks>
    /// The value is provided by the system/device and can be used to correlate the device
    /// with other Windows APIs that accept a PnP device ID.
    /// </remarks>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public string? PnPDeviceID { get; internal set; } = null;

    #endregion

    #region IPortableDeviceValues

    /// <summary>
    /// Logical name of the device.
    /// </summary>
    /// <remarks>
    /// May be <c>null</c> if the device does not expose a name through the values API.
    /// </remarks>
    public string? Name { get; internal set; } = null;

    /// <summary>
    /// The sync partner configured for the device (if any).
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public string? SyncPartner { get; internal set; } = null;

    /// <summary>
    /// Firmware version string reported by the device.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public string? FirmwareVersion { get; internal set; } = null;

    /// <summary>
    /// Battery level of the device as reported by the device (percentage or similar).
    /// </summary>
    /// <remarks>
    /// A <c>null</c> value indicates the device does not report battery level.
    /// </remarks>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>

    public uint? PowerLevel { get; internal set; } = null;

    /// <summary>
    /// Primary power source of the device.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public PowerSource? PowerSource { get; internal set; } = null;

    /// <summary>
    /// Protocol name used by the device (for example, MTP).
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public string? Protocol { get; internal set; } = null;

    /// <summary>
    /// Model name of the device.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public string? Model { get; internal set; } = null;

    /// <summary>
    /// Device serial number.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public string? SerialNumber { get; internal set; } = null;

    /// <summary>
    /// Indicates whether the device supports non-consumable media (e.g. DRM-protected content).
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public bool? SupportsNonConsumable { get; internal set; } = null;

    

    /// <summary>
    /// DRM schemes supported by the device.
    /// </summary>
    /// <remarks>
    /// May be <c>null</c> or an empty array if no DRM schemes are exposed.
    /// </remarks>
    public string[]? SupportedDrmSchemes { get; internal set; } = null;

    /// <summary>
    /// Indicates whether supported formats are ordered on the device.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public bool? SupportedFormatsAreOrdered { get; internal set; } = null;

    /// <summary>
    /// The device type (for example, phone, camera, etc.).
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public DeviceType? DeviceType { get; internal set; } = null;

    /// <summary>
    /// Transport mechanism used by the device.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>

    public DeviceTransport? Transport { get; internal set; } = null;

    /// <summary>
    /// Indicates whether to use the device stage UI for this device.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public DeviceTransport? UseDeviceStage { get; internal set; } = null;


#if DEBUG

    /// <summary>
    /// Diagnostic identifier for the device (debug only).
    /// </summary>
    public string? Id { get; internal set; } = null;

    /// <summary>
    /// Diagnostic parent identifier (debug only).
    /// </summary>
    public string? ParentId { get; internal set; } = null;

    /// <summary>
    /// Content type exposed by the object (debug only).
    /// </summary>
    public ContentType? ContentType { get; internal set; } = null;

    /// <summary>
    /// Persistent unique identifier for the device (debug only).
    /// </summary>
    public string? PersistentUniqueId { get; internal set; } = null;

    /// <summary>
    /// Object format (debug only).
    /// </summary>
    public Formats? ObjectFormat { get; internal set; } = null;

    /// <summary>
    /// Indicates whether the object is hidden (debug only).
    /// </summary>
    public bool? IsHidden { get; internal set; } = null;

    /// <summary>
    /// Indicates whether the object can be deleted (debug only).
    /// </summary>
    public bool? CanDelete { get; internal set; } = null;

    /// <summary>
    /// Container functional object identifier (debug only).
    /// </summary>
    public string? ContainerFunctionalObjectId { get; internal set; } = null;

    /// <summary>
    /// Functional category of the object (debug only).
    /// </summary>
    public FunctionalCategory? FunctionalObjectCategory { get; internal set; } = null;

    /// <summary>
    /// Network identifier exposed by the device (debug only).
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public ulong? NetworkIdentifier { get; internal set; } = null;

    /// <summary>
    /// Functional unique identifier of the device (debug only).
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public uint? FunctionalUniqueId { get; internal set; } = null;

    /// <summary>
    /// Model unique identifier of the device (debug only).
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public uint? ModelUniqueId { get; internal set; } = null;

    /// <summary>
    /// EDP identifier (debug only).
    /// </summary>
    public string? EdpItentifier { get; internal set; } = null;

#endif

    #endregion

    #region dynamic IPortableDeviceValues

    /// <summary>
    /// Current date and time on the device (if provided).
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">Thrown when the device is not connected.</exception>
    public DateTime? DateTime
    {
        get => GetDevicePropertyDateTime(WPD.DEVICE_DATETIME);
        set => SetDeviceProperty(WPD.DEVICE_DATETIME, value);
    }

    #endregion
}
