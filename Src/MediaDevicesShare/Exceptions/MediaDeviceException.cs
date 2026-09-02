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
    /// <param name="errorCode">The HRESULT returned by the COM call. A negative value indicates failure.</param>
    /// <param name="interf">The COM interface or component where the error occurred.</param>
    /// <param name="function">The function or method that reported the error.</param>
    /// <param name="lineNumber">The source line number of the caller (provided by the compiler).</param>
    /// <param name="memberName">The member name of the caller (provided by the compiler).</param>
    /// <param name="filePath">The source file path of the caller (provided by the compiler).</param>
    /// <remarks>
    /// When <paramref name="errorCode"/> is a failure (negative) value, this method:
    /// - Obtains a descriptive exception message from <see cref="Marshal.GetExceptionForHR(int)"/>.
    /// - Builds a diagnostic message that includes the HRESULT, interface, function, and caller location.
    /// - Writes the diagnostic message to the debug output and throws a <see cref="MediaDeviceException"/>.
    /// </remarks>
    /// <exception cref="MediaDeviceException">Thrown when <paramref name="errorCode"/> indicates a COM failure.</exception>
    internal static void ThrowIfComError(
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
    /// <param name="lineNumber">The source line number of the caller (provided by the compiler).</param>
    /// <param name="memberName">The member name of the caller (provided by the compiler).</param>
    /// <param name="filePath">The source file path of the caller (provided by the compiler).</param>
    /// <exception cref="MediaDeviceException">Thrown when <paramref name="errorCode"/> is a failure (negative) value.</exception>
    internal static void ThrowIfComError(
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
        WpdItem item,
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
