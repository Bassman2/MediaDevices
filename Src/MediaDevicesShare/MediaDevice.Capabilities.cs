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

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.SupportedCommands(this.deviceCapabilities!));
    }

    public IEnumerable<MediaProperty> CommandOptions(Commands command)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.CommandOptions(this.deviceCapabilities!, command));
    }


    /// <summary>
    /// Retrieves all functional categories by the mediaDevice.
    /// </summary>
    /// <returns>List with functional categories</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<FunctionalCategory> FunctionalCategories()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.FunctionalCategories(this.deviceCapabilities!));
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

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.FunctionalObjects(this.deviceCapabilities!, functionalCategory));
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

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.SupportedContentTypes(this.deviceCapabilities!, functionalCategory));
    }

    public IEnumerable<ContentType> SupportedFormats(ContentType functionalCategory)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.SupportedFormats(this.deviceCapabilities!, functionalCategory));
    }

    public IEnumerable<string> SupportedFormatProperties(Formats format)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.SupportedFormatProperties(this.deviceCapabilities!, format));
    }

    //public IEnumerable<MediaProperty> FixedPropertyAttributes(Formats format, PropertyKey key)
    //{
    //    NotConnectedException.ThrowIfNotConnected(this);

    //    return mainWorker.InvokeEnumerable(() => ProtocolHandler.FixedPropertyAttributes(this.deviceCapabilities!, format, key));
    //}

    /// <summary>
    /// Retrieves all events supported by the mediaDevice.
    /// </summary>
    /// <returns>List with supported events</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<Events> SupportedEvents()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.SupportedEvents(this.deviceCapabilities!));
    }

    public IEnumerable<(string, string)> EventOptions(Events ev)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.EventOptions(this.deviceCapabilities!, ev));
    }

}
