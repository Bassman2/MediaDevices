namespace MediaDevices.Internal;

[ComConversionLoss]
internal struct PropVariantData
{
    public uint cData;

    [ComConversionLoss]
    public IntPtr pData;
}
