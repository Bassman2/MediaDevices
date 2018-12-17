using System;
using System.Collections.Generic;

namespace MediaDevices
{
    /// <summary>
    /// Enumerable helper class to catch exceptions during an enumeration
    /// </summary>
    public static class Enumerables
    {
        /// <summary>
        /// Catch exceptions during an enumeration.
        /// </summary>
        /// <typeparam name="T">Type of the enumeration.</typeparam>
        /// <param name="src">Source of the enumeration.</param>
        /// <param name="action">Action if an exception occurs.</param>
        /// <returns>Result enumeration. </returns>
        /// <example>
        /// <code>
        /// public void Work()
        /// {
        ///     var devices = MediaDevice.GetDevices();
        ///     using (var device = devices.First(d => d.FriendlyName == "My Cell Phone"))
        ///     {
        ///         device.Connect();
        ///     
        ///         var items = device.EnumerateFileSystemEntries("/").CatchExceptions(HandleException).ToList();
        ///     
        ///         device.Disconnect();
        ///     }
        /// }
        /// 
        /// private void HandleException(Exception ex)
        /// {
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static IEnumerable<T> CatchExceptions<T>(this IEnumerable<T> src, Action<Exception> action = null)
        {
            using (var enumerator = src.GetEnumerator())
            {
                bool next = true;
                while (next)
                {
                    try
                    {
                        next = enumerator.MoveNext();
                    }
                    catch (Exception ex)
                    {
                        if (action != null)
                        {
                            action(ex);
                        }
                        continue;
                    }

                    if (next)
                    {
                        yield return enumerator.Current;
                    }
                }
            }
        }
    }
}
