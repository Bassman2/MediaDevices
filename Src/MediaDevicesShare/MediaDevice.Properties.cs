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


    #endregion

    #region IPortableDeviceValues

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
    public int? PowerLevel { get; internal set; } = null;

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
    /// Network Identifier
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public ulong? NetworkIdentifier { get; internal set; } = null;

    /// <summary>
    /// Functional unique id od the media mediaDevice
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public byte[]? FunctionalUniqueId { get; internal set; } = null;

    /// <summary>
    /// Model unique id od the media mediaDevice
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public byte[]? ModelUniqueId { get; internal set; } = null;

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

    #endregion
}
