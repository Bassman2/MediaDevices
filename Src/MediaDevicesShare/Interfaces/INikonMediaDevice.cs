namespace MediaDevices;

public interface INikonMediaDevice
{
    IEnumerable<OpCodesNikon> VendorOpcodes();

    #region Camera Setup & Configuration

    // (0 = A, 1 = B, 2 = C, 3 = D)
    int? ShootingMode { get; set; }
    string? ShootingBankNameA { get; set; }
    string? ShootingBankNameB { get; set; }
    string? ShootingBankNameC { get; set; }
    string? ShootingBankNameD { get; set; }

    void ResetCurrentBank();

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Write operations will fail if the camera is currently in a state where RAW recording is disabled entirely, 
    /// such as being locked to a specialized scene mode
    /// </remarks>
    NikonRawCompression? RawCompression { get; set; }

    int? WhiteBalanceAutoBias { get; set; }
    int? CompressionNL { get; set; }
    int? ImageSize { get; set; }

    #endregion

    #region Exposure Control

    int? FNumber { get; set; }
    int? FocalLength { get; set; }
    int? EffectMode { get; set; }
    int? ExposureProgram { get; set; }
    int? ExposureIndex { get; set; }

    #endregion

    #region Live View & Focus Settings

    int? LiveViewStatus { get; set; }
    int? LiveViewDriveMode { get; set; }
    int? LiveViewAFArea { get; set; }
    int? FocusMode { get; set; }

    #endregion

    #region Capture & Shutter

    int? RecordingMedia { get; set; }
    int? ShutterSpeed { get; set; }
    int? BurstMode { get; set; }

    #endregion
}
