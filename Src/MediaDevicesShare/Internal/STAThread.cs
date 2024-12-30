namespace MediaDevices.Internal;

/// <summary>
/// 
/// </summary>
internal class STAThread : IDisposable
{
#if NET9_0_OR_GREATER
    private readonly Lock runLock = new();
#else
    private readonly object runLock = new object();
#endif
    private readonly Thread thread;
    private readonly AutoResetEvent startEvent = new AutoResetEvent(false);
    private readonly AutoResetEvent runEvent = new AutoResetEvent(false);
    private readonly AutoResetEvent waitEvent = new AutoResetEvent(false);
    private Action? runAction;
    private Exception? runException;

    /// <summary>
    /// 
    /// </summary>
    public STAThread()
    {
        this.thread = new Thread(() => Loop());
        this.thread.TrySetApartmentState(ApartmentState.STA);
        this.thread.Start();
        this.startEvent.WaitOne();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public virtual void Dispose()
    {
        Close();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// True if thread ist running, false if not.
    /// </summary>
    public bool IsRunning { get; private set; }

    /// <summary>
    /// Close STA thread.
    /// </summary>
    public void Close()
    {
        lock (runLock)
        {
            if (this.thread.ThreadState == System.Threading.ThreadState.Running && this.IsRunning)
            {
                this.IsRunning = false;
                runEvent.Set();
                this.thread.Join();
            }
        }
    }

    private int counter = 0;

    private void Loop()
    {
        this.IsRunning = true;
        this.startEvent.Set();
        while (this.IsRunning)
        {
            runEvent.WaitOne();

            if (this.IsRunning)
            {
                Debug.WriteLine($"Run {++counter} started.");
                try
                {
                    runAction?.Invoke();
                }
                catch (Exception e)
                {
                    runException = e;
                }
                waitEvent.Set();
            }
        }
    }

    private void RunIntern(Action action)
    {
        if (Environment.CurrentManagedThreadId == thread.ManagedThreadId)
        {
            throw new Exception("ERROR: Already in STA thread. Must be called from other thread.!!!");
        }

        Debug.WriteLine("++Run");

        lock (runLock)
        {
            runException = null;
            runAction = action;
            Debug.WriteLine("fire");
            runEvent.Set();

            waitEvent.WaitOne();
            Debug.WriteLine($"Run {counter} ready.");

            if (runException != null)
            {
                Debug.WriteLine(runException);
                throw runException;
            }
        }
        Debug.WriteLine("--Run");
    }

    /// <summary>
    /// Run action in STA thread
    /// </summary>
    /// <param name="action">Action to run in STA thread.</param>
    public void Run(Action action)
    {
        ArgumentNullException.ThrowIfNull(action, nameof(action));
        STAThreadNotRunningException.ThrowIfNotRunning(IsRunning);

        RunIntern(action);
    }

    /// <summary>
    /// Run function in STA thread
    /// </summary>
    /// <typeparam name="T">Return type of the function.</typeparam>
    /// <param name="func">Function to run in STA thread.</param>
    /// <returns>Return value of the function.</returns>
    public T? Run<T>(Func<T> func)
    {
        ArgumentNullException.ThrowIfNull(func, nameof(func));
        STAThreadNotRunningException.ThrowIfNotRunning(IsRunning);

        T? result = default;
        RunIntern(() => result = func());
        return result;
    }
}
