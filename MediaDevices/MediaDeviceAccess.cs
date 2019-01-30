namespace MediaDevices
{
    /// <summary>
    /// Specifies the desired access the client is requesting to this driver.
    /// </summary>
    public enum MediaDeviceAccess : uint
    {
        /// <summary>
        /// Use the default value. 
        /// </summary>
        Default = 0,

        /// <summary>
        /// All possible access rights
        /// </summary>
        GenericAll = 0x10000000,

        /// <summary>
        /// Execute access
        /// </summary>
        GenericExcecute = 0x20000000,

        /// <summary>
        /// Write access
        /// </summary>
        GenericWrite = 0x40000000,

        /// <summary>
        /// Read access
        /// </summary>
        GenericRead = 0x80000000,  
    }
}
