namespace MediaDevices
{
    /// <summary>
    /// Power source of the device
    /// </summary>
    public enum PowerSource
    {
        /// <summary>
        /// Device does not report the power source.
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// The power source of the device is battery.
        /// </summary>
        Battery = 0,

        /// <summary>
        /// The power source of the device is external.
        /// </summary>
        External = 1
    }
}
