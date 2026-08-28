namespace MediaDevices;

// Explicit Interface Implementation
partial class MediaDevice : INikonMediaDevice
{
    IEnumerable<OpCodesNikon> INikonMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.VendorOpcodes<OpCodesNikon>(this.device!));
    }

    #region Camera Setup & Configuration

    int? INikonMediaDevice.ShootingMode
    {
        get => GetDevicePropertyInt(WPD.CanonDevicePropertyShootingMode);
        set => SetDeviceProperty(WPD.CanonDevicePropertyShootingMode, value);
    }

    string? INikonMediaDevice.ShootingBankNameA
    {
        get => GetDevicePropertyString(WPD.NikonDevicePropertyShootingBankNameA);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShootingBankNameA, value);
    }

    string? INikonMediaDevice.ShootingBankNameB
    {
        get => GetDevicePropertyString(WPD.NikonDevicePropertyShootingBankNameB);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShootingBankNameB, value);
    }

    string? INikonMediaDevice.ShootingBankNameC
    {
        get => GetDevicePropertyString(WPD.NikonDevicePropertyShootingBankNameC);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShootingBankNameC, value);
    }

    string? INikonMediaDevice.ShootingBankNameD
    {
        get => GetDevicePropertyString(WPD.NikonDevicePropertyShootingBankNameD);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShootingBankNameD, value);
    }

    void INikonMediaDevice.ResetCurrentBank() 
        => SetDeviceProperty(WPD.NikonDevicePropertyResetBank, 0);

    NikonRawCompression? INikonMediaDevice.RawCompression
    {
        get => (NikonRawCompression?)GetDevicePropertyUInt(WPD.CanonDevicePropertyShootingMode);
        set => SetDeviceProperty(WPD.CanonDevicePropertyShootingMode, (uint?)value);
    }

    int? INikonMediaDevice.WhiteBalanceAutoBias
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyWhiteBalanceAutoBias);
        set => SetDeviceProperty(WPD.NikonDevicePropertyWhiteBalanceAutoBias, value);
    }

    NikonCompressionNL? INikonMediaDevice.CompressionNL
    {
        get => (NikonCompressionNL?)GetDevicePropertyUInt(WPD.NikonDevicePropertyCompressionNL);
        set => SetDeviceProperty(WPD.NikonDevicePropertyCompressionNL, (uint?)value);
    }

    NikonImageSize? INikonMediaDevice.ImageSize
    {
        get => (NikonImageSize?)GetDevicePropertyUInt(WPD.NikonDevicePropertyImageSize);
        set => SetDeviceProperty(WPD.NikonDevicePropertyImageSize, (uint?)value);
    }

    #endregion

    #region Exposure Control

    int? INikonMediaDevice.FNumber
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyFNumber);
        set => SetDeviceProperty(WPD.NikonDevicePropertyFNumber, value);
    }

    int? INikonMediaDevice.FocalLength
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyFocalLength);
        set => SetDeviceProperty(WPD.NikonDevicePropertyFocalLength, value);
    }

    int? INikonMediaDevice.EffectMode
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyEffectMode);
        set => SetDeviceProperty(WPD.NikonDevicePropertyEffectMode, value);
    }
    int? INikonMediaDevice.ExposureProgram
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyExposureProgram);
        set => SetDeviceProperty(WPD.NikonDevicePropertyExposureProgram, value);
    }
    int? INikonMediaDevice.ExposureIndex
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyExposureIndex);
        set => SetDeviceProperty(WPD.NikonDevicePropertyExposureIndex, value);
    }

    #endregion

    #region Live View & Focus Settings

    NokiaLiveViewStatus? INikonMediaDevice.LiveViewStatus
    {
        get => (NokiaLiveViewStatus?)GetDevicePropertyUInt(WPD.NikonDevicePropertyLiveViewStatus);
        set => SetDeviceProperty(WPD.NikonDevicePropertyLiveViewStatus, (uint?)value);
    }

    NikonLiveViewDriveMode? INikonMediaDevice.LiveViewDriveMode
    {
        get => (NikonLiveViewDriveMode?)GetDevicePropertyUInt(WPD.NikonDevicePropertyLiveViewDriveMode);
        set => SetDeviceProperty(WPD.NikonDevicePropertyLiveViewDriveMode, (uint?)value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Legacy DSLR Generation (e.g., Nikon D850, D7500, D4S)</remarks>
    NikonLiveViewAFAreaD? INikonMediaDevice.LiveViewAFAreaD
    {
        get => (NikonLiveViewAFAreaD?)GetDevicePropertyUInt(WPD.NikonDevicePropertyLiveViewAFArea);
        set => SetDeviceProperty(WPD.NikonDevicePropertyLiveViewAFArea, (uint?)value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>Modern Mirrorless Generation (e.g., Nikon Z6 II, Z7 II, Z8, Z9)</remarks>
    NikonLiveViewAFAreaZ? INikonMediaDevice.LiveViewAFAreaZ
    {
        get => (NikonLiveViewAFAreaZ?)GetDevicePropertyUInt(WPD.NikonDevicePropertyLiveViewAFArea);
        set => SetDeviceProperty(WPD.NikonDevicePropertyLiveViewAFArea, (uint?)value);
    }

    NikonFocusMode? INikonMediaDevice.FocusMode
    {
        get => (NikonFocusMode?)GetDevicePropertyUInt(WPD.NikonDevicePropertyFocusMode);
        set => SetDeviceProperty(WPD.NikonDevicePropertyFocusMode, (uint?)value);
    }

    #endregion

    #region Capture & Shutter

    NikonRecordingMedia? INikonMediaDevice.RecordingMedia
    {
        get => (NikonRecordingMedia?)GetDevicePropertyUInt(WPD.NikonDevicePropertyRecordingMedia);
        set => SetDeviceProperty(WPD.NikonDevicePropertyRecordingMedia, (uint?)value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Fractional shutter speeds are represented by multiplying the fraction out or utilizing Nikon's internal lookup table 
    /// (e.g., 1/4000 or legacy hex bit-masks like 0x00010000).
    /// ShutterSpeedBulbMode: The shutter stays open as long as the capture command pin is held active.
    /// ShutterSpeedTimeMode: The first shutter command opens the exposure; a second distinct command closes it.
    /// </remarks>
    uint? INikonMediaDevice.ShutterSpeed
    {
        get => GetDevicePropertyUInt(WPD.NikonDevicePropertyShutterSpeed);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShutterSpeed, value);
    }

    NikonBurstMode? INikonMediaDevice.BurstMode
    {
        get => (NikonBurstMode?)GetDevicePropertyUInt(WPD.NikonDevicePropertyBurstMode);
        set => SetDeviceProperty(WPD.NikonDevicePropertyBurstMode, (uint?)value);
    }

    #endregion
}
