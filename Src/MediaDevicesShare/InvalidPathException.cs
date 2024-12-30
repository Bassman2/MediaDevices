namespace MediaDevices;

/// <summary>
/// 
/// </summary>
public class InvalidPathException : Exception, ISerializable
{
    /// <summary>
    /// 
    /// </summary>
    public InvalidPathException()
        : base("Invalid path")
    { }

    /// <summary>
    /// Initializes a new instance of the PortableDevices.NotConnectedException class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidPathException(string message)
        : base(message)
    { }

    /// <summary>
    /// Initializes a new instance of the PortableDevices.NotConnectedException class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
    public InvalidPathException(string message, Exception innerException)
        : base(message, innerException)
    { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    public static void ThrowIfPathIsInvalid(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || path.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
        {
            Throw();
        }
    }

    private static void Throw() =>
        throw new InvalidPathException();
}
