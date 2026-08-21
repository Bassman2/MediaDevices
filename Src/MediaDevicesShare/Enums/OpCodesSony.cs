namespace MediaDevices;

public enum OpCodesSony : ushort
{
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
}
