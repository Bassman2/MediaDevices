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
