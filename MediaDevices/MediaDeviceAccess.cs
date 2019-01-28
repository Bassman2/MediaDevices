namespace MediaDevices
{
    public enum MediaDeviceAccess : uint
    {
        Read = 0x80000000,  // GENERIC_READ
        Write = 0x40000000, // GENERIC_WRITE
        ReadWrite = Read | Write,
        All = 0x10000000, // GENERIC_ALL
    }
}
