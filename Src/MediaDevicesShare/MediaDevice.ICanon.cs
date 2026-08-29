namespace MediaDevices;

// Explicit Interface Implementation
partial class MediaDevice : ICanonMediaDevice
{
    IEnumerable<OpCodesCanon> ICanonMediaDevice.VendorOpcodes()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.VendorOpcodes<OpCodesCanon>(this.device!));
    }

    void ICanonMediaDevice.Capture()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        //mainWorker.Invoke(() => ProtocolHandler.Capture(this.device!));
    }

    int? ICanonMediaDevice.ShootingMode
    {
        get => GetDevicePropertyInt(WPD.CanonDevicePropertyShootingMode);
        set => SetDeviceProperty(WPD.CanonDevicePropertyShootingMode, value);
    }


    string? ICanonMediaDevice.OwnerName
    {
        get => GetDevicePropertyString(WPD.CanonDevicePropertyOwnerName);
        set => SetDeviceProperty(WPD.CanonDevicePropertyOwnerName, value);
    }

    string? ICanonMediaDevice.ArtistAuthor
    {
        get => GetDevicePropertyString(WPD.CanonDevicePropertyArtistAuthor);
        set => SetDeviceProperty(WPD.CanonDevicePropertyArtistAuthor, value);
    }


    string? ICanonMediaDevice.Copyright
    {
        get => GetDevicePropertyString(WPD.CanonDevicePropertyCopyright);
        set => SetDeviceProperty(WPD.CanonDevicePropertyCopyright, value);
    }

    string? ICanonMediaDevice.Serial
    {
        get => GetDevicePropertyString(WPD.CanonDevicePropertySerial);
        set => SetDeviceProperty(WPD.CanonDevicePropertySerial, value);
    }


    #region Commands

    void ICanonMediaDevice.TakePicture()
    {
        mainWorker.Invoke(() => ProtocolHandler.CanonTakePicture(this));
    }

    async Task ICanonMediaDevice.TakePictureAsync(CancellationToken cancellationToken)
    {
        await mainWorker.InvokeAsync(() => ProtocolHandler.CanonTakePicture(this), cancellationToken);
    }

    void ICanonMediaDevice.TakePictureAndDownload(string destination)
    {
        var ready = new AutoResetEvent(false);

        Directory.CreateDirectory(destination);

        ObjectAdded += (sender, e) =>
        {
            string extension = Path.GetExtension(e.ObjectName!).ToLower();

            // ignore temp files
            if (extension == ".tmp" || string.IsNullOrEmpty(extension))
            {
                return;
            }

            string destinationPath = Path.Combine(destination, e.ObjectName!);
            this.DownloadFile(e.ObjectFullFileName, destinationPath);
            ready.Set();

        };

        mainWorker.Invoke(() => ProtocolHandler.CanonTakePicture(this));

        ready.WaitOne();
    }



    Task ICanonMediaDevice.TakePictureAndDownloadAsync(string destination, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            return Task.FromCanceled(cancellationToken);
        }

        var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        // Register cancellation so the returned task will be cancelled if the token is triggered
        var ctr = cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken));

        Directory.CreateDirectory(destination);

        ObjectAdded += (sender, e) =>
        {
            string extension = Path.GetExtension(e.ObjectName!).ToLower();

            // ignore temp files
            if (extension == ".tmp" || string.IsNullOrEmpty(extension))
            {
                return;
            }

            string destinationPath = Path.Combine(destination, e.ObjectName!);
            this.DownloadFile(e.ObjectFullFileName, destinationPath);
            tcs.SetResult();

        };

        mainWorker.Invoke(() => ProtocolHandler.CanonTakePicture(this));

        return tcs.Task;
    }

    #endregion

}