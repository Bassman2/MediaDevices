namespace MediaDevices.ProtocolStack;

internal enum MtpObjectFormat : ushort
{
    Undefined = 0x3000,
    Text = 0x3004,
    Format_JPEG = 0x3801,
    // Nutze Undefined (0x3000) für generische Dateien
}