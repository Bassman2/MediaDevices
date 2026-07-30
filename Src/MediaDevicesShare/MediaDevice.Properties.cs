namespace MediaDevices;

partial class MediaDevice
{
    #region IPortableDeviceManager

    public string? FriendlyName
    {
        get => IsConnected ? mainWorker.GetFriendlyName(this.deviceValues!) : friendlyName;
        set
        {
            NotConnectedException.ThrowIfNotConnected(this);
            mainWorker.SetFriendlyName(this, value ?? "");
            // set friendlyName for use after Disconnect
            friendlyName = mainWorker.GetFriendlyName(this.deviceValues!) ?? "";
        }
    }

    /// <summary>
    /// Description of the portable mediaDevice.
    /// </summary>
    /// <remarks>Readable when not connected.</remarks>
    public string? Description => description;

    /// <summary>
    /// Manufacturer of the portable mediaDevice.
    /// </summary>
    /// <remarks>Readable when not connected.</remarks>
    public string? Manufacturer
        => IsConnected ? mainWorker.GetManufacturer(this.deviceValues!) : manufacturer;

    #endregion

    #region IPortableDevice

    /// <summary>
    /// PnP mediaDevice ID
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? PnPDeviceID
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetPnPDeviceID(this.device);
        }
    }

    #endregion

    #region IPortableDeviceValues

    /// <summary>
    /// Sync partner of the mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? SyncPartner
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetSyncPartner(this.deviceValues!);
        }
    }

    /// <summary>
    /// Firmware version of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? FirmwareVersion
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetFirmwareVersion(this.deviceValues!);
        }
    }

    /// <summary>
    /// Battery level of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public int? PowerLevel
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetPowerLevel(this.deviceValues!);
        }
    }

    /// <summary>
    /// Power source of the mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public PowerSource? PowerSource
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetPowerSource(this.deviceValues!);
        }
    }

    /// <summary>
    /// Protocol of the mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? Protocol
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetProtocol(this.deviceValues!);
        }
    }

    /// <summary>
    /// Model of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? Model
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetModel(this.deviceValues!);
        }
    }

    /// <summary>
    /// Serial number of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string? SerialNumber
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetSerialNumber(this.deviceValues!);

        }
    }

    /// <summary>
    /// Supports non consumable.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public bool? SupportsNonConsumable
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetSupportsNonConsumable(this.deviceValues!);
        }
    }

    /// <summary>
    /// Date and time of the media mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DateTime? DateTime
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetDateTime(this.deviceValues!);
        }
    }

    /// <summary>
    /// Supported formats are ordered.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public bool? SupportedFormatsAreOrdered
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetSupportedFormatsAreOrdered(this.deviceValues!);
        }
    }

    /// <summary>
    /// Device type of the portable mediaDevice.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DeviceType? DeviceType
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetDeviceType(this.deviceValues!);
        }
    }

    /// <summary>
    /// Network Identifier
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public ulong? NetworkIdentifier
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetNetworkIdentifier(this.deviceValues!);
        }
    }

    /// <summary>
    /// Functional unique id od the media mediaDevice
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public byte[]? FunctionalUniqueId
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetFunctionalUniqueId(this.deviceValues!);
        }
    }

    /// <summary>
    /// Model unique id od the media mediaDevice
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public byte[]? ModelUniqueId
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetModelUniqueId(this.deviceValues!);
        }
    }

    /// <summary>
    /// Device transport.
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DeviceTransport? Transport
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetTransport(this.deviceValues!);
        }
    }

    /// <summary>
    /// Use mediaDevice stage
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public DeviceTransport? UseDeviceStage
    {
        get
        {
            NotConnectedException.ThrowIfNotConnected(this);
            return mainWorker.GetUseDeviceStage(this.deviceValues!);

        }
    }

    #endregion
}
