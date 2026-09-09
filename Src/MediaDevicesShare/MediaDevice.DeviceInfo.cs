namespace MediaDevices;

partial class MediaDevice
{
    // all values from GetDeviceInfo operation

    public ushort StandardVersion { get; internal set; }

    public uint VendorExtensionId { get; internal set; }

    public ushort VendorExtensionVersion { get; internal set; }

    public string VendorExtensionDescription { get; internal set; } = string.Empty;

    public FunctionalMode FunctionalMode { get; internal set; }

    public Commands[] OperationsSupported { get; internal set; }

    public Events[] EventsSupported { get; internal set; }

    public ushort[] DevicePropertiesSupported { get; internal set; }

    public ushort[] CaptureFormats { get; internal set; }

    public ushort[] PlaybackFormats { get; internal set; }

    public string Manufacturer { get; internal set; }

    public string Model { get; internal set; }

    public string DeviceVersion { get; internal set; }

    public string SerialNumber { get; internal set; }
}
