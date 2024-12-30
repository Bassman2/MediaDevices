namespace MediaDevices;

/// <summary>
/// 
/// </summary>
public class STAThreadNotRunningException : Exception, ISerializable
{
    /// <summary>
    /// 
    /// </summary>
    public STAThreadNotRunningException() 
        : base("STA Thread Not Running")
    { }

    /// <summary>
    /// Initializes a new instance of the PortableDevices.NotConnectedException class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public STAThreadNotRunningException(string message)
        : base(message)
    { }

    /// <summary>
    /// Initializes a new instance of the PortableDevices.NotConnectedException class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public STAThreadNotRunningException(string message, Exception innerException)
        : base(message, innerException)
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isRunning"></param>
    public static void ThrowIfNotRunning(bool isRunning)
    {
        if (!isRunning)
        {
            Throw();
        }
    }

    private static void Throw() =>
        throw new STAThreadNotRunningException();
}
