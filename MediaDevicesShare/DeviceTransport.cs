namespace MediaDevices
{
    /// <summary>
    /// device transports
    /// </summary>
    public enum DeviceTransport
    {
        /// <summary>
        /// not supportet by driver
        /// </summary>
        NotSupported = -1,

        /// <summary>
        /// unspecified transport
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// USB transport
        /// </summary>
        USB = 1,

        /// <summary>
        /// IP transport
        /// </summary>
        IP = 2,

        /// <summary>
        /// bluetooth transport
        /// </summary>
        Bluetooth = 3
    }
}
