namespace MediaDevices
{
    /// <summary>
    /// Indicates the current state of the operation in progress.
    /// </summary>
    public enum OperationState
    {
        /// <summary>
        /// Unspecified
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// Started
        /// </summary>
        Started = 1,

        /// <summary>
        /// Running
        /// </summary>
        Running = 2,

        /// <summary>
        /// Paused
        /// </summary>
        Paused = 3,

        /// <summary>
        /// Cancelled
        /// </summary>
        Cancelled = 4,

        /// <summary>
        /// Finished
        /// </summary>
        Finished = 5,

        /// <summary>
        /// Aborted
        /// </summary>
        Aborted = 6
    }
}
