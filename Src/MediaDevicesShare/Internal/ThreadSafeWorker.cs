using System.Collections;
using System.Collections.Concurrent;

namespace MediaDevices.Internal;

internal sealed class ThreadSafeWorker : IDisposable
{
    private readonly Thread thread;
    private readonly BlockingCollection<Action> queue = [];
    private volatile bool disposed = false;

    public static int ThreadId { get; private set; } = 0;

    private const string exceptionInside = "Exception inside ThreadSafeWorker";
    public ThreadSafeWorker()
    {
        thread = new Thread(WorkLoop) { Name = "MediaDeviceWorkerThread", IsBackground = true };
        if (!thread.TrySetApartmentState(ApartmentState.MTA))
        {
            throw new InvalidOperationException("Failed to set MTA apartment state.");
        }
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

    private void WorkLoop()
    {
        Debug.WriteLine($"WorkLoop Apartment: {Thread.CurrentThread.GetApartmentState()}");
        foreach (var action in queue.GetConsumingEnumerable())
        {
            try { action(); }
            catch (Exception ex) { Debug.WriteLine(ex); }
        }
    }
    
    public void Invoke(
        Action action,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotOutside(lineNumber, filePath, memberName);
        ObjectDisposedException.ThrowIf(disposed, this);

        Exception? error = null;

        var ready = new AutoResetEvent(false);
        queue.Add(() =>
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                ready.Set();
            }
        });
        ready.WaitOne();
        if (error != null)
        {
            if (error is FileNotFoundException || 
                error is DirectoryNotFoundException || 
                error is UnauthorizedAccessException ||
                error is IOException ||
                error is NotSupportedException)
            {
                throw error;
            }
            else
            {
                throw new AggregateException(exceptionInside, error);
            }
        }
    }

    public T Invoke<T>(
        Func<T> func,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotOutside(lineNumber, filePath, memberName);
        ObjectDisposedException.ThrowIf(disposed, this);

        Exception? error = null;
        T? result = default;

        var ready = new AutoResetEvent(false);
        queue.Add(() =>
        {
            try
            {
                result = func();
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                ready.Set();
            }
        });
        ready.WaitOne();
        if (error != null)
        {
            if (error is FileNotFoundException || 
                error is DirectoryNotFoundException ||
                error is UnauthorizedAccessException ||
                error is IOException ||
                error is NotSupportedException)
            {
                throw error;
            }
            else
            {
                throw new AggregateException(exceptionInside, error);
            }
        }
        return result!;
    }
    
    #region Enumerable

    public IEnumerable<T> InvokeEnumerable<T>(
        Func<IEnumerable<T>> func,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotOutside(lineNumber, filePath, memberName);
        ObjectDisposedException.ThrowIf(disposed, this);

        return new WorkerEnumerable<T>(this, func);
    }

    private class WorkerEnumerable<T>(ThreadSafeWorker worker, Func<IEnumerable<T>> func) : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator() => new WorkerEnumerator<T>(worker, worker.Invoke(() => func().GetEnumerator()));

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private class WorkerEnumerator<T>(ThreadSafeWorker worker, IEnumerator<T> inner) : IEnumerator<T>
    {
        public void Dispose() => inner.Dispose();
        public T Current => inner.Current;
        object IEnumerator.Current => Current!;
        public void Reset() => inner.Reset();
        public bool MoveNext() => worker.Invoke(() => inner.MoveNext());
    }

    #endregion

    #region Async

    public Task InvokeAsync(
        Action action,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotOutside(lineNumber, filePath, memberName);
        ObjectDisposedException.ThrowIf(disposed, this);

        var tcs = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
        queue.Add(() =>
        {
            try
            {
                action();
                tcs.SetResult();
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        });
        return tcs.Task;
    }

    public Task<T> InvokeAsync<T>(
        Func<T> func,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotOutside(lineNumber, filePath, memberName);
        ObjectDisposedException.ThrowIf(disposed, this);

        var tcs = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
        queue.Add(() =>
        {
            try
            {
                var result = func();
                tcs.SetResult(result);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }
        });
        return tcs.Task;
    }


    #endregion

    #region AsyncEnumerable

    public IAsyncEnumerable<T> InvokeAsyncEnumerable<T>(
        Func<IAsyncEnumerable<T>> func,
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        ThreadSafeWorkerException.ThrowIfNotOutside(lineNumber, filePath, memberName);
        ObjectDisposedException.ThrowIf(disposed, this);

        return new WorkerAsyncEnumerable<T>(this, func);
    }

    private class WorkerAsyncEnumerable<T>(ThreadSafeWorker worker, Func<IAsyncEnumerable<T>> func) : IAsyncEnumerable<T>
    {
        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default) => new WorkerAsyncEnumerator<T>(worker, worker.Invoke(() => func().GetAsyncEnumerator(cancellationToken)));
    }

    private class WorkerAsyncEnumerator<T>(ThreadSafeWorker worker, IAsyncEnumerator<T> inner) : IAsyncEnumerator<T>
    {
        public ValueTask DisposeAsync() => inner.DisposeAsync();
        public T Current => inner.Current;
        public ValueTask<bool> MoveNextAsync() => worker.Invoke(() => inner.MoveNextAsync());
    }

    #endregion
}




