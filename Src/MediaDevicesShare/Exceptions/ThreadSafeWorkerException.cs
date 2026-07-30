namespace MediaDevices;

public class ThreadSafeWorkerException(string? message) : Exception(message)
{
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

    private static string Caller(int lineNumber, string filePath, string memberName) => $"{filePath} ({lineNumber}) {memberName}";
}
