namespace MediaDevices;

public enum OpCodesPanasonic : ushort
{

    #region Panasonic 

    // Panasonic Basic and Session Control (0x91xx)

    /// <summary>
    /// Internal initialization command
    /// </summary>
    Panasonic_InternalInit = 0x9101,

    /// <summary>
    /// Starts a manufacturer-specific session (typically expects storage ID 0x00010001 as an argument).
    /// </summary>
    Panasonic_OpenSession = 0x9102,

    /// <summary>
    /// Properly closes the manufacturer-specific Panasonic session.
    /// </summary>
    Panasonic_CloseSession = 0x9103,

    /// <summary>
    /// Retrieves an extended device and protocol ID from the Lumix camera.
    /// </summary>
    Panasonic_GetExtDeviceID = 0x9104,

    // Lumix Remote and Camera Control (0x94xx)

    /// <summary>
    /// Initial control command to activate remote mode.
    /// </summary>
    Panasonic_InitRemoteMode = 0x9401,

    /// <summary>
    /// Queries manufacturer-specific camera properties (used extensively to read out Lumix-specific menu items).
    /// </summary>
    Panasonic_GetProperty = 0x9402,

    /// <summary>
    /// Changes Panasonic camera settings via USB command.
    /// </summary>
    Panasonic_SetProperty = 0x9403,

    /// <summary>
    /// The primary command to trigger the camera digitally (open shutter/take photo).
    /// </summary>
    Panasonic_InitiateCapture = 0x9404,

    /// <summary>
    /// Controls autofocus (AF) and exposure metering (AE) in shooting mode (equivalent to pressing the shutter button halfway).
    /// </summary>
    Panasonic_RecCtrl_AF_AE = 0x9405,

    /// <summary>
    /// Performs administrative functions on the camera (used, among other things, for software-controlled formatting of memory cards).
    /// </summary>
    Panasonic_SetupCtrl = 0x9406,

    #endregion

}
