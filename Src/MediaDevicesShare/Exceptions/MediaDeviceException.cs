namespace MediaDevices;

/// <summary>
/// Represents errors that occur when interacting with media devices and COM components.
/// </summary>
/// <param name="message">The error message that explains the reason for the exception.</param>
public class MediaDeviceException(string message) : Exception(message)
{
    ///// <summary>
    ///// Throws a <see cref="MediaDeviceException"/> when a COM call returns a failure HRESULT.
    ///// </summary>
    ///// <param name="errorCode">The HRESULT returned by the COM call.</param>
    ///// <param name="interf">The COM interface or component where the error occurred.</param>
    ///// <exception cref="MediaDeviceException">Thrown when <paramref name="errorCode"/> is a failure (negative) value.</exception>
    //public static void ThrowIfComError(
    //    int errorCode, 
    //    string interf,
    //    [CallerLineNumber] int lineNumber = 0,
    //    [CallerMemberName] string memberName = "",
    //    [CallerFilePath] string filePath = "")
    //{
    //    if (errorCode < 0)
    //    {
    //        string errorMessage = Marshal.GetExceptionForHR(errorCode)?.Message ?? "unknown error";
    //        string errorPosition = $"{filePath} ({lineNumber}) {memberName}";
    //        string message = $"COM Error 0x{errorCode:x8} in CoCreateInstance {interf}: {errorMessage} at {errorPosition}";
    //        Debug.WriteLine(message);
    //        Throw(message);
    //    }
    //}

    /// <summary>
    /// Throws a <see cref="MediaDeviceException"/> when a COM call returns a failure HRESULT.
    /// </summary>
    /// <param name="errorCode">The HRESULT returned by the COM call.</param>
    /// <param name="interf">The COM interface or component where the error occurred.</param>
    /// <param name="function">The function or method that reported the error.</param>
    /// <exception cref="MediaDeviceException">Thrown when <paramref name="errorCode"/> is a failure (negative) value.</exception>
    public static void ThrowIfComError(
        int errorCode, 
        string interf, 
        string function,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "")
    {
        if (errorCode < 0)
        {
            string errorMessage = Marshal.GetExceptionForHR(errorCode)?.Message ?? "unknown error";
            string errorPosition = $"{filePath} ({lineNumber}) {memberName}";
            string message = $"COM Error 0x{errorCode:x8} in {interf}.{function}: {errorMessage} at {errorPosition}";
            Debug.WriteLine(message);
            Throw(message);
        }
    }

    /// <summary>
    /// Throws a <see cref="MediaDeviceException"/> when a COM call returns a failure HRESULT.
    /// </summary>
    /// <param name="errorCode">The HRESULT returned by the COM call.</param>
    /// <param name="interf">The COM interface or component where the error occurred.</param>
    /// <param name="function">The function or method that reported the error.</param>
    /// <param name="parameter">An optional parameter or context value related to the failing call.</param>
    /// <exception cref="MediaDeviceException">Thrown when <paramref name="errorCode"/> is a failure (negative) value.</exception>
    public static void ThrowIfComError(
        int errorCode, 
        string interf, 
        string function, 
        string parameter,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "")
    {
        if (errorCode < 0)
        {
            string errorMessage = Marshal.GetExceptionForHR(errorCode)?.Message ?? "unknown error";
            string errorPosition = $"{filePath} ({lineNumber}) {memberName}";
            string message = $"COM Error 0x{errorCode:x8} in {interf}.{function} with {parameter}: {errorMessage} at {errorPosition}";
            Debug.WriteLine(message);
            Throw(message);
        }
    }

    internal static void ThrowIfComError(
        int errorCode,
        string interf,
        string function,
        Item item,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string filePath = "")
    {
        if (errorCode < 0)
        {
            string errorMessage = Marshal.GetExceptionForHR(errorCode)?.Message ?? "unknown error";
            string errorPosition = $"{filePath} ({lineNumber}) {memberName}";
            string message = $"COM Error 0x{errorCode:x8} in {interf}.{function} for {item.FullName}: {errorMessage} at {errorPosition}";
            Debug.WriteLine(message);
            Throw(message);
        }
    }

    [DoesNotReturn]
    private static void Throw(string message) =>
        throw new MediaDeviceException(message);
}
