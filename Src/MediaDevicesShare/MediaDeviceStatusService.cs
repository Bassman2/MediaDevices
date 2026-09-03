namespace MediaDevices;

/// <summary>
/// Status service class
/// </summary>
public class MediaDeviceStatusService : MediaDeviceService
{
    internal MediaDeviceStatusService(IDevice device, string serviceId) : base(device, serviceId)
    {

    }

    /// <summary>
    /// Update service
    /// </summary>
    protected override void Update()
    {
        IPortableDeviceKeyCollection keyCol = ComHelper.CreateInstance<IPortableDeviceKeyCollection>();

        //int err = ComHelper.CreateInstance<IPortableDeviceKeyCollection>(ref CLSID.PortableDeviceKeyCollection, out var keyCol);
        //MediaDeviceException.ThrowIfComError(err, nameof(IPortableDeviceKeyCollection));



        keyCol.Add(ref WPD.SignalStrength);
        keyCol.Add(ref WPD.TextMessages);
        keyCol.Add(ref WPD.NewPictures);
        keyCol.Add(ref WPD.MissedCalls);
        keyCol.Add(ref WPD.VoiceMail);
        keyCol.Add(ref WPD.NetworkName);
        keyCol.Add(ref WPD.NetworkType);
        keyCol.Add(ref WPD.Roaming);
        keyCol.Add(ref WPD.BatteryLife);
        keyCol.Add(ref WPD.ChargingState);
        keyCol.Add(ref WPD.StorageCapacity);
        keyCol.Add(ref WPD.StorageFreeSpace);
        keyCol.Add(ref WPD.InternetConnected);
        IPortableDeviceValues values = GetProperties(keyCol);

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.SignalStrength, out value.Value);
            this.SignalStrength = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.TextMessages, out value.Value);
            this.TextMessages = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.NewPictures, out value.Value);
            this.NewPictures = value;
        }


        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.MissedCalls, out value.Value);
            this.MissedCalls = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.VoiceMail, out value.Value);
            this.VoiceMail = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.NetworkName, out value.Value);
            this.NetworkName = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.NetworkType, out value.Value);
            this.NetworkType = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.Roaming, out value.Value);
            this.Roaming = (Roaming)(byte)value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.BatteryLife, out value.Value);
            this.BatteryLife = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.ChargingState, out value.Value);
            this.ChargingState = (ChargingState)(byte)value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.StorageCapacity, out value.Value);
            this.StorageCapacity = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.StorageFreeSpace, out value.Value);
            this.StorageFreeSpace = value;
        }

        using (var value = new PropVariantFacade())
        {
            values.GetValue(ref WPD.InternetConnected, out value.Value);
            this.InternetConnected = value;
        }
    }

    /// <summary>
    /// Signal strength, from 0 to 4.
    /// </summary>
    public byte SignalStrength { get; private set; }

    /// <summary>
    /// Number of unread text messages.
    /// </summary>
    public byte TextMessages { get; private set; }

    /// <summary>
    /// Total number of pictures on the mediaDevice.
    /// </summary>
    public ushort NewPictures { get; private set; }

    /// <summary>
    /// Total number of missed calls on the mediaDevice.
    /// </summary>
    public byte MissedCalls { get; private set; }

    /// <summary>
    /// Total number of new voicemail messages on the mediaDevice/service. 
    /// For devices that have only a binary state, 0 represents no new voicemail messages and 0xFF represents new messages.
    /// </summary>
    public byte VoiceMail { get; private set; }

    /// <summary>
    /// Human-readable name of the current mobile network (for example, “Microsoft Cellular”).
    /// </summary>
    public string? NetworkName { get; private set; }

    /// <summary>
    /// Type of mobile network that the mediaDevice is currently using (for example, “E” for EDGE, “U” for UMTS, or “1x” for 1xRTT).
    /// </summary>
    public string? NetworkType { get; private set; }

    /// <summary>
    /// Roaming type.
    /// </summary>
    public Roaming Roaming { get; private set; }

    /// <summary>
    /// Remaining battery life of the mediaDevice, as an integer from 0 to 100.
    /// </summary>
    public byte BatteryLife { get; private set; }

    /// <summary>
    /// Charging state
    /// </summary>
    public ChargingState ChargingState { get; private set; }

    /// <summary>
    /// Total usable storage capacity of the mediaDevice, in bytes, across all storage locations.
    /// </summary>
    public ulong StorageCapacity { get; private set; }

    /// <summary>
    /// Total usable free space on the mediaDevice, in bytes, across all storage locations.
    /// </summary>
    public ulong StorageFreeSpace { get; private set; }

    /// <summary>
    /// Boolean value that indicates whether the mobile mediaDevice is connected to an outside data network (such as the Internet).
    /// </summary>
    public bool InternetConnected { get; private set; }

}
