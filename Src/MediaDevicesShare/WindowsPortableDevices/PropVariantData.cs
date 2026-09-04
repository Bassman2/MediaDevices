namespace MediaDevices.WindowsPortableDevices;

[ComConversionLoss]
internal struct PropVariantData
{
    public uint cData;

    [ComConversionLoss]
    public IntPtr pData;
}
