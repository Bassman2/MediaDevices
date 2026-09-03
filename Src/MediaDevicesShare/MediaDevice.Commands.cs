namespace MediaDevices;

partial class MediaDevice
{
    /// <summary>
    /// Reset mediaDevice
    /// </summary>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    /// <exception cref="NotSupportedException">not supported by mediaDevice.</exception>
    public void ResetDevice()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        worker.Invoke(() => device.ResetDevice());
    }

    /// <summary>
    /// Get content locations
    /// </summary>
    /// <param name="contentType">Content type to find the locations for.</param>
    /// <returns>List with the location paths.</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<string>? GetContentLocations(ContentType contentType)
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return worker.Invoke(() => device.GetContentLocations(contentType));
    }

    //public void Supported(string id)
    //{
    //    NotConnectedException.ThrowIfNotConnected(this);
    //    
    //    worker.Supported(this, id);
    //}

    /// <summary>
    /// Eject storage
    /// </summary>
    /// <param name="path">Path of storage to eject.</param>
    /// <returns>true is success and false if not supported.</returns>
    public bool Eject(string path)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));

        return worker.Invoke(() => device.Eject(device.PathToObjectId(path)));
    }
    
    /// <summary>
    /// FormatId storage
    /// </summary>
    /// <param name="path">Path of storage to format.</param>
    public void Format(string path)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNullOrEmpty(path, nameof(path));

        worker.Invoke(() => device.Format(device.PathToObjectId(path)));
    }

    /// <summary>
    /// Send a text SMS
    /// </summary>
    /// <param name="functionalObject">Functional object of the SMS</param>
    /// <param name="recipient">Recipient of the SMS</param>
    /// <param name="text">Text of the SMS</param>
    /// <returns>true is success; false if not</returns>
    /// <example>
    /// <code>
    /// var devices = MediaDevice.GetDevices();
    /// using (var mediaDevice = devices.First(d => d.FriendlyName == "My Cell Phone"))
    /// {
    ///     mediaDevice.Connect();
    ///     if (mediaDevice.FunctionalCategories().Any(c => c == FunctionalCategory.SMS))
    ///     {
    ///         // get list of available SIM cards
    ///         var objects = mediaDevice.FunctionalObjects(FunctionalCategory.SMS);
    ///         mediaDevice.SendTextSMS(objects.First());
    ///     }
    ///     mediaDevice.Disconnect();
    /// }
    /// </code>
    /// </example>
    public bool SendTextSMS(string functionalObject, string recipient, string text)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNullOrEmpty(functionalObject, nameof(functionalObject));
        ArgumentNullException.ThrowIfNullOrEmpty(recipient, nameof(recipient));
        ArgumentNullException.ThrowIfNullOrEmpty(text, nameof(text));

        return worker.Invoke(() => device.SendTextSMS(functionalObject, recipient, text));
    }

    /// <summary>
    /// Initiate a still image capturing
    /// </summary>
    /// <param name="functionalObject">Functional object of the camera</param>
    /// <returns>true is success; false if not</returns>
    /// <exception cref="System.ArgumentNullException">path is null or empty.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    /// <example>
    /// <code>
    /// var devices = MediaDevice.GetDevices();
    /// using (var mediaDevice = devices.First(d => d.FriendlyName == "My Cell Phone"))
    /// {
    ///     mediaDevice.Connect();
    ///     if (mediaDevice.FunctionalCategories().Any(c => c == FunctionalCategory.StillImageCapture))
    ///     {
    ///         // get list of available cameras (front, rear)
    ///         var objects = mediaDevice.FunctionalObjects(FunctionalCategory.StillImageCapture);
    ///         mediaDevice.StillImageCaptureInitiate(objects.First());
    ///         // ObjectAdded event call after image create
    ///     }
    ///     mediaDevice.Disconnect();
    /// }
    /// </code>
    /// </example>
    public bool StillImageCaptureInitiate(string functionalObject)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNullOrEmpty(functionalObject, nameof(functionalObject));

        return worker.Invoke(() => device.StillImageCaptureInitiate(functionalObject));
    }

    

    /// <summary>
    /// Get storage informations
    /// </summary>
    /// <param name="storageObjectId">ID of the storage object</param>
    /// <returns>MediaStorageInfo class with storage informations</returns>
    /// <exception cref="System.ArgumentNullException">path is null or empty.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    /// <example>
    /// <code>
    /// var devices = MediaDevice.GetDevices();
    /// using (var mediaDevice = devices.First(d => d.FriendlyName == "My Cell Phone"))
    /// {
    ///     mediaDevice.Connect();
    ///     
    ///     // get list of available storages (SD-Card, Internal Flash, ...)
    ///     var objects = mediaDevice.FunctionalObjects(FunctionalCategory.Storage);
    ///     MediaStorageInfo info = GetStorageInfo(objects.First());
    ///     ulong size = info.FreeSpaceInBytes;
    ///     
    ///     mediaDevice.Disconnect();
    /// }
    /// </code>
    /// </example>
    public MediaStorageInfo? GetStorageInfo(string storageObjectId)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        ArgumentNullException.ThrowIfNullOrEmpty(storageObjectId, nameof(storageObjectId));

        return worker.Invoke(() => device.GetStorageInfo(storageObjectId));
    }
}
