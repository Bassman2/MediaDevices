using System;
using System.Runtime.InteropServices;

namespace MediaDevices.Internal
{
    [ComConversionLoss]
    internal struct PropVariantData
    {
        public uint cData;

        [ComConversionLoss]
        public IntPtr pData;
    }
}
