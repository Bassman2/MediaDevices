namespace MediaDevices;

public enum OpCodesCanon : ushort
{

    #region Canon Powershot (0x9001 - 0x9035)

    /// <summary>
    /// Retrieves the size of a specified object on the Canon PowerShot device.
    /// </summary>
    GetPartialObjectInfo = 0x9001,

    SetObjectArchive = 0x9002,

    /// <summary>
    /// Keeps the Canon PowerShot device active to prevent automatic power-down during communication sessions.
    /// </summary>
    KeepDeviceOn = 0x9003,

    /// <summary>
    /// Locks the user interface on the Canon PowerShot device to prevent accidental button presses during remote operations.
    /// </summary>
    LockDeviceUI = 0x9004,

    /// <summary>
    /// Unlocks the user interface on the Canon PowerShot device to allow normal button presses and manual control.
    /// </summary>
    UnlockDeviceUI = 0x9005,

    GetViewfinderUserDefinedLines = 0x9008,

    ///// <summary>
    ///// Initiates remote camera release control mode on the Canon PowerShot device for triggering captures.
    ///// </summary>
    //InitiateReleaseControl = 0x9008,

    /// <summary>
    /// Enables the viewfinder display on the Canon PowerShot device to show real-time preview.
    /// </summary>
    ViewfinderOn = 0x900B,

    /// <summary>
    /// Disables the viewfinder display on the Canon PowerShot device to conserve power.
    /// </summary>
    ViewfinderOff = 0x900C,


    GetChanges = 0x9010,

    GetFolderEntries = 0x9011,

    GetFormatEffects = 0x9012,

    FormatEffectsStore = 0x9013,
    ///// <summary>
    ///// Checks for pending events on the Canon PowerShot device such as button presses or focus completion.
    ///// </summary>
    //CheckEvent = 0x9013,


    GetCustomFuncs = 0x9018,

    GetAsphericalLensData = 0x901B,

    /// <summary>
    /// Retrieves the current viewfinder image from the Canon PowerShot device for live preview display.
    /// </summary>
    GetViewfinderImage = 0x901D,

    InitiateDirectTransfer = 0x902F,

    ///// <summary>
    ///// Sets wireless LAN pairing information on the Canon PowerShot device for network connectivity.
    ///// </summary>
    //SetPairingInfoWLAN = 0x902F,

    TerminateDirectTransfer = 0x9030,

    ///// <summary>
    ///// Sets Bluetooth pairing information on the Canon PowerShot device for wireless communication.
    ///// </summary>
    //SetPairingInfoBluetooth = 0x9030,

    SetDisplayMonitor = 0x9034,

    PairingComplete = 0x9035,



    #endregion

    #region Canon EOS (0x9191 - 0x9155)

    EOS_TerminateEventProc = 0x905A,

    EOS_ExecuteEventProc = 0x9052,

    EOS_GetEventProcResult = 0x9053,

    EOS_GetEventProcList = 0x9057,

    EOS_ExecuteEventProcAsync = 0x9058,

    EOS_GetEventProcActiveList = 0x9059,

   EOS_GetLensParams = 0x9060,

    EOS_GetCounterValues = 0x905F,

    // File handling and memory

    /// <summary>
    /// Retrieves the list of storage device identifiers (handles) available on the Canon EOS camera.
    /// </summary>
    EOS_GetStorageIDs = 0x9101,

    EOS_GetStorageInfo = 0x9102,

    EOS_GetObjectInfo = 0x9103,

    /// <summary>
    /// Downloads a file object from the Canon EOS camera to the PC.
    /// </summary>
    EOS_GetObject = 0x9104,

    EOS_DeleteObject = 0x9105,
    EOS_FormatStore = 0x9106,
    EOS_GetPartialObject = 0x9107,

    /// <summary>
    /// Queries extended device information and capabilities specific to Canon EOS cameras.
    /// </summary>
    EOS_GetDeviceInfoEx = 0x9108,

    EOS_GetObjectInfoEx = 0x9109,

    EOS_GetThumbEx = 0x910A,
    EOS_SendPartialObject = 0x910B,
    EOS_SetObjectAttributes = 0x910C,

    EOS_SetObjectTime = 0x910E,

    // Camera handling

    /// <summary>
    /// Triggers a remote shutter release on the Canon EOS camera.
    /// </summary>
    /// <remarks>Triggers the camera via USB/IP.</remarks>
    EOS_RemoteRelease = 0x910F,

    EOS_SetDevicePropValueEx = 0x9110,

    EOS_GetRemoteMode = 0x9113,

    /// <summary>
    /// Enables or disables remote control mode on the Canon EOS camera.
    /// </summary>
    /// <remarks>Switches the camera to PC control mode.</remarks>
    EOS_SetRemoteMode = 0x9114,

    EOS_SetEventMode = 0x9115,

    /// <summary>
    /// Polls for pending events on the Canon EOS camera such as button presses, focus completion, or operational status changes.
    /// </summary>
    /// <remarks>Queries camera events, e.g., setting changes.</remarks>
    EOS_GetEvent = 0x9116,
    
    EOS_TransferComplete = 0x9117,

    EOS_CancelTransfer = 0x9118,

    EOS_ResetTransfer = 0x9119,

    EOS_PCHDDCapacity = 0x911A,

    EOS_SetUILock = 0x911B,

    EOS_ResetUILock = 0x911C,

    EOS_KeepDeviceOn = 0x911D,

    EOS_SetNullEventMode = 0x911E,
    
    EOS_SetDisplayMonitor = 0x911F,

    // Data Transfer

    EOS_TransferCompleteDT = 0x9120,

    EOS_CancelTransferDT = 0x9121,

    EOS_SetTransferTargetDT = 0x9122,


    // Bulk

    /// <summary>
    /// Initiates continuous bulb exposure (long shutter) mode on the Canon EOS camera.
    /// </summary>
    /// <remarks>For long exposures</remarks>
    EOS_BulbStart = 0x9125,

    /// <summary>
    /// Terminates continuous bulb exposure (long shutter) mode on the Canon EOS camera.
    /// </summary>
    /// <remarks>For long exposures</remarks>
    EOS_BulbEnd = 0x9126,

    EOS_RequestDevicePropValue = 0x9127,

    EOS_RemoteReleaseOn = 0x9128,

    EOS_RemoteReleaseOff = 0x9129,

    EOS_ChangePhotoStudioMode = 0x912B,

    EOS_GetPartialObjectEx = 0x912C,

    EOS_ReSizeImageData = 0x912D,

    EOS_GetReSizeData = 0x912E,
    
    EOS_ReleaseReSizeData = 0x912F,

    EOS_ResetMirrorLockupState = 0x9130,

    EOS_InitiateGetPartialObjectEx = 0x9131,

    EOS_EndGetPartialObjectEx = 0x9132,

    EOS_MovieSelectSWOn = 0x9133,

    EOS_MovieSelectSWOff = 0x9134,

    EOS_InitiateGetViewfinderData = 0x9135,

    EOS_TerminateGetViewfinderData = 0x9136,

    EOS_InitiateGetViewfinderDataEx = 0x9137,

    // Viewfinder

    /// <summary>
    /// Starts the viewfinder preview stream on the Canon EOS camera for live view display.
    /// </summary>
    /// <remarks>For Live View</remarks>
    EOS_InitiateViewfinder = 0x9151,

    /// <summary>
    /// Stops the viewfinder preview stream on the Canon EOS camera.
    /// </summary>
    /// <remarks>For Live View</remarks>
    EOS_TerminateViewfinder = 0x9152,

    // LiveView and Focus

    /// <summary>
    /// Retrieves the current viewfinder image frame from the Canon EOS camera for live preview display.
    /// </summary>
    /// <remarks>Transfers the live view still images to the PC.</remarks>
    EOS_GetViewFinderDat = 0x9153,

    /// <summary>
    /// Triggers autofocus on the Canon EOS camera.
    /// </summary>
    EOS_DoAf = 0x9154,

    /// <summary>
    /// Controls lens focus motor movement on the Canon EOS camera for manual focus adjustments.
    /// </summary>
    /// <remarks>Manual focusing/lens stepping via software.</remarks>
    EOS_DriveLens = 0x9155,

    EOS_DepthOfFieldPreview = 0x9156,

    EOS_ClickWB = 0x9157,
    
    EOS_Zoom = 0x9158,
    
    EOS_ZoomPosition = 0x9159,

    EOS_SetLiveAfFrame = 0x915A,

    EOS_AfCancel = 0x9160,

    EOS_TransferComplete2 = 0x91F0,

    EOS_CancelTransfer2 = 0x91F1,

    EOS_FAPIMessageTX = 0x91FE,

    EOS_FAPIMessageRX = 0x91FF,

    #endregion

}
