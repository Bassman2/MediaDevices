namespace MediaDevices.Internal;

internal static class ErrorCodes
{
    public static string GetErrorMessage(int errorCode)
    {
        return errorCode switch
        {
            unchecked((int)0x80070005) => "Access is denied.",
            unchecked((int)0x80070057) => "The parameter is incorrect.",
            unchecked((int)0x8007000E) => "Not enough storage is available to complete this operation.",
            unchecked((int)0x80070032) => "The request is not supported.",
            unchecked((int)0x8007007A) => "The data area passed to a system call is too small.",
            unchecked((int)0x8007001F) => "A mediaDevice attached to the system is not functioning.",
            unchecked((int)0x80070002) => "The system cannot find the file specified.",
            _ => $"Unknown error code: 0x{errorCode:X8}",
        };
    }
}
