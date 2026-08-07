using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace MediaDevices.Internal;

internal sealed class EventThreadHandler : IDisposable
{
    private readonly Thread thread;
    private readonly BlockingCollection<MediaDeviceEventArgs> queue = new();

    //private volatile bool _isRunning = true;
    private volatile bool disposed = false;

    public EventThreadHandler()
    {
        thread = new Thread(ProcessEventQueue) { Name = "MediaDeviceEventThread", IsBackground = true, Priority = ThreadPriority.Normal};
        thread.Start();
    }

    public void Dispose()
    {
        if (disposed)
        {
            return;
        }

        disposed = true;
        
        try
        {
            if (!thread.Join(5000))
            {
                Debug.WriteLine("Event thread did not terminate gracefully within timeout.");
            }
        }
        finally
        {
            queue?.Dispose();
        }
    }

    /// <summary>
    /// Enqueues an event action to be invoked on the event thread.
    /// </summary>
    /// <param name="eventAction">The event action to invoke.</param>
    public void Invoke(MediaDeviceEventArgs eventArgs)
    {
        if (disposed)
        {
            throw new ObjectDisposedException(nameof(EventThreadHandler));
        }

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
            //try { action(); }
            //catch (Exception ex) { Debug.WriteLine(ex); }
        }
    }
}
