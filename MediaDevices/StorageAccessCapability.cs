namespace MediaDevices
{
    /// <summary>
    /// Storage Access Capability
    /// </summary>
    public enum StorageAccessCapability : uint
    {
        /// <summary>
        /// Read Write
        /// </summary>
        ReadWrite = 0,

        /// <summary>
        /// Read only without object deletion
        /// </summary>
        ReadOnlyWithoutObjectDeletion = 1,

        /// <summary>
        /// Read only with object deletion
        /// </summary>
        ReadOnlyWithObjectDeletion = 2
    }
}
