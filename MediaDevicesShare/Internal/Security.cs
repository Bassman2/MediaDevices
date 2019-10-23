namespace MediaDevices.Internal
{
    internal enum SecurityImpersonationLevel : uint
    {
        Anonymous,
        Identification,
        Impersonation,
        Delegation
    }

    internal enum Security : uint
    {
        ANONYMOUS = (SecurityImpersonationLevel.Anonymous << 16),
        IDENTIFICATION = (SecurityImpersonationLevel.Identification << 16),
        IMPERSONATION = (SecurityImpersonationLevel.Impersonation << 16),
        DELEGATION = (SecurityImpersonationLevel.Delegation << 16),

        CONTEXT_TRACKING = 0x00040000,
        EFFECTIVE_ONLY = 0x00080000,

        SQOS_PRESENT = 0x00100000,
        VALID_SQOS_FLAGS = 0x001F0000,
    }
}
