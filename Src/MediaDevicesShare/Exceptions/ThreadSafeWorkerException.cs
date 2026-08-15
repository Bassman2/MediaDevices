namespace MediaDevices;

/// <summary>
/// Exception type used to indicate incorrect thread usage when interacting with <see cref="ThreadSafeWorker"/>.
/// Thrown when an operation is performed either from the wrong managed thread or with an incompatible
/// apartment state for operations that must run on the worker thread.
/// </summary>
/// <param name="message">Optional human-readable message describing the error.</param>
public class ThreadSafeWorkerException(string? message) : Exception(message)
{
    /// <summary>
    /// Validates that the caller is executing on the dedicated <see cref="ThreadSafeWorker.ThreadId"/> and that
    /// the current thread's apartment state is <see cref="ApartmentState.MTA"/>.
    /// </summary>
    /// <param name="lineNumber">The source line number of the caller (provided by the compiler).</param>
    /// <param name="filePath">The source file path of the caller (provided by the compiler).</param>
    /// <param name="memberName">The member name of the caller (provided by the compiler).</param>
    /// <exception cref="ThreadSafeWorkerException">
    /// Thrown when the current managed thread id does not match <see cref="ThreadSafeWorker.ThreadId"/>,
    /// or when the current thread's apartment state is not <see cref="ApartmentState.MTA"/>.
    /// </exception>
    internal static void ThrowIfNotInside(
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        if (Environment.CurrentManagedThreadId != ThreadSafeWorker.ThreadId)
        {
            string caller = Caller(lineNumber, filePath, memberName);
            throw new ThreadSafeWorkerException($"Wrong Thread! {caller}");
        }
        if (Thread.CurrentThread.GetApartmentState() != ApartmentState.MTA)
        {
            string caller = Caller(lineNumber, filePath, memberName);
            throw new ThreadSafeWorkerException($"Wrong Thread ApartmentState! {caller}");
        }
    }

    /// <summary>
    /// Validates that the caller is not executing on the dedicated <see cref="ThreadSafeWorker.ThreadId"/>.
    /// Use this to ensure code that must run off the worker thread does not accidentally run on it, which
    /// could cause deadlocks.
    /// </summary>
    /// <param name="lineNumber">The source line number of the caller (provided by the compiler).</param>
    /// <param name="filePath">The source file path of the caller (provided by the compiler).</param>
    /// <param name="memberName">The member name of the caller (provided by the compiler).</param>
    /// <exception cref="ThreadSafeWorkerException">
    /// Thrown when the current managed thread id equals <see cref="ThreadSafeWorker.ThreadId"/>, indicating
    /// the caller is running on the worker thread and may cause a deadlock if it waits for worker operations.
    /// </exception>
    internal static void ThrowIfNotOutside(
        [CallerLineNumber] int lineNumber = 0,
        [CallerFilePath] string filePath = "",
        [CallerMemberName] string memberName = "")
    {
        if (Environment.CurrentManagedThreadId == ThreadSafeWorker.ThreadId)
        {
            string caller = Caller(lineNumber, filePath, memberName);
            throw new ThreadSafeWorkerException($"Already in Wrong Thread. Deadlock will occure! {caller}");
        }
    }

    /// <summary>
    /// Builds a concise caller location string containing file path, line number and member name.
    /// Used to produce clearer exception messages from the validation helpers.
    /// </summary>
    /// <param name="lineNumber">The source line number of the caller.</param>
    /// <param name="filePath">The source file path of the caller.</param>
    /// <param name="memberName">The member name of the caller.</param>
    /// <returns>A single-line string describing the caller location.</returns>
    private static string Caller(int lineNumber, string filePath, string memberName) => $"{filePath} ({lineNumber}) {memberName}";
}
