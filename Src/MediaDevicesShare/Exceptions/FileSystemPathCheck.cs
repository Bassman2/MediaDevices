namespace MediaDevices.Internal;

internal static class FileSystemPathCheck
{
    private const int maxPathLength = 255;

    public static void ThrowIfInvalidPath(string? path, [CallerArgumentExpression(nameof(path))] string? paramName = null)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(paramName);
        }

        var invalidChars = Path.GetInvalidPathChars();
        if (path.IndexOfAny(invalidChars) >= 0)
        {
            throw new ArgumentException($"{paramName} contains invalid path characters");
        }

        if (path.Length > maxPathLength)
        {
            throw new PathTooLongException($"{paramName} has more than {maxPathLength} characters");
        }
    }
}
