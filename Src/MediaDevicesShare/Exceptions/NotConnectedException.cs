namespace MediaDevices;

/// <summary>
/// Represent error that occur if portable mediaDevice is not connected.
/// </summary>
public class NotConnectedException(string? message) : Exception(message)
{
    internal static void ThrowIfNotConnected(MediaDevice mediaDevice)
    {
        if (!mediaDevice.IsConnected)
        {
            throw new NotConnectedException("Device is not connected.");
        }
    }
}
