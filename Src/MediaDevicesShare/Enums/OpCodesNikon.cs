namespace MediaDevices;

public enum OpCodesNikon
{

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

}
