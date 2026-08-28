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

    int? INikonMediaDevice.CompressionNL
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyCompressionNL);
        set => SetDeviceProperty(WPD.NikonDevicePropertyCompressionNL, value);
    }

    int? INikonMediaDevice.ImageSize
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyImageSize);
        set => SetDeviceProperty(WPD.NikonDevicePropertyImageSize, value);
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

    int? INikonMediaDevice.LiveViewStatus
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyLiveViewStatus);
        set => SetDeviceProperty(WPD.NikonDevicePropertyLiveViewStatus, value);
    }
    int? INikonMediaDevice.LiveViewDriveMode
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyLiveViewDriveMode);
        set => SetDeviceProperty(WPD.NikonDevicePropertyLiveViewDriveMode, value);
    }
    int? INikonMediaDevice.LiveViewAFArea
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyLiveViewAFArea);
        set => SetDeviceProperty(WPD.NikonDevicePropertyLiveViewAFArea, value);
    }
    int? INikonMediaDevice.FocusMode
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyFocusMode);
        set => SetDeviceProperty(WPD.NikonDevicePropertyFocusMode, value);
    }

    #endregion

    #region Capture & Shutter

    int? INikonMediaDevice.RecordingMedia
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyRecordingMedia);
        set => SetDeviceProperty(WPD.NikonDevicePropertyRecordingMedia, value);
    }
    int? INikonMediaDevice.ShutterSpeed
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyShutterSpeed);
        set => SetDeviceProperty(WPD.NikonDevicePropertyShutterSpeed, value);
    }
    int? INikonMediaDevice.BurstMode
    {
        get => GetDevicePropertyInt(WPD.NikonDevicePropertyBurstMode);
        set => SetDeviceProperty(WPD.NikonDevicePropertyBurstMode, value);
    }

    #endregion
}
