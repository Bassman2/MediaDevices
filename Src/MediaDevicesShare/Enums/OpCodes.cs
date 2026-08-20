namespace MediaDevices;


#pragma warning disable CA1069

/// <summary>
/// Defines the operation codes (opcodes) used in Picture Transfer Protocol (PTP) and vendor-specific device communication.
/// </summary>
/// <remarks>
/// <para>
/// The OpCodes enum represents all supported operation codes for controlling and communicating with digital cameras 
/// and media devices using the PTP protocol and vendor-specific extensions.
/// </para>
/// <para>
/// The enum is organized into the following categories:
/// <list type="bullet">
/// <item><description>PTP Commands (0x1001 - 0x101C): Standard Picture Transfer Protocol commands for basic device operations.</description></item>
/// <item><description>Canon Powershot: Vendor-specific opcodes for Canon Powershot cameras.</description></item>
/// <item><description>Canon EOS: Vendor-specific opcodes for Canon EOS cameras, including live view and advanced capture features.</description></item>
/// <item><description>Nikon: Vendor-specific opcodes for Nikon cameras, including SDRAM capture and live view commands.</description></item>
/// <item><description>Vendor (0x9xxx): Generic vendor codes for unspecified manufacturers.</description></item>
/// <item><description>Microsoft Extensions (0x98xx): MTP (Media Transfer Protocol) extensions for object properties and references.</description></item>
/// </list>
/// </para>
/// <para>
/// Each opcode is a 16-bit unsigned integer (ushort) that identifies a specific command to send to the device.
/// The protocol layer uses these codes to route commands to the appropriate device handler and parse responses.
/// </para>
/// </remarks>
public enum OpCodes : ushort
{
    /// <summary>
    /// Unknown command.
    /// </summary>
    Unknown = 0,

    #region PTP Commands (0x1001 - 0x101C

    /// <summary>
    /// Queries basic hardware and protocol data.
    /// </summary>
    GetDeviceInfo = 0x1001,

    /// <summary>
    /// Starts a new communication session with the device.
    /// </summary>
    OpenSession = 0x1002,

    /// <summary>
    /// Ends the active session.
    /// </summary>
    CloseSession = 0x1003,

    /// <summary>
    /// Provides a list of all available storage devices (e.g., internal storage, SD card).
    /// </summary>
    GetStorageIDs = 0x1004,

    /// <summary>
    /// Queries the capacity and free space of a storage device.
    /// </summary>
    GetStorageInfo = 0x1005,

    /// <summary>
    /// Returns the number of objects in a directory or storage.
    /// </summary>
    GetNumObjects = 0x1006,

    /// <summary>
    /// Retrieves a list of IDs (handles) for all files in a directory.
    /// </summary>
    GetObjectHandles = 0x1007,

    /// <summary>
    /// Retrieves metadata (file name, size, and type).
    /// </summary>
    GetObjectInfo = 0x1008,

    /// <summary>
    /// Starts the actual data transfer of a file from the device to the PC.
    /// </summary>
    GetObject = 0x1009,

    /// <summary>
    /// Downloads the thumbnail image of an object.
    /// </summary>
    GetThumb = 0x100A,

    /// <summary>
    /// Deletes a file or folder on the device.
    /// </summary>
    DeleteObject = 0x100B,

    /// <summary>
    /// Sends metadata for a new file to the device before the file is transferred.
    /// </summary>
    SendObjectInfo = 0x100C,

    /// <summary>
    /// Transfers the actual file data from the PC to the device.
    /// </summary>
    SendObject = 0x100D,

    /// <summary>
    /// Triggers the device's camera function to take a picture.
    /// </summary>
    InitiateCapture = 0x100E,

    /// <summary>
    /// Formats the specified storage medium.
    /// </summary>
    FormatStore = 0x100F,

    /// <summary>
    /// Retrieves the description/limits of a device property (e.g., battery level).
    /// </summary>
    GetDevicePropDesc = 0x1014,

    /// <summary>
    /// Reads the current value of a device property.
    /// </summary>
    GetDevicePropValue = 0x1015,

    /// <summary>
    /// Changes the value of a device property (e.g., time zone or name).
    /// </summary>
    SetDevicePropValue = 0x1016,

    /// <summary>
    /// Resets a device property to the factory default.
    /// </summary>
    ResetDevicePropValue = 0x1017,

    /// <summary>
    /// Reads only a specific section (byte range) of a file.
    /// </summary>
    GetPartialObject = 0x101B,

    /// <summary>
    /// Starts continuous media recording (e.g., video).
    /// </summary>
    InitiateOpenCapture = 0x101C,

    #endregion

    #region MTP Extentions (0x9201 - 0x9203) 

    /// <summary>
    /// Reports objects that have been added to or deleted from the device.
    /// </summary>
    /// <remarks>
    /// This MTP (Media Transfer Protocol) extension opcode is used to notify the host about changes
    /// to the file system on the device, allowing synchronization of added and removed items.
    /// </remarks>
    ReportAddedDeletedItems = 0x9201,

    /// <summary>
    /// Reports objects that have been acquired or captured by the device.
    /// </summary>
    /// <remarks>
    /// This MTP extension opcode notifies the host about newly captured or imported objects,
    /// such as recently taken photos or downloaded media on the device.
    /// </remarks>
    ReportAcquiredItems = 0x9202,

    /// <summary>
    /// Retrieves or manages playlist object preferences on the device.
    /// </summary>
    /// <remarks>
    /// This MTP extension opcode is used to query or configure playlist-related object preferences,
    /// enabling enhanced media management and playlist handling on devices that support this feature.
    /// </remarks>
    PlaylistObjectPref = 0x9203,

    #endregion

    #region Microsoft Zune (0x9204)

    /// <summary>
    /// Represents an undefined Microsoft Zune operation code.
    /// </summary>
    /// <remarks>
    /// This is a vendor-specific opcode used by Microsoft Zune devices. The exact functionality
    /// of this operation is not documented or is device-specific. This opcode should be handled
    /// with care as its behavior may vary depending on the device implementation.
    /// </remarks>
    Zune_GetUndefined001 = 0x9204,

    #endregion

    #region Canon Powershot

    /// <summary>
    /// Retrieves the size of a specified object on the Canon PowerShot device.
    /// </summary>
    Canon_PowershotGetObjectSize = 0x9001,

    /// <summary>
    /// Keeps the Canon PowerShot device active to prevent automatic power-down during communication sessions.
    /// </summary>
    Canon_PowershotKeepDeviceOn = 0x9003,

    /// <summary>
    /// Locks the user interface on the Canon PowerShot device to prevent accidental button presses during remote operations.
    /// </summary>
    Canon_PowershotLockDeviceUI = 0x9004,

    /// <summary>
    /// Unlocks the user interface on the Canon PowerShot device to allow normal button presses and manual control.
    /// </summary>
    Canon_PowershotUnlockDeviceUI = 0x9005,

    /// <summary>
    /// Initiates remote camera release control mode on the Canon PowerShot device for triggering captures.
    /// </summary>
    Canon_PowershotInitiateReleaseControl = 0x9008,

    /// <summary>
    /// Enables the viewfinder display on the Canon PowerShot device to show real-time preview.
    /// </summary>
    Canon_PowershotViewfinderOn = 0x900B,

    /// <summary>
    /// Disables the viewfinder display on the Canon PowerShot device to conserve power.
    /// </summary>
    Canon_PowershotViewfinderOff = 0x900C,

    /// <summary>
    /// Checks for pending events on the Canon PowerShot device such as button presses or focus completion.
    /// </summary>
    Canon_PowershotCheckEvent = 0x9013,

    /// <summary>
    /// Retrieves the current viewfinder image from the Canon PowerShot device for live preview display.
    /// </summary>
    Canon_PowershotGetViewfinderImage = 0x901D,

    /// <summary>
    /// Sets wireless LAN pairing information on the Canon PowerShot device for network connectivity.
    /// </summary>
    Canon_PowershotSetPairingInfoWLAN = 0x902F,

    /// <summary>
    /// Sets Bluetooth pairing information on the Canon PowerShot device for wireless communication.
    /// </summary>
    Canon_PowershotSetPairingInfoBluetooth = 0x9030,

    #endregion

    #region Canon EOS

    /// <summary>
    /// Retrieves the list of storage device identifiers (handles) available on the Canon EOS camera.
    /// </summary>
    Canon_EOSGetStorageIDs = 0x9101,

    /// <summary>
    /// Downloads a file object from the Canon EOS camera to the PC.
    /// </summary>
    Canon_EOSGetObject = 0x9104,

    /// <summary>
    /// Queries extended device information and capabilities specific to Canon EOS cameras.
    /// </summary>
    Canon_EOSGetDeviceInfoEx = 0x9108,

    /// <summary>
    /// Triggers a remote shutter release on the Canon EOS camera.
    /// </summary>
    /// <remarks>Triggers the camera via USB/IP.</remarks>
    Canon_EOSRemoteRelease = 0x910F,


    /// <summary>
    /// Enables or disables remote control mode on the Canon EOS camera.
    /// </summary>
    /// <remarks>Switches the camera to PC control mode.</remarks>
    Canon_EOSSetRemoteMode = 0x9114,

    /// <summary>
    /// Polls for pending events on the Canon EOS camera such as button presses, focus completion, or operational status changes.
    /// </summary>
    /// <remarks>Queries camera events, e.g., setting changes.</remarks>
    Canon_EOSGetEvent = 0x9116,

    /// <summary>
    /// Initiates continuous bulb exposure (long shutter) mode on the Canon EOS camera.
    /// </summary>
    /// <remarks>For long exposures</remarks>
    Canon_EOSBulbStart = 0x9125,

    /// <summary>
    /// Terminates continuous bulb exposure (long shutter) mode on the Canon EOS camera.
    /// </summary>
    /// <remarks>For long exposures</remarks>
    Canon_EOSBulbEnd = 0x9126,

    /// <summary>
    /// Starts the viewfinder preview stream on the Canon EOS camera for live view display.
    /// </summary>
    /// <remarks>For Live View</remarks>
    Canon_EOSInitiateViewfinder = 0x9151,

    /// <summary>
    /// Stops the viewfinder preview stream on the Canon EOS camera.
    /// </summary>
    /// <remarks>For Live View</remarks>
    Canon_EOSTerminateViewfinder = 0x9152,

    /// <summary>
    /// Retrieves the current viewfinder image frame from the Canon EOS camera for live preview display.
    /// </summary>
    /// <remarks>Transfers the live view still images to the PC.</remarks>
    Canon_EOSGetViewFinderImage = 0x9153,

    /// <summary>
    /// Triggers autofocus on the Canon EOS camera.
    /// </summary>
    Canon_EOSDoAf = 0x9154,

    /// <summary>
    /// Controls lens focus motor movement on the Canon EOS camera for manual focus adjustments.
    /// </summary>
    /// <remarks>Manual focusing/lens stepping via software.</remarks>
    Canon_EOSDriveLens = 0x9155,

    #endregion

    #region Nikon

    // Capture and Focus Control (0x90xx)

    /// <summary>
    /// Triggers the camera and saves the image directly to the camera's internal memory (SDRAM) instead of the memory card.
    /// </summary>
    Nikon_InitiateCaptureRecInSdram = 0x90C0,

    /// <summary>
    /// Activates and controls the lens's autofocus motor.
    /// </summary>
    Nikon_AfDrive = 0x90C1,

    /// <summary>
    /// Combined command: Automatically focuses and triggers directly to SDRAM.
    /// </summary>
    Nikon_AfCaptureSDRAM = 0x90CB,

    /// <summary>
    /// Switches between internal camera modes or priorities.
    /// </summary>
    Nikon_ChangeCameraMode = 0x90C2,

    /// <summary>
    /// Deletes an image previously stored in volatile SDRAM.
    /// </summary>
    Nikon_DelImageSDRAM = 0x90C3,

    /// <summary>
    /// Downloads a high-resolution preview image (full-screen thumbnail).
    /// </summary>
    Nikon_GetLargeThumb = 0x90C4,

    // Live View and Real-Time Streaming (0x92xx)

    /// <summary>
    /// The code 0x9200 marks the exact beginning of the live-view command class. It is included by the camera firmware as a placeholder but does not itself perform any executable function.
    /// </summary>
    Nikon_Placeholder = 0x9200,

    /// <summary>
    /// Flips up the mirror (on DSLRs) and starts the camera's Live View mode.
    /// </summary>
    Nikon_StartLiveView = 0x9201,

    /// <summary>
    /// Ends live view mode and closes the sensor stream.
    /// </summary>
    Nikon_EndLiveView = 0x9202,

    /// <summary>
    /// Retrieves the current live image as a continuous JPEG frame (called in a loop for video preview).
    /// </summary>
    Nikon_GetLiveViewImg = 0x9203,

    /// <summary>
    /// Controls the focus motor manually in precise steps (important for software-based macro focus stacking).
    /// </summary>
    Nikon_MfDrive = 0x9204,

    /// <summary>
    /// Moves the autofocus point in the Live View image.
    /// </summary>
    Nikon_ChangeAfArea = 0x9205,

    /// <summary>
    /// Immediately cancels an ongoing autofocus operation.
    /// </summary>
    Nikon_InitiateCaptureRecInMedia = 0x9207,

    // Diagnostics, profiles, and camera events

    /// <summary>
    /// Queries the camera's event buffer. 
    /// The camera responds with manufacturer-specific event codes 
    /// (e.g., 0xC101 for Nikon_ObjectAddedInSDRAM or 0xC10C for Nikon_LiveViewStateChanged).
    /// </summary>
    Nikon_GetEvent = 0x90C7,

    /// <summary>
    /// Lists all manufacturer-specific device features supported by this Nikon model.
    /// </summary>
    Nikon_GetVendorPropCodes = 0x90CA,

    /// <summary>
    /// Reads the camera's "Picture Control" profiles (color profiles such as Standard, Neutral, and Portrait).
    /// </summary>
    Nikon_GetPictCtrlData = 0x90CC,

    /// <summary>
    /// Writes the camera's "Picture Control" profiles (color profiles such as Standard, Neutral, and Portrait).
    /// </summary>
    Nikon_SetPictCtrlData = 0x90CD,

    /// <summary>
    /// Used with older network profiles (Wi-Fi/Ethernet transfers).
    /// </summary>
    Nikon_GetProfileAllData = 0x9006,

    /// <summary>
    /// Used with older network profiles (Wi-Fi/Ethernet transfers).
    /// </summary>
    Nikon_SetProfileData = 0x9009,

    #endregion

    #region Sony

    // Sony SDIO Core Operations (0x92xx)

    /// <summary>
    /// Performs the initial authentication handshake to unlock advanced PC control.
    /// </summary>
    Sony_SDIO_Connect = 0x9201,

    /// <summary>
    /// Retrieves extended Sony protocol versions and lists of supported properties.
    /// </summary>
    Sony_SDIO_GetExtDeviceInfo = 0x9202,

    /// <summary>
    /// Retrieves specific object metadata for Sony file structures.
    /// </summary>
    Sony_SDIO_GetExtObjectInfo = 0x9203,

    /// <summary>
    /// Downloads media objects via optimized Sony data channels.
    /// </summary>
    Sony_SDIO_GetExtObject = 0x9204,

    /// <summary>
    /// Sets manufacturer-specific camera properties (e.g., exposure or focus modes)
    /// </summary>
    Sony_SDIO_SetExtDevicePropValue = 0x9205,

    /// <summary>
    /// Transmits direct triggering and control commands to the camera electronics (e.g., opening the shutter).
    /// </summary>
    Sony_SDIO_ControlDevice = 0x9207,

    /// <summary>
    /// Retrieves all current camera settings simultaneously. 
    /// PCs send this command at regular intervals to reflect changes made to the camera settings by the photographer live within the software.
    /// </summary>
    Sony_SDIO_GetAllExtDevicePropInfo = 0x9209,

    // Sony DiExtCmd & App-Installer

    /// <summary>
    /// Used for direct memory and firmware write accesses.
    /// </summary>
    Sony_DiExtCmd_write = 0x98a1,

    /// <summary>
    /// Used for direct memory and firmware read accesses.
    /// </summary>
    Sony_DiExtCmd_read = 0x98a2,

    /// <summary>
    /// Forces a restart of the USB interface to switch the device to a different mode (e.g., app mode or mass storage) via software control.
    /// </summary>
    Sony_ReqReconnect = 0x98a3,

    #endregion

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

    #region Fujifilm 

    /// <summary>
    /// Switches the camera to "tethering mode" via software. 
    /// The camera's display typically locks or shows a connection icon while control is handed over to the USB channel.
    /// </summary>
    Fujifilm_InitiateTethering = 0x9021,

    /// <summary>
    /// Queries the manufacturer-specific event buffer to report asynchronous camera changes 
    /// (e.g., when the photographer manually turns the aperture ring) to the PC.
    /// </summary>
    Fujifilm_GetCheckEvent = 0x902B,

    #endregion

    #region Leica

    /// <summary>
    /// Used by desktop applications such as Leica Image Shuttle to transfer camera settings and profiles directly to the camera body.
    /// </summary>
    Leica_SetCameraSettings = 0x9001,

    /// <summary>
    /// Retrieves the current configuration package and the status of the camera system.
    /// </summary>
    Leica_GetCameraSettings = 0x9002,

    /// <summary>
    /// Reads out specific lens parameters. 
    /// This is used, among other things, in the Adobe Lightroom tethering plugin to retrieve lens metadata from digital rangefinder cameras (such as the M-series).
    /// </summary>
    Leica_GetLensParameter = 0x9003,

    #endregion

    #region Samsung

    /// <summary>
    /// Samsung vendor-specific opcode (0x9501).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Samsung_Unknown1 = 0x9501,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9502).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Samsung_Unknown2 = 0x9502,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9503).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Samsung_Unknown3 = 0x9503,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9504).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Samsung_Unknown4 = 0x9504,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9201).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Samsung_Unknown5 = 0x9201,

    /// <summary>
    /// Samsung vendor-specific opcode (0x9202).
    /// Purpose is not publicly documented; observed in Samsung device traffic.
    /// Treat as reserved/vendor-specific and avoid relying on behavior across models/firmware.
    /// </summary>
    Samsung_Unknown6 = 0x9202,

    #endregion

    #region Vendor 0x9

    /// <summary>
    /// Vendor code 0x9001 
    /// </summary>
    Vendor_001 = 0x9001,

    /// <summary>
    /// Vendor code 0x9002 
    /// </summary>
    Vendor_002 = 0x9002,

    /// <summary>
    /// Vendor code 0x9003 
    /// </summary>
    Vendor_003 = 0x9003,

    /// <summary>
    /// Vendor code 0x9004 
    /// </summary>
    Vendor_004 = 0x9004,

    /// <summary>
    /// Vendor code 0x9005 
    /// </summary>
    Vendor_005 = 0x9005,

    /// <summary>
    /// Vendor code 0x9006 
    /// </summary>
    Vendor_006 = 0x9006,

    /// <summary>
    /// Vendor code 0x9007 
    /// </summary>
    Vendor_007 = 0x9007,

    /// <summary>
    /// Vendor code 0x9008 
    /// </summary>
    Vendor_008 = 0x9008,

    /// <summary>
    /// Vendor code 0x9009 
    /// </summary>
    Vendor_009 = 0x9009,

    /// <summary>
    /// Vendor code 0x900A 
    /// </summary>
    Vendor_00A = 0x900A,

    /// <summary>
    /// Vendor code 0x900B 
    /// </summary>
    Vendor_00B = 0x900B,

    /// <summary>
    /// Vendor code 0x900C 
    /// </summary>
    Vendor_00C = 0x900C,

    /// <summary>
    /// Vendor code 0x900D 
    /// </summary>
    Vendor_00D = 0x900D,

    /// <summary>
    /// Vendor code 0x900E 
    /// </summary>
    Vendor_00E = 0x900E,

    /// <summary>
    /// Vendor code 0x900F 
    /// </summary>
    Vendor_00F = 0x900F,

    /// <summary>
    /// Vendor code 0x9010 
    /// </summary>
    Vendor_010 = 0x9010,

    /// <summary>
    /// Vendor code 0x901A 
    /// </summary>
    Vendor_01A = 0x901A,

    /// <summary>
    /// Vendor code 0x901B 
    /// </summary>
    Vendor_01B = 0x901B,

    /// <summary>
    /// Vendor code 0x901C 
    /// </summary>
    Vendor_01C = 0x901C,

    /// <summary>
    /// Vendor code 0x901D 
    /// </summary>
    Vendor_01D = 0x901D,

    /// <summary>
    /// Vendor code 0x901E 
    /// </summary>
    Vendor_01E = 0x901E,

    /// <summary>
    /// Vendor code 0x901F 
    /// </summary>
    Vendor_01F = 0x901F,

    /// <summary>
    /// Vendor code 0x9701 
    /// </summary>
    Vendor_701 = 0x9701,

    /// <summary>
    /// Vendor code 0x901F 
    /// </summary>
    Vendor_702 = 0x9702,

    #endregion

    #region Microsoft Extentions

    /// <summary>
    /// Lists the metadata properties supported by a file format.
    /// </summary>
    GetObjectPropsSupported = 0x9801,

    /// <summary>
    /// Provides the technical description of a specific object property.
    /// </summary>
    GetObjectPropDesc = 0x9802,

    /// <summary>
    /// Reads a specific property of a file (e.g., song artist).
    /// </summary>
    GetObjectPropValue = 0x9803,

    /// <summary>
    /// Writes/modifies a specific file property on the device.
    /// </summary>
    SetObjectPropValue = 0x9804,

    /// <summary>
    /// Queries a list of multiple properties for one or more objects simultaneously (important for fast browsing).
    /// </summary>
    GetObjPropList = 0x9805,

    /// <summary>
    /// Changes multiple properties for multiple objects in one go.
    /// </summary>
    SetObjPropList = 0x9806,

    /// <summary>
    /// Lists dependencies between different properties.
    /// </summary>
    GetInterdependentPropDesc = 0x9807,

    /// <summary>
    /// Transfers a list of properties in parallel when creating a new file.
    /// </summary>
    SendObjectPropList = 0x9808,

    /// <summary>
    /// Retrieves an object's links (used for playlists).
    /// </summary>
    GetObjectReferences = 0x9810,

    /// <summary>
    /// Creates or overwrites links (e.g., adding a title to a playlist).
    /// </summary>
    SetObjectReferences = 0x9811,

    /// <summary>
    /// Skips data fragments during sequential data transmission.
    /// </summary>
    Skip = 0x9812,

    #endregion
}
