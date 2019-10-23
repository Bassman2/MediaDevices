namespace MediaDevices
{
    /// <summary>
    /// Device charging state
    /// </summary>
    public enum ChargingState : byte
    {
        /// <summary>
        /// The battery is not charging. 
        /// </summary>
        NotCharging = 0,

        /// <summary>
        /// The battery is currently charging.
        /// </summary>
        Charging = 1,

        /// <summary>
        /// The charging status is unknown.
        /// </summary>
        Unknown = 2
    }
}
