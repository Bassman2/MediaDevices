namespace MediaDevices;

partial class MediaDevice
{
    /// <summary>
    /// Retrieves all commands supported by the mediaDevice.
    /// </summary>
    /// <returns>List with supported commands</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<Commands> SupportedCommands()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.SupportedCommands());
    }

    /// <summary>
    /// Retrieves all options and properties supported for a specific command.
    /// </summary>
    /// <param name="command">The command to retrieve options for</param>
    /// <returns>Enumerable collection of media properties supported for the command</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<MediaProperty> CommandOptions(Commands command)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.CommandOptions(command));
    }


    /// <summary>
    /// Retrieves all functional categories by the mediaDevice.
    /// </summary>
    /// <returns>List with functional categories</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<FunctionalCategory> FunctionalCategories()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.FunctionalCategories(this.deviceCapabilities!));
    }

    /// <summary>
    /// Retrieves all functional objects of a functional category by the mediaDevice.
    /// </summary>
    /// <param name="functionalCategory">Select functional category</param>
    /// <returns>List with functional objects</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<string> FunctionalObjects(FunctionalCategory functionalCategory)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.FunctionalObjects(functionalCategory));
    }

    /// <summary>
    /// Get supported content types
    /// </summary>
    /// <param name="functionalCategory">Select functional category</param>
    /// <returns>List with supported content types </returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<ContentType> SupportedContentTypes(FunctionalCategory functionalCategory)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.SupportedContentTypes(functionalCategory));
    }

    /// <summary>
    /// Retrieves all supported formats for the specified content type.
    /// </summary>
    /// <param name="functionalCategory">The content type to query supported formats for.</param>
    /// <returns>An enumerable collection of supported <see cref="Formats"/>.</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<Formats> SupportedFormats(ContentType functionalCategory)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.SupportedFormats(functionalCategory));
    }

    /// <summary>
    /// Retrieves all supported format properties for the specified format.
    /// </summary>
    /// <param name="format">The format to retrieve supported properties for.</param>
    /// <returns>An enumerable collection of supported format property names.</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<string> SupportedFormatProperties(Formats format)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.SupportedFormatProperties(format));
    }

    //public IEnumerable<MediaProperty> FixedPropertyAttributes(Formats format, PropertyKey key)
    //{
    //    NotConnectedException.ThrowIfNotConnected(this);

    //    return worker.InvokeEnumerable(() => device.FixedPropertyAttributes(this.deviceCapabilities!, format, key));
    //}

    /// <summary>
    /// Retrieves all events supported by the mediaDevice.
    /// </summary>
    /// <returns>List with supported events</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<Events> SupportedEvents()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.SupportedEvents());
    }

    /// <summary>
    /// Retrieves all options available for the specified event.
    /// </summary>
    /// <param name="ev">The event to query options for.</param>
    /// <returns>
    /// An enumerable of string pairs representing event option name and option value.
    /// The tuple's Item1 is the option name and Item2 is the option value.
    /// </returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<(string, string)> EventOptions(Events ev)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.InvokeEnumerable(() => device.EventOptions(ev));
    }

}
