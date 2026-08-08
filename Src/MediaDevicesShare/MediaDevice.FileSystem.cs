namespace MediaDevices;

partial class MediaDevice       
{
    #region path based

    /// <summary>
    /// Returns an enumerable collection of directory names in a specified path.
    /// </summary>
    /// <param name="path">The directory to search.</param>
    /// <returns>An enumerable collection of directory names in the directory specified by path.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<string> EnumerateDirectories(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.EnumerateDirectories(this, path));
    }

    /// <summary>
    /// Returns an enumerable collection of directory information that matches a specified search pattern and search subdirectory option. 
    /// </summary>
    /// <param name="path">The directory to search in.</param>
    /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular expressions. The default pattern is "*", which returns all files.</param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.</param>
    /// <returns>An enumerable collection of directories that matches searchPattern and searchOption.</returns>
    /// <remarks>searchPattern can be a combination of literal and wildcard characters, but doesn't support regular expressions.</remarks>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.EnumerateDirectories(this, path, searchPattern, searchOption));
    }


    /// <summary>
    /// Returns an enumerable collection of file names in a specified path.
    /// </summary>
    /// <param name="path">The directory to search.</param>
    /// <returns>An enumerable collection of file names in the directory specified by path.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<string> EnumerateFiles(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.EnumerateFiles(this, path));
    }

    /// <summary>
    /// Returns an enumerable collection of file names that match a search pattern in a specified path, and optionally searches subdirectories.
    /// </summary>
    /// <param name="path">The absolute path to the directory to search. This string is case-sensitive.</param>
    /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but doesn't support regular expressions.</param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.</param>
    /// <returns>An enumerable collection of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.EnumerateFiles(this, path, searchPattern, searchOption));
    }

    /// <summary>
    /// Returns an enumerable collection of file-system entries in a specified path.
    /// </summary>
    /// <param name="path">The directory to search.</param>
    /// <returns>An enumerable collection of file-system entries in the directory specified by path.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<string> EnumerateFileSystemEntries(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.EnumerateFileSystemEntries(this, path));
    }

    /// <summary>
    /// Returns an enumerable collection of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
    /// </summary>
    /// <param name="path">The absolute path to the directory to search. This string is case-sensitive.</param>
    /// <param name="searchPattern">The search string to match against file-system entries in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but doesn't support regular expressions.</param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.</param>
    /// <returns>An enumerable collection of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public IEnumerable<string> EnumerateFileSystemEntries(string path, string? searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.EnumerateFileSystemEntries(this, path, searchPattern, searchOption));
    }

    /// <summary>
    /// Returns an array of directory names in a specified path.
    /// </summary>
    /// <param name="path">The directory to search.</param>
    /// <returns>An array of directory names in the directory specified by path.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string[] GetDirectories(string path) 
        => [.. EnumerateDirectories(path)];

    /// <summary>
    /// Returns an array of directory information that matches a specified search pattern and search subdirectory option. 
    /// </summary>
    /// <param name="path">The directory to search in.</param>
    /// <param name="searchPattern">The search string to match against the names of directories. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters (see Remarks), but doesn't support regular expressions. The default pattern is "*", which returns all files.</param>
    /// <param name="searchOption">One of the values that specifies whether the search operation should include only the current directory or all subdirectories. The default value is TopDirectoryOnly.</param>
    /// <returns>An array of directories that matches searchPattern and searchOption.</returns>
    /// <remarks>searchPattern can be a combination of literal and wildcard characters, but doesn't support regular expressions.</remarks>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        => [.. EnumerateDirectories(path, searchPattern, searchOption)];
    
    /// <summary>
    /// Returns an array of file names in a specified path.
    /// </summary>
    /// <param name="path">The directory to search.</param>
    /// <returns>An array of file names in the directory specified by path.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string[] GetFiles(string path)
        => [.. EnumerateFiles(path)];
    
    /// <summary>
    /// Returns an array of file names that match a search pattern in a specified path, and optionally searches subdirectories.
    /// </summary>
    /// <param name="path">The absolute path to the directory to search. This string is case-sensitive.</param>
    /// <param name="searchPattern">The search string to match against the names of files in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but doesn't support regular expressions.</param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.</param>
    /// <returns>An array of the full names (including paths) for the files in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string[] GetFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        => [.. EnumerateFiles(path, searchPattern, searchOption)];
    

    /// <summary>
    /// Returns an array of file-system entries in a specified path.
    /// </summary>
    /// <param name="path">The directory to search.</param>
    /// <returns>An array of file-system entries in the directory specified by path.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string[] GetFileSystemEntries(string path)
        => [.. EnumerateFileSystemEntries(path)];
    

    /// <summary>
    /// Returns an array of file names and directory names that match a search pattern in a specified path, and optionally searches subdirectories.
    /// </summary>
    /// <param name="path">The absolute path to the directory to search. This string is case-sensitive.</param>
    /// <param name="searchPattern">The search string to match against file-system entries in path. This parameter can contain a combination of valid literal path and wildcard (* and ?) characters, but doesn't support regular expressions.</param>
    /// <param name="searchOption">One of the enumeration values that specifies whether the search operation should include only the current directory or should include all subdirectories.</param>
    /// <returns>An array of file-system entries in the directory specified by path and that match the specified search pattern and option.</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        => [.. EnumerateFileSystemEntries(path, searchPattern, searchOption)];

    /// <summary>
    /// Determines whether the given path refers to an existing directory on disk.
    /// </summary>
    /// <param name="path">The path to test.</param>
    /// <returns>true if path refers to an existing directory; otherwise, false.</returns>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public bool DirectoryExists(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.Invoke(() => ProtocolHandler.DirectoryExists(this, path));
    }

    /// <summary>
    /// Creates all directories and subdirectories in the specified path.
    /// </summary>
    /// <param name="path">The directory path to create.</param>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void CreateDirectory(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.CreateDirectory(this, path));
    }

    /// <summary>
    /// Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
    /// </summary>
    /// <param name="path">The name of the directory to remove.</param>
    /// <param name="recursive">true to remove directories, subdirectories, and files in path; otherwise, false.</param>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void DeleteDirectory(string path, bool recursive = false)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.DeleteDirectory(this, path, recursive));
    }
    
    /// <summary>
    /// Determines whether the specified file exists.
    /// </summary>
    /// <param name="path">The file to check.</param>
    /// <returns>true if the  path contains the name of an existing file; otherwise, false.</returns>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public bool FileExists(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.Invoke(() => ProtocolHandler.FileExists(this, path));
    }

    /// <summary>
    /// Deletes the specified file.
    /// </summary>
    /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void DeleteFile(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.DeleteFile(this, path));
    }

    /// <summary>
    /// Rename a file or folder.
    /// </summary>
    /// <param name="path">Path to the file or folder to rename.</param>
    /// <param name="newName">New name of the file or folder.</param>
    public void Rename(string path, string newName)
    {
        NotConnectedException.ThrowIfNotConnected(this);
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        FileSystemPathCheck.ThrowIfInvalidPath(newName, nameof(newName));

        mainWorker.Invoke(() => ProtocolHandler.Rename(this, path, newName));
    }

    #endregion

    #region Download and Upload path based

    /// <summary>
    /// Download data from a file on a portable mediaDevice to a stream.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="stream">The stream to download to.</param>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void DownloadFile(string source, Stream stream)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.DownloadFile(this, source, stream));
    }

    public void DownloadFile(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.DownloadFile(this, source, destination));
    }

    /// <summary>
    /// Download icon from a file on a portable mediaDevice to a stream.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="stream">The stream to download to.</param>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void DownloadIcon(string source, Stream stream)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.DownloadIcon(this, source, stream));
    }

    public void DownloadIcon(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.DownloadIcon(this, source, destination));
    }

    /// <summary>
    /// Download thumbnail from a file on a portable mediaDevice to a stream.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <param name="stream">The stream to download to.</param>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void DownloadThumbnail(string source, Stream stream)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        ArgumentNullException.ThrowIfNull(stream);
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.DownloadThumbnail(this, source, stream));
    }

    public void DownloadThumbnail(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.DownloadThumbnail(this, source, destination));
    }

    public void DownloadFolder(string source, string destination, bool recursive = true, bool ignoreExceptions = true)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source);
        FileSystemPathCheck.ThrowIfInvalidPath(destination);
        NotConnectedException.ThrowIfNotConnected(this);
                
        mainWorker.Invoke(() => ProtocolHandler.DownloadFolder(this, source, destination, recursive, ignoreExceptions));
    }


    /// <summary>
    /// Upload data from a stream to a file on a portable mediaDevice.
    /// </summary>
    /// <param name="stream">The stream to upload from.</param>
    /// <param name="destination">The path to the file.</param>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void UploadFile(Stream stream, string destination)
    {
        ArgumentNullException.ThrowIfNull(stream, nameof(stream));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.UploadFile(this, stream, destination));
    }

    public void UploadFile(string source, string destination)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.UploadFile(this, source, destination));
    }

    public void UploadFolder(string source, string destination, bool recursive = true, bool ignoreExceptions = true)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(source, nameof(source));
        FileSystemPathCheck.ThrowIfInvalidPath(destination, nameof(destination));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.UploadFolder(this, source, destination, recursive, ignoreExceptions));
    }


    #endregion

        #region MediaFileInfo, MediaDirectoryInfo, MediaDriveInfo and MediaFileSystemInfo based 

        /// <summary>
        /// Gets a new instance of the MediaFileInfo class, which acts as a wrapper for a file path.
        /// </summary>
        /// <param name="path">The fully qualified name of the file, directory or object.</param>
        /// <returns>New instance of the MediaFileInfo class</returns>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public MediaFileInfo GetFileInfo(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

         return mainWorker.Invoke(() => ProtocolHandler.GetFileInfo(this, path));
    }

    /// <summary>
    /// Gets a new instance of the MediaDirectoryInfo class, which acts as a wrapper for a directory path.
    /// </summary>
    /// <param name="path">The fully qualified name of the directory or object.</param>
    /// <returns>New instance of the MediaDirectoryInfo class</returns>
    /// <exception cref="System.IO.IOException">path is a file name.</exception>
    /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
    /// <exception cref="System.ArgumentNullException">path is null.</exception>
    /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public MediaDirectoryInfo GetDirectoryInfo(string path)
    {
        FileSystemPathCheck.ThrowIfInvalidPath(path, nameof(path));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.Invoke(() => ProtocolHandler.GetDirectoryInfo(this, path));
    }

    /// <summary>
    /// Get all drives of the mediaDevice.
    /// </summary>
    /// <returns>Array with all drives of the mediaDevice.</returns>
    public IEnumerable<MediaDriveInfo> GetDrives()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.InvokeEnumerable(() => ProtocolHandler.GetDrives(this));
    }

    /// <summary>
    /// Gets a new instance of the root MediaDirectoryInfo class, which acts as a wrapper for the root directory path.
    /// </summary>
    /// <returns>New instance of the root MediaDirectoryInfo class</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public MediaDirectoryInfo GetRootDirectory()
    {
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.Invoke(() => ProtocolHandler.GetRootDirectory(this));
    }

    #endregion

    #region PersistentUniqueId

    public string GetPathFromPersistentUniqueId(string persistentUniqueId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.Invoke(() => ProtocolHandler.GetPathFromPersistentUniqueId(this, persistentUniqueId));
    }

    /// <summary>
    /// Create a <see cref="MediaFileSystemInfo"/> instance from the Persistent Unique Id.
    /// </summary>
    /// <param name="persistentUniqueId">Persistent Unique Id of the file or folder.</param>
    /// <returns>New instance of the <see cref="MediaFileInfo"/> or <see cref="MediaDirectoryInfo"/> class.</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    /// <exception cref="System.ArgumentNullException">persistentUniqueId is null or empty.</exception>
    /// <exception cref="System.IO.FileNotFoundException">persistentUniqueId not found.</exception>
    public MediaFileSystemInfo GetFileSystemInfoFromPersistentUniqueId(string persistentUniqueId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.Invoke(() => ProtocolHandler.GetFileSystemInfoFromPersistentUniqueId(this, persistentUniqueId));
    }

    /// <summary>
    /// Download data from a file on a portable mediaDevice to a file identified by a Persistent Unique Id.
    /// </summary>
    /// <param name="persistentUniqueId">Persistent Unique Id of the file.</param>
    /// <param name="destination">The file to download to.</param>
    /// <exception cref="System.ArgumentNullException">persistentUniqueId is null or empty.</exception>
    /// <exception cref="System.ArgumentNullException">stream is null.</exception>
    /// <exception cref="System.IO.FileNotFoundException">persistentUniqueId not found.</exception>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    public void DownloadFileFromPersistentUniqueId(string persistentUniqueId, string destination)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        mainWorker.Invoke(() => ProtocolHandler.DownloadFileFromPersistentUniqueId(this, persistentUniqueId, destination));
    }

    /// <summary>
    /// Opens a files stream from an Persistent Unique ID to read from.
    /// </summary>
    /// <param name="persistentUniqueId">Persistent unique ID of the item.</param>
    /// <returns>A new read-only FileStream object.</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    /// <exception cref="System.ArgumentNullException">persistentUniqueId is null or empty.</exception>
    /// <exception cref="System.IO.FileNotFoundException">persistentUniqueId not found.</exception>
    public Stream OpenReadFromPersistentUniqueId(string persistentUniqueId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.Invoke(() => ProtocolHandler.OpenReadFromPersistentUniqueId(this, persistentUniqueId));
    }

    /// <summary>
    /// Opens a stream reader with UTF-8 encoding from an Persistent Unique ID to read from.
    /// </summary>
    /// <param name="persistentUniqueId">Persistent unique ID of the item.</param>
    /// <returns>A new StreamReader object.</returns>
    /// <exception cref="MediaDevices.NotConnectedException">mediaDevice is not connected.</exception>
    /// <exception cref="System.ArgumentNullException">persistentUniqueId is null or empty.</exception>
    /// <exception cref="System.IO.FileNotFoundException">persistentUniqueId not found.</exception>
    public StreamReader? OpenTextFromPersistentUniqueId(string persistentUniqueId)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(persistentUniqueId, nameof(persistentUniqueId));
        NotConnectedException.ThrowIfNotConnected(this);

        return mainWorker.Invoke(() => ProtocolHandler.OpenTextFromPersistentUniqueId(this, persistentUniqueId));
    }
    
    #endregion
}
