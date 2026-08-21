namespace MediaDevices;

public enum OpCodesFujifilm : ushort
{

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

}
