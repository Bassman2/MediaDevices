namespace MediaDevices.Internal;

internal sealed class StreamWrapper : Stream
{
    private readonly IStream stream;
    private readonly ulong size;
    private readonly object obj;

    public StreamWrapper(IStream stream, ulong size = 0)
    {
        this.stream = stream ?? throw new ArgumentNullException(nameof(stream));
        this.size = size;
        this.obj = new();
    }

    public StreamWrapper(object obj, ulong size = 0)
    {
        this.obj = obj;
        this.stream = (IStream)obj;
        this.size = size;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            //Marshal.Release(stream);
            //try
            //{
            //    ComObject comObject = (ComObject)obj;
            //    comObject.FinalRelease();

            //    //stream.Finalize;
            //    //int err = Marshal.FinalReleaseComObject(obj);

            //    //if (Marshal.IsComObject(obj))
            //    //{
                    
            //    //    //try
            //    //    //{
            //    //    //    // Release all RCW references for the COM stream
            //    //    //    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(this.stream);
            //    //    //}
            //    //    //catch (Exception ex)
            //    //    //{
            //    //    //    Debug.WriteLine($"Exception while releasing COM IStream: {ex}");
            //    //    //}
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine($"Unexpected error in Dispose: {ex}");
            //}
        }

        base.Dispose(disposing);

    }

    private void CheckDisposed()
    {
        ObjectDisposedException.ThrowIf(this.stream == null, this);
        //{
        //    throw new ObjectDisposedException("StreamWrapper");
        //}
    }

    // old code
    // Marshal.ReleaseComObject(this.stream);

    //object obj = stream;
    //int err = Marshal.ReleaseComObject(obj);
    ////int err = Marshal.FinalReleaseComObject(obj);
    //MediaDeviceException.ThrowIfComError(err, nameof(IStream), "ReleaseComObject");


    //StrategyBasedComWrappers.TryGetComInstance()
    //ComWrappers.TryGetComInstance
    //if (this.stream != null)
    //{
    // TODO Marshal.ReleaseComObject(stream);
    //    this.stream = null;
    //}

    //int err = Marshal.FinalReleaseComObject(this.stream);
    //if (Marshal.IsComObject(this.stream))
    //{
    //    Marshal.ReleaseComObject(this.stream);
    //}
    ////comObject = null;

    //Marshal.ReleaseComObject(stream);
    //if (this.pLength != IntPtr.Zero)
    //{
    //    Marshal.FreeHGlobal(this.pLength);
    //    this.pLength = IntPtr.Zero;
    //}

    public override bool CanRead => true;

    public override bool CanSeek => false;

    public override bool CanWrite => true;

    public override void Flush()
    {
        int err = this.stream.Commit(0);
        MediaDeviceException.ThrowIfComError(err, nameof(IStream), nameof(IStream.Commit));
    }
    
    
    public override long Length
    {
        get
        {
            CheckDisposed();
            return (long)this.size;
        }
    }

    public override long Position
    {
        get => Seek(0, SeekOrigin.Current);
        set => Seek(value, SeekOrigin.Begin);
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        CheckDisposed();

        if (offset < 0 || count < 0 || offset + count > buffer.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(offset));
        }

        byte[] localBuffer = buffer;

        if (offset > 0)
        {
            localBuffer = new byte[count];
        }


        int err = this.stream.Read(localBuffer, count, out var read);
        MediaDeviceException.ThrowIfComError(err, nameof(IStream), nameof(IStream.Read));

        //int bytesRead = Marshal.ReadInt32(this.pLength);

        if (offset > 0)
        {
            Array.Copy(localBuffer, 0, buffer, offset, (int)read);
        }

        return (int)read;
    }

    public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException("Seek not implemented");
        
    public override void SetLength(long value)
    {
        CheckDisposed();

        stream.SetSize(value);
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        CheckDisposed();

        if (offset < 0 || count < 0 || offset + count > buffer.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(offset));
        }

        byte[] localBuffer = buffer;

        if (offset > 0)
        {
            localBuffer = new byte[count];
            Array.Copy(buffer, offset, localBuffer, 0, count);
        }

        // workaround for Windows 10 Update 1703 problem 
        // https://social.msdn.microsoft.com/Forums/en-US/7f7a045d-9d9d-4ff4-b8e3-de2d7477a177/windows-10-update-1703-problem-with-wpd-and-mtp?forum=csharpgeneral
        
        int err = stream.Write(localBuffer, count, out var written); //this.pLength);
        MediaDeviceException.ThrowIfComError(err, nameof(IStream), nameof(IStream.Write));
    }
}
