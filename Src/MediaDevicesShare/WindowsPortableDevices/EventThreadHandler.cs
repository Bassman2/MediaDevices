using System.Collections.Concurrent;

namespace MediaDevices.WindowsPortableDevices;

internal sealed class EventThreadHandler : IDisposable
{
    private readonly Thread thread;
    private readonly BlockingCollection<MediaDeviceEventArgs> queue = [];
    private readonly MediaDevice mediaDevice;
    private volatile bool disposed = false;

    public int ThreadId { get; private set; } = 0;

    public EventThreadHandler(MediaDevice mediaDevice)
    {
        this.mediaDevice = mediaDevice;
        thread = new Thread(ProcessEventQueue) { Name = "MediaDeviceEventThread", IsBackground = true, Priority = ThreadPriority.Normal};
        ThreadId = thread.ManagedThreadId;
        thread.Start();
    }

    public void Dispose()
    {
        if (disposed) return;
        disposed = true;

        queue.CompleteAdding();
        thread.Join(5000);
        queue.Dispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Enqueues an event action to be invoked on the event thread.
    /// </summary>
    /// <param name="eventArgs">The event action to invoke.</param>
    public void Invoke(MediaDeviceEventArgs eventArgs)
    {
        ObjectDisposedException.ThrowIf(disposed, this);

        try
        {
            queue.Add(eventArgs);
        }
        catch (OperationCanceledException)
        {
            Debug.WriteLine("Event queue was cancelled while enqueuing event.");
        }
    }

    private void ProcessEventQueue()
    {
        foreach (var eventArgs in queue.GetConsumingEnumerable())
        {
            try { mediaDevice.InvokeEvent(eventArgs); }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }
    }
}
