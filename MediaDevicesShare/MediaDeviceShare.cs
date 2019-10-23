namespace MediaDevices
{
    /// <summary>
    /// Specifies the share mode the client is requesting to this device.
    /// </summary>
    public enum MediaDeviceShare : uint
    {
        /// <summary>
        /// Use the default value. 
        /// </summary>
        Default = 0, 

        /// <summary>
        /// Enables subsequent open operations on a file or device to request read access. 
        /// Otherwise, other processes cannot open the file or device if they request read access.
        /// If this flag is not specified, but the file or device has been opened for read access, the function fails.
        /// </summary>
        Read = 1,

        /// <summary>
        /// Enables subsequent open operations on a file or device to request write access. 
        /// Otherwise, other processes cannot open the file or device if they request write access.
        /// If this flag is not specified, but the file or device has been opened for write access or has a file mapping with write access, the function fails.
        /// </summary>
        Write = 2,

        /// <summary>
        /// Enables subsequent open operations on a file or device to request delete access. 
        /// Otherwise, other processes cannot open the file or device if they request delete access.
        /// If this flag is not specified, but the file or device has been opened for delete access, the function fails.
        /// </summary>
        Delete = 4,
    }
}
