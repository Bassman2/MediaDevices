namespace MediaDevices;

public class ArgumentPathException(string paramName) : ArgumentException("Invalide path", paramName)
{
    public static void ThrowIfNullOrNotPath(string? path, [CallerArgumentExpression(nameof(path))] string? paramName = null)
    {
        if (!IsPath(path))
        {
            Throw(paramName);
        }
    }

    private static bool IsPath(string? path)
    {
        return !string.IsNullOrWhiteSpace(path) && path.IndexOfAny(Path.GetInvalidPathChars()) < 0;
    }

    [DoesNotReturn]
    internal static void Throw(string? paramName) =>
        throw new ArgumentPathException(paramName ?? "");
}
