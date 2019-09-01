using System;
using System.Runtime.Serialization;

namespace MediaDevices
{
    /// <summary>
    /// Represent error that occur if portable device is not connected.
    /// </summary>
    [SerializableAttribute]
    public class NotConnectedException : Exception, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the PortableDevices.NotConnectedException class.
        /// </summary>
        public NotConnectedException()
        { }

        /// <summary>
        /// Initializes a new instance of the PortableDevices.NotConnectedException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public NotConnectedException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the PortableDevices.NotConnectedException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public NotConnectedException(string message, Exception innerException) 
            : base(message, innerException)
        { }
    }
}
