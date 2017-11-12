using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using PortableDeviceApiLib;
using PortableDeviceTypesLib;
using IPortableDeviceKeyCollection = PortableDeviceApiLib.IPortableDeviceKeyCollection;
using IPortableDeviceValues = PortableDeviceApiLib.IPortableDeviceValues;
using IPortableDevicePropVariantCollection = PortableDeviceApiLib.IPortableDevicePropVariantCollection;
using PropertyKey = PortableDeviceApiLib._tagpropertykey;
using PROPVARIANT = PortableDeviceApiLib.tag_inner_PROPVARIANT;
using MediaDevices.Internal;
using System.Text.RegularExpressions;
using System.Reflection;

namespace MediaDevices
{
    /// <summary>
    /// Represents a portable device.
    /// </summary>
    public sealed class MediaDevice : IDisposable
    {
        internal char DirectorySeparatorChar = '\\';

        private delegate void RefAction<T1, T2>(T1 arg1, ref T2 arg2);

        private const uint PORTABLE_DEVICE_DELETE_NO_RECURSION = 0;
        private const uint PORTABLE_DEVICE_DELETE_WITH_RECURSION = 1;

        //private const uint SMS_TEXT_MESSAGE = 0;
        //private const uint SMS_BINARY_MESSAGE = 1;


        #region Fields

        private PortableDeviceApiLib.PortableDevice device;
        internal IPortableDeviceContent deviceContent;
        private IPortableDeviceProperties deviceProperties;
        private IPortableDeviceCapabilities deviceCapabilities;
        private string friendlyName = string.Empty;
        private string eventCookie;
        private EventCallback eventCallback;
        private HResult lastError;

        #endregion

        #region events

        /// <summary>
        /// This event is sent after a new object is available on the device.
        /// </summary>
        public event EventHandler<MediaDeviceEventArgs> ObjectAdded;

        /// <summary>
        /// This event is sent after a previously existing object has been removed from the device.
        /// </summary>
        /// 
        public event EventHandler<MediaDeviceEventArgs> ObjectRemoved;

        /// <summary>
        /// This event is sent after an object has been updated such that any connected client should refresh its view of that object.
        /// </summary>
        public event EventHandler<MediaDeviceEventArgs> ObjectUpdated;

        /// <summary>
        /// This event indicates that the device is about to be reset, and all connected clients should close their connection to the device. 
        /// </summary>
        public event EventHandler<MediaDeviceEventArgs> DeviceReset;

        /// <summary>
        /// This event indicates that the device capabilities have changed. Clients should re-query the device if they have made any decisions based on device capabilities.
        /// </summary>
        public event EventHandler<MediaDeviceEventArgs> DeviceCapabilitiesUpdated;

        /// <summary>
        /// This event indicates the progress of a format operation on a storage object.
        /// </summary>
        public event EventHandler<MediaDeviceEventArgs> StorageFormat;

        /// <summary>
        /// This event is sent to request an application to transfer a particular object from the device.
        /// </summary>
        public event EventHandler<MediaDeviceEventArgs> ObjectTransferRequest;

        /// <summary>
        /// This event is sent when a driver for a device is being unloaded. This is typically a result of the device being unplugged.
        /// </summary>
        public event EventHandler<MediaDeviceEventArgs> DeviceRemoved;

        /// <summary>
        /// This event is sent when a driver has completed invoking a service method. This event must be sent even when the method fails.
        /// </summary>
        public event EventHandler<MediaDeviceEventArgs> ServiceMethodComplete;

        #endregion

        #region static

        private static readonly PortableDeviceManager portableDeviceManager = new PortableDeviceManager();

        /// <summary>
        /// Returns an enumerable collection of currently available portable devices.
        /// </summary>
        /// <returns>>An enumerable collection of portable devices currently available.</returns>
        public static IEnumerable<MediaDevice> GetDevices()
        {
            portableDeviceManager.RefreshDeviceList();

            // get number of devices
            uint count = 0;
            portableDeviceManager.GetDevices(null, ref count);

            if (count == 0)
            {
                return new List<MediaDevice>();
            }

            // get device IDs
            var deviceIds = new string[count];
            portableDeviceManager.GetDevices(deviceIds, ref count);

            return deviceIds.Select(d => new MediaDevice(d));
        }

        //public static IEnumerable<MediaDevice> GetDevices(FunctionalCategory category)
        //{
        //    if (category == FunctionalCategory.All)
        //    {
        //        return GetDevices();
        //    }

        //    var devices = GetDevices();

        //    var dev = devices.FirstOrDefault();

        //    dev.deviceCapabilities
        //}

        /// <summary>
        /// Returns an enumerable collection of currently available private portable devices.
        /// </summary>
        /// <returns>>An enumerable collection of private portable devices currently available.</returns>
        public static IEnumerable<MediaDevice> GetPrivateDevices()
        {
            portableDeviceManager.RefreshDeviceList();

            // get number of devices
            uint count = 0;
            portableDeviceManager.GetPrivateDevices(null, ref count);

            // get device IDs
            var deviceIds = new string[count];
            portableDeviceManager.GetPrivateDevices(deviceIds, ref count);

            return deviceIds.Select(d => new MediaDevice(d));
        }

        #endregion

        #region constructor

        private MediaDevice(string deviceId)
        {
            this.DeviceId = deviceId;

            char[] buffer = new char[260];
            uint count = 256;
            try
            {
                portableDeviceManager.GetDeviceDescription(deviceId, buffer, ref count);
                this.Description = new string(buffer, 0, (int)count - 1);
            }
            catch (COMException)
            {
                this.Description = string.Empty;
            }
            try
            {
                count = 256;
                portableDeviceManager.GetDeviceFriendlyName(deviceId, buffer, ref count);
                this.friendlyName = new string(buffer, 0, (int)count - 1);
            }
            catch (COMException)
            {
                this.friendlyName = string.Empty;
            }
            try
            {
                count = 256;
                portableDeviceManager.GetDeviceManufacturer(deviceId, buffer, ref count);
                this.Manufacturer = new string(buffer, 0, (int)count - 1);
            }
            catch (COMException)
            {
                this.Description = string.Empty;
            }

            this.device = new PortableDeviceApiLib.PortableDevice();

        }

        /// <summary>
        /// Releases the resources used by the PortableDevices.PortableDevice.
        /// </summary>
        public void Dispose()
        {
            Disconnect();
        }

        /// <summary>
        /// Overrides ToString for debug use.
        /// </summary>
        /// <returns>A string with the friendly name, the manufacture and the description.</returns>
        public override string ToString()
        {
            string friendlyName = String.Empty;
            string manufacturer = String.Empty;
            string description = String.Empty;
            try
            {
                friendlyName = this.FriendlyName;

            }
            catch { }
            try
            {
                manufacturer = this.Manufacturer;
            }
            catch { }
            try
            {
                description = this.Description;
            }
            catch { }
            return $"{friendlyName} - {manufacturer} - {description}";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Is portable device connected.
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// Device Id of the portable device.
        /// </summary>
        /// <remarks>Readable when not connected.</remarks>
        public string DeviceId { get; private set; }

        /// <summary>
        /// Description of the portable device.
        /// </summary>
        /// <remarks>Readable when not connected.</remarks>
        public string Description { get; private set; }

        /// <summary>
        /// Friendly name of the portable device.
        /// </summary>
        /// <remarks>Readable when not connected.</remarks>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected. only for setter</exception>
        public string FriendlyName
        {
            get { return IsConnected ? GetStringProperty(WPD.DEVICE_FRIENDLY_NAME) : this.friendlyName; }
            set { SetStringProperty(WPD.DEVICE_FRIENDLY_NAME, value); }
        }

        /// <summary>
        /// Manufacturer of the portable device.
        /// </summary>
        /// <remarks>Readable when not connected.</remarks>
        public string Manufacturer { get; private set; }

        /// <summary>
        /// Sync partner of the device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string SyncPartner
        {
            get { return GetStringProperty(WPD.DEVICE_SYNC_PARTNER); }
        }

        /// <summary>
        /// Firmware version of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string FirmwareVersion
        {
            get { return GetStringProperty(WPD.DEVICE_FIRMWARE_VERSION); }
        }

        /// <summary>
        /// Battery level of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public int PowerLevel
        {
            get { return GetIntegerProperty(WPD.DEVICE_POWER_LEVEL); }
        }

        /// <summary>
        /// Power source of the device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public PowerSource PowerSource
        {
            get { return (PowerSource)GetIntegerProperty(WPD.DEVICE_POWER_SOURCE); }
        }

        /// <summary>
        /// Protocol of the device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string Protocol
        {
            get { return GetStringProperty(WPD.DEVICE_PROTOCOL); }
        }

        /// <summary>
        /// Model of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string Model
        {
            get { return GetStringProperty(WPD.DEVICE_MODEL); }
        }

        /// <summary>
        /// Serial number of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string SerialNumber
        {
            get { return GetStringProperty(WPD.DEVICE_SERIAL_NUMBER); }
        }

        /// <summary>
        /// Supports non consumable.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public bool SupportsNonConsumable
        {
            get { return GetBoolProperty(WPD.DEVICE_SUPPORTS_NON_CONSUMABLE); }
        }

        ///// <summary>
        ///// Date and time of the media device.
        ///// </summary>
        ///// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        //public DateTime? DateTime
        //{
        //    get { return GetDateTimeProperty(WPD_DEVICE_DATETIME); }
        //}

        /// <summary>
        /// Supported formats are ordered.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public bool SupportedFormatsAreOrdered
        {
            get { return GetBoolProperty(WPD.DEVICE_SUPPORTED_FORMATS_ARE_ORDERED); }
        }

        /// <summary>
        /// Device type of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public DeviceType DeviceType
        {
            get { return (DeviceType)this.GetIntegerProperty(WPD.DEVICE_TYPE); }
        }

        ///// <summary>
        ///// EUI-64
        ///// </summary>
        ///// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        //public ulong NetworIdentifier
        //{
        //    get { return GetULongProperty(WPD_DEVICE_NETWORK_IDENTIFIER); }
        //}

        ///// <summary>
        ///// Functional unique id od the media device
        ///// </summary>
        ///// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        //public object FunctionalUniqueId
        //{
        //    get { return GetObjectProperty(WPD_DEVICE_FUNCTIONAL_UNIQUE_ID); }
        //}

        ///// <summary>
        ///// Model unique id od the media device
        ///// </summary>
        ///// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        //public object ModelUniqueId
        //{
        //    get { return GetObjectProperty(WPD_DEVICE_MODEL_UNIQUE_ID); }
        //}

        /// <summary>
        /// Device transport.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public DeviceTransport Transport
        {
            get { return (DeviceTransport)this.GetIntegerProperty(WPD.DEVICE_TRANSPORT); }
        }

        ///// <summary>
        ///// Use device stage
        ///// </summary>
        ///// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        //public DeviceTransport UseDeviceStage
        //{
        //    get { return (DeviceTransport)this.GetIntegerProperty(WPD_DEVICE_USE_DEVICE_STAGE); }
        //}

        /// <summary>
        /// PnP device ID
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string PnPDeviceID
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                string pnPDeviceID = string.Empty;
                this.device.GetPnPDeviceID(out pnPDeviceID);
                return pnPDeviceID;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Connect to the portable device.
        /// </summary>
        public void Connect()
        {
            if (this.IsConnected)
            {
                return;
            }

            var clientInfo = (IPortableDeviceValues)new PortableDeviceValues();
            this.device.Open(this.DeviceId, clientInfo);
            this.device.Capabilities(out this.deviceCapabilities);
            this.device.Content(out this.deviceContent);
            this.deviceContent.Properties(out this.deviceProperties);

            // advice event handler
            this.eventCallback = new EventCallback(this);
            this.device.Advise(0, this.eventCallback, null, out this.eventCookie);

            this.IsConnected = true;
        }

        /// <summary>
        /// Disconnect from the portable device.
        /// </summary>
        public void Disconnect()
        {
            if (!this.IsConnected)
            {
                return;
            }
            if (!string.IsNullOrEmpty(this.eventCookie))
            {
                this.device.Unadvise(this.eventCookie);
                this.eventCookie = null;
            }
            this.device.Close();
            this.IsConnected = false;
        }

        /// <summary>
        /// The Cancel method cancels a pending operation on this device. 
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void Cancel()
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            this.device.Cancel();
        }
        
        /// <summary>
        /// Get the last error
        /// </summary>
        /// <returns>Error code</returns>
        public HResult GetLastError()
        {
            return this.lastError;
        }

        /// <summary>
        /// Returns an enumerable collection of directory names in a specified path.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <returns>An enumerable collection of directory names in the directory specified by path.</returns>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<string> EnumerateDirectories(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = FindFolder(path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return GetChildren(item.Id).Where(i => i.Type != ItemType.File).Select(i => i.Name);
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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = FindFolder(path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return GetChildren(item.Id, searchPattern, searchOption).Where(i => i.Type != ItemType.File).Select(i => i.Name);
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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<string> EnumerateFiles(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = FindFolder(path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return GetChildren(item.Id).Where(i => i.Type == ItemType.File).Select(i => i.Name);
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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = FindFolder(path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return GetChildren(item.Id, searchPattern, searchOption).Where(i => i.Type == ItemType.File).Select(i => i.Name);
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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<string> EnumerateFileSystemEntries(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = FindFolder(path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return GetChildren(item.Id).Select(i => i.Name);
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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = FindFolder(path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return GetChildren(item.Id, searchPattern, searchOption).Select(i => i.Name);
        }

        /// <summary>
        /// Creates all directories and subdirectories in the specified path.
        /// </summary>
        /// <param name="path">The directory path to create.</param>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void CreateDirectory(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            CreateSubdirectory(path);
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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void DeleteDirectory(string path, bool recursive = false)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = FindFolder(path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }

            var objectIdCollection = (IPortableDevicePropVariantCollection)new PortableDeviceTypesLib.PortableDevicePropVariantCollection();

            var propVariantValue = PropVariant.StringToPropVariant(item.Id);
            objectIdCollection.Add(ref propVariantValue);

            // TODO: get the results back and handle failures correctly
            deviceContent.Delete(recursive ? PORTABLE_DEVICE_DELETE_WITH_RECURSION : PORTABLE_DEVICE_DELETE_NO_RECURSION, objectIdCollection, null);
        }

        /// <summary>
        /// Determines whether the given path refers to an existing directory on disk.
        /// </summary>
        /// <param name="path">The path to test.</param>
        /// <returns>true if path refers to an existing directory; otherwise, false.</returns>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public bool DirectoryExists(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            return FindFolder(path) != null;
        }

        /// <summary>
        /// Download data from a file on a portable device to a stream.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="stream">The stream to download to.</param>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void DownloadFile(string path, Stream stream)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = FindFile(path);
            if (item == null)
            {
                throw new FileNotFoundException($"File {path} not found.");
            }

            Download(item.Id, stream);
        }



        /// <summary>
        /// Upload data from a stream to a file on a portable device.
        /// </summary>
        /// <param name="stream">The stream to upload from.</param>
        /// <param name="path">The path to the file.</param>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void UploadFile(Stream stream, string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            string folder = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);
            Item item = FindFolder(folder);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Directory {folder} not found.");
            }

            if (GetChildren(item.Id).Any(i => i.Name == fileName))
            {
                throw new IOException($"File {path} already exists");
            }

            IPortableDeviceValues portableDeviceValues = new PortableDeviceValues() as IPortableDeviceValues;

            portableDeviceValues.SetStringValue(ref WPD.OBJECT_PARENT_ID, item.Id);
            portableDeviceValues.SetUnsignedLargeIntegerValue(ref WPD.OBJECT_SIZE, (ulong)stream.Length);
            portableDeviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, fileName);
            portableDeviceValues.SetStringValue(ref WPD.OBJECT_NAME, fileName);

            uint num = 0u;
            string text = null;
            PortableDeviceApiLib.IStream wpdStream;
            this.deviceContent.CreateObjectWithPropertiesAndData(portableDeviceValues, out wpdStream, ref num, ref text);

            using (StreamWrapper destinationStream = new StreamWrapper(wpdStream))
            {
                stream.CopyTo(destinationStream);
                destinationStream.Flush();
            }
        }

        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        /// <param name="path">The file to check.</param>
        /// <returns>true if the  path contains the name of an existing file; otherwise, false.</returns>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public bool FileExists(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            var objectId = FindFile(path);
            return objectId != null;
        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        /// <param name="path">The name of the file to be deleted. Wildcard characters are not supported.</param>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void DeleteFile(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = FindFile(path);
            if (item == null)
            {
                throw new FileNotFoundException($"File {path} not found.");
            }

            var objectIdCollection = (PortableDeviceApiLib.IPortableDevicePropVariantCollection)new PortableDeviceTypesLib.PortableDevicePropVariantCollection();

            var propVariantValue = PropVariant.StringToPropVariant(item.Id);
            objectIdCollection.Add(ref propVariantValue);

            // TODO: get the results back and handle failures correctly
            deviceContent.Delete(PORTABLE_DEVICE_DELETE_NO_RECURSION, objectIdCollection, null);
        }

        /// <summary>
        /// Gets a new instance of the MediaFileInfo class, which acts as a wrapper for a file path.
        /// </summary>
        /// <param name="path">The fully qualified name of the file, directory or object.</param>
        /// <returns>New instance of the MediaFileInfo class</returns>
        public MediaFileInfo GetFileInfo(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            var item = FindItem(path);
            if (item == null)
            {
                throw new FileNotFoundException($"{path} not found.");
            }

            return new MediaFileInfo(this, item.Id);
        }

        /// <summary>
        /// Gets a new instance of the MediaDirectoryInfo class, which acts as a wrapper for a directory path.
        /// </summary>
        /// <param name="path">The fully qualified name of the directory or object.</param>
        /// <returns>New instance of the MediaDirectoryInfo class</returns>
        public MediaDirectoryInfo GetDirectoryInfo(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("path");
            }
            if (!IsPath(path))
            {
                throw new ArgumentException("path");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            var item = FindFolder(path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"{path} not found.");
            }

            return new MediaDirectoryInfo(this, item.Id);
        }

        /// <summary>
        /// Gets a new instance of the root MediaDirectoryInfo class, which acts as a wrapper for the root directory path.
        /// </summary>
        /// <returns>New instance of the root MediaDirectoryInfo class</returns>
        public MediaDirectoryInfo GetRootDirectory()
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            return new MediaDirectoryInfo(this, Item.RootId);
        }

        #endregion

        #region Device Capabilities

        /// <summary>
        /// Retrieves all commands supported by the device.
        /// </summary>
        /// <returns>List with supported commands</returns>
        public IEnumerable<Commands> SupportedCommands()
        {
            IPortableDeviceKeyCollection commands;
            this.deviceCapabilities.GetSupportedCommands(out commands);
            return commands.ToEnum<Commands>();
        }

        /// <summary>
        /// Retrieves all functional categories by the device.
        /// </summary>
        /// <returns>List with functional categories</returns>
        public IEnumerable<FunctionalCategory> FunctionalCategories()
        {
            IPortableDevicePropVariantCollection categories;
            this.deviceCapabilities.GetFunctionalCategories(out categories);
            return categories.ToEnum<FunctionalCategory>();
        }

        /// <summary>
        /// Retrieves all functional objects of a functional category by the device.
        /// </summary>
        /// <param name="functionalCategory">Select functional category</param>
        /// <returns>List with functional objects</returns>
        public IEnumerable<string> FunctionalObjects(FunctionalCategory functionalCategory)
        {
            IPortableDevicePropVariantCollection objects;
            this.deviceCapabilities.GetFunctionalObjects(functionalCategory.Guid(), out objects);
            return objects.ToStrings();
        }


        /// <summary>
        /// Get supported content types
        /// </summary>
        /// <param name="functionalCategory">Select functional category</param>
        /// <returns>List with supported content types </returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<ContentType> SupportedContentTypes(FunctionalCategory functionalCategory)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            IPortableDevicePropVariantCollection types;
            this.deviceCapabilities.GetSupportedContentTypes(functionalCategory.Guid(), out types);
            return types.ToEnum<ContentType>();
        }


        /// <summary>
        /// Retrieves all events supported by the device.
        /// </summary>
        /// <returns>List with supported events</returns>
        public IEnumerable<Events> SupportedEvents()
        {
            IPortableDevicePropVariantCollection events;
            this.deviceCapabilities.GetSupportedEvents(out events);
            return events.ToEnum<Events>();
        }

        #endregion

        #region Commands 

        /// <summary>
        /// Reset device
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        /// <exception cref="NotSupportedException">not supported by device.</exception>
        public void ResetDevice()
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            Command.Create(WPD.COMMAND_COMMON_RESET_DEVICE).Send(this.device);
        }

        /// <summary>
        /// Get content locations
        /// </summary>
        /// <param name="contentType">Content type to find the locations for.</param>
        /// <returns>List with the location pathes.</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<string> GetContentLocations(ContentType contentType)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Command cmd = Command.Create(WPD.COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION);
            cmd.Add(WPD.PROPERTY_DEVICE_HINTS_CONTENT_TYPE, contentType.Guid());
            cmd.Send(this.device);
            return cmd.GetPropVariants(WPD.PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS).Select(c => GetPath(c));
        }

        //public void Supported(string id)
        //{
        //    var values = (IPortableDeviceValues)new PortableDeviceValues();
        //    IPortableDeviceValues result;
        //    values.SetGuidValue(WPD_PROPERTY_COMMON_COMMAND_CATEGORY, WPD_COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED.fmtid);
        //    values.SetUnsignedIntegerValue(WPD_PROPERTY_COMMON_COMMAND_ID, WPD_COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED.pid);

        //    values.SetStringValue(WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID, id);
        //    this.device.SendCommand(0, values, out result);

        //    object keys = null;
        //    result.GetIUnknownValue(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS, out keys);
        //    CommandCheckResult(result);
        //}

        /// <summary>
        /// Eject storage
        /// </summary>
        /// <param name="path">Path of storage to eject.</param>
        public void EjectStorage(string path)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            Item item = FindFolder(path);
            Command cmd = Command.Create(WPD.COMMAND_STORAGE_EJECT);
            cmd.Add(WPD.PROPERTY_STORAGE_OBJECT_ID, item.Id);
            cmd.Send(this.device);
        }

        /// <summary>
        /// Format storage
        /// </summary>
        /// <param name="path">Path of storage to format.</param>
        public void FormatStorage(string path)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            Item item = FindFolder(path);
            Command cmd = Command.Create(WPD.COMMAND_STORAGE_FORMAT);
            cmd.Add(WPD.PROPERTY_STORAGE_OBJECT_ID, item.Id);
            cmd.Send(this.device);
        }

        /// <summary>
        /// Send a text SMS
        /// </summary>
        /// <param name="functionalObject">Functional object of the SMS</param>
        /// <param name="recipient">Recipient of the SMS</param>
        /// <param name="text">Text of the SMS</param>
        /// <returns>true is success; false if not</returns>
        /// <example>
        /// <code>
        /// var devices = MediaDevice.GetDevices();
        /// using (var device = devices.First(d => d.FriendlyName == "My Cell Phone"))
        /// {
        ///     device.Connect();
        ///     if (device.FunctionalCategories().Any(c => c == FunctionalCategory.SMS))
        ///     {
        ///         // get list of available SIM cards
        ///         var objects = device.FunctionalObjects(FunctionalCategory.SMS);
        ///         device.SendTextSMS(objects.First());
        ///     }
        ///     device.Disconnect();
        /// }
        /// </code>
        /// </example>
        public bool SendTextSMS(string functionalObject, string recipient, string text)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            if (string.IsNullOrEmpty(functionalObject))
            {
                throw new ArgumentNullException("functionalObject");
            }

            var values = (IPortableDeviceValues)new PortableDeviceValues();
            IPortableDeviceValues result;
            values.SetGuidValue(WPD.PROPERTY_COMMON_COMMAND_CATEGORY, WPD.COMMAND_SMS_SEND.fmtid);
            values.SetUnsignedIntegerValue(WPD.PROPERTY_COMMON_COMMAND_ID, WPD.COMMAND_SMS_SEND.pid);

            values.SetStringValue(WPD.PROPERTY_COMMON_COMMAND_TARGET, functionalObject);
            values.SetStringValue(WPD.PROPERTY_SMS_RECIPIENT, recipient);
            values.SetUnsignedIntegerValue(WPD.PROPERTY_SMS_MESSAGE_TYPE, (uint)SmsMessageType.Text);
            values.SetStringValue(WPD.PROPERTY_SMS_TEXT_MESSAGE, text);
            this.device.SendCommand(0, values, out result);

            return CheckCommonResult(result);
        }

        /// <summary>
        /// Initiate a still image capturing
        /// </summary>
        /// <param name="functionalObject">Functional object of the camera</param>
        /// <returns>true is success; false if not</returns>
        /// <exception cref="System.ArgumentNullException">path is null or empty.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        /// <example>
        /// <code>
        /// var devices = MediaDevice.GetDevices();
        /// using (var device = devices.First(d => d.FriendlyName == "My Cell Phone"))
        /// {
        ///     device.Connect();
        ///     if (device.FunctionalCategories().Any(c => c == FunctionalCategory.StillImageCapture))
        ///     {
        ///         // get list of available cameras (front, rear)
        ///         var objects = device.FunctionalObjects(FunctionalCategory.StillImageCapture);
        ///         device.StillImageCaptureInitiate(objects.First());
        ///         // ObjectAdded event call after image create
        ///     }
        ///     device.Disconnect();
        /// }
        /// </code>
        /// </example>
        public bool StillImageCaptureInitiate(string functionalObject)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            if (string.IsNullOrEmpty(functionalObject))
            {
                throw new ArgumentNullException("functionalObject");
            }

            var values = (IPortableDeviceValues)new PortableDeviceValues();
            IPortableDeviceValues result;
            values.SetGuidValue(WPD.PROPERTY_COMMON_COMMAND_CATEGORY, WPD.COMMAND_STILL_IMAGE_CAPTURE_INITIATE.fmtid);
            values.SetUnsignedIntegerValue(WPD.PROPERTY_COMMON_COMMAND_ID, WPD.COMMAND_STILL_IMAGE_CAPTURE_INITIATE.pid);

            values.SetStringValue(WPD.PROPERTY_COMMON_COMMAND_TARGET, functionalObject);
            this.device.SendCommand(0, values, out result);

            return CheckCommonResult(result);
        }

        internal void CallEvent(IPortableDeviceValues eventParameters)
        {
            string pnpDeviceId = string.Empty;
            Guid eventGuid;
            uint operationState = 0;
            uint operationProgress = 0;
            string objectParentPersistanceUniqueId = string.Empty;
            string objectCreationCookie = string.Empty;
            int childHierarchyChanged = 0;
            string serviceMethodContext = string.Empty;

            eventParameters.GetStringValue(WPD.EVENT_PARAMETER_PNP_DEVICE_ID, out pnpDeviceId);
            eventParameters.GetGuidValue(WPD.EVENT_PARAMETER_EVENT_ID, out eventGuid);
            try
            {
                eventParameters.GetUnsignedIntegerValue(WPD.EVENT_PARAMETER_OPERATION_STATE, out operationState);
            }
            catch { }
            try
            {
                eventParameters.GetUnsignedIntegerValue(WPD.EVENT_PARAMETER_OPERATION_PROGRESS, out operationProgress);
            }
            catch { }
            try
            {
                eventParameters.GetStringValue(WPD.EVENT_PARAMETER_OBJECT_PARENT_PERSISTENT_UNIQUE_ID, out objectParentPersistanceUniqueId);
            }
            catch { }
            try
            {
                eventParameters.GetStringValue(WPD.EVENT_PARAMETER_OBJECT_CREATION_COOKIE, out objectCreationCookie);
            }
            catch { }
            try
            {
                eventParameters.GetBoolValue(WPD.EVENT_PARAMETER_CHILD_HIERARCHY_CHANGED, out childHierarchyChanged);
            }
            catch { }
            try
            {
                eventParameters.GetStringValue(WPD.EVENT_PARAMETER_SERVICE_METHOD_CONTEXT, out serviceMethodContext);
            }
            catch { }


            Events eventEnum = GetEnumFromAttrGuid<Events>(eventGuid);

            MediaDeviceEventArgs eventArgs = new MediaDeviceEventArgs(
                pnpDeviceId,
                eventEnum,
                (OperationState)operationState,
                operationProgress,
                objectParentPersistanceUniqueId,
                objectCreationCookie,
                childHierarchyChanged != 0,
                serviceMethodContext);

            switch (eventEnum)
            {
            case Events.Notification:
                //this.Notification?.Invoke(this, eventArgs);
                break;
            case Events.ObjectAdded:
                this.ObjectAdded?.Invoke(this, eventArgs);
                break;
            case Events.ObjectRemoved:
                this.ObjectRemoved?.Invoke(this, eventArgs);
                break;
            case Events.ObjectUpdated:
                this.ObjectUpdated?.Invoke(this, eventArgs);
                break;
            case Events.DeviceReset:
                this.DeviceReset?.Invoke(this, eventArgs);
                break;
            case Events.DeviceCapabilitiesUpdated:
                this.DeviceCapabilitiesUpdated?.Invoke(this, eventArgs);
                break;
            case Events.StorageFormat:
                this.StorageFormat?.Invoke(this, eventArgs);
                break;
            case Events.ObjectTransferRequest:
                this.ObjectTransferRequest?.Invoke(this, eventArgs);
                break;
            case Events.DeviceRemoved:
                this.DeviceRemoved?.Invoke(this, eventArgs);
                break;
            case Events.ServiceMethodComplete:
                this.ServiceMethodComplete?.Invoke(this, eventArgs);
                break;
            default:
                break;
            }


        }

        /// <summary>
        /// Get storage informations
        /// </summary>
        /// <param name="storageObjectId">ID of the storage object</param>
        /// <returns>MediaStorageInfo class with storage informations</returns>
        /// <exception cref="System.ArgumentNullException">path is null or empty.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        /// <example>
        /// <code>
        /// var devices = MediaDevice.GetDevices();
        /// using (var device = devices.First(d => d.FriendlyName == "My Cell Phone"))
        /// {
        ///     device.Connect();
        ///     
        ///     // get list of available storages (SD-Card, Internal Flash, ...)
        ///     var objects = device.FunctionalObjects(FunctionalCategory.Storage);
        ///     MediaStorageInfo info = GetStorageInfo(objects.First());
        ///     ulong size = info.FreeSpaceInBytes;
        ///     
        ///     device.Disconnect();
        /// }
        /// </code>
        /// </example>
        public MediaStorageInfo GetStorageInfo(string storageObjectId)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            if (string.IsNullOrEmpty(storageObjectId))
            {
                throw new ArgumentNullException(nameof(storageObjectId));
            }

            IPortableDeviceKeyCollection keys = (IPortableDeviceKeyCollection)new PortableDeviceKeyCollection();
            keys.Add(WPD.STORAGE_TYPE);
            keys.Add(WPD.STORAGE_FILE_SYSTEM_TYPE);
            keys.Add(WPD.STORAGE_CAPACITY);
            keys.Add(WPD.STORAGE_FREE_SPACE_IN_BYTES);
            keys.Add(WPD.STORAGE_FREE_SPACE_IN_OBJECTS);
            keys.Add(WPD.STORAGE_DESCRIPTION);
            keys.Add(WPD.STORAGE_SERIAL_NUMBER);
            keys.Add(WPD.STORAGE_MAX_OBJECT_SIZE);
            keys.Add(WPD.STORAGE_CAPACITY_IN_OBJECTS);
            keys.Add(WPD.STORAGE_ACCESS_CAPABILITY);

            IPortableDeviceValues values;
            this.deviceProperties.GetValues(storageObjectId, keys, out values);

            MediaStorageInfo info = new MediaStorageInfo();

            uint type = 0;
            try
            {
                values.GetUnsignedIntegerValue(WPD.STORAGE_TYPE, out type);
            }
            catch { }
            info.Type = (StorageType)type;

            string fileSystemType = String.Empty;
            try
            {
                values.GetStringValue(WPD.STORAGE_FILE_SYSTEM_TYPE, out fileSystemType);
            }
            catch { }
            info.FileSystemType = fileSystemType;

            ulong capacity = 0;
            try
            {
                values.GetUnsignedLargeIntegerValue(WPD.STORAGE_CAPACITY, out capacity);
            }
            catch { }
            info.Capacity = capacity;

            ulong freeBytes = 0;
            try
            {
                values.GetUnsignedLargeIntegerValue(WPD.STORAGE_FREE_SPACE_IN_BYTES, out freeBytes);
            }
            catch { }
            info.FreeSpaceInBytes = freeBytes;

            ulong freeObjects = 0;
            try
            {
                values.GetUnsignedLargeIntegerValue(WPD.STORAGE_FREE_SPACE_IN_OBJECTS, out freeObjects);
            }
            catch { }
            info.FreeSpaceInObjects = freeObjects;

            string description = String.Empty;
            try
            {
                values.GetStringValue(WPD.STORAGE_DESCRIPTION, out description);
            }
            catch { }
            info.Description = description;

            string serialNumber = String.Empty;
            try
            {
                values.GetStringValue(WPD.STORAGE_SERIAL_NUMBER, out serialNumber);
            }
            catch { }
            info.SerialNumber = serialNumber;

            ulong maxObjectSize = 0;
            try
            {
                values.GetUnsignedLargeIntegerValue(WPD.STORAGE_MAX_OBJECT_SIZE, out maxObjectSize);
            }
            catch { }
            info.MaxObjectSize = maxObjectSize;

            ulong capacityInObjects = 0;
            try
            {
                values.GetUnsignedLargeIntegerValue(WPD.STORAGE_CAPACITY_IN_OBJECTS, out capacityInObjects);
            }
            catch { }
            info.CapacityInObjects = capacityInObjects;

            uint accessCapability = 0;
            try
            {
                values.GetUnsignedIntegerValue(WPD.STORAGE_ACCESS_CAPABILITY, out accessCapability);
            }
            catch { }
            info.AccessCapability = (StorageAccessCapability)accessCapability;

            return info;
        }

        #endregion

        #region Intern Methods

        internal void Download(string id, Stream stream)
        {
            using (Stream sourceStream = OpenRead(id))
            {
                sourceStream.CopyTo(stream);
            }
        }

        internal Stream OpenRead(string id)
        {
            IPortableDeviceResources resources;
            this.deviceContent.Transfer(out resources);

            PortableDeviceApiLib.IStream wpdStream;
            uint optimalTransferSize = 0;

            resources.GetStream(id, ref WPD.RESOURCE_DEFAULT, 0, ref optimalTransferSize, out wpdStream);

            return new StreamWrapper(wpdStream);
        }

        internal ObjectProperties GetProperties(string id)
        {
            return new ObjectProperties(this.deviceProperties, id);
        }

        //internal void RefreshFileSystemInfo(MediaFileSystemInfo fileSystemInfo, string id)
        //{ 

        //    ObjectProperties prop = new ObjectProperties(this.deviceProperties, id);
        //    Guid contentType = prop.ContentType;
        //    MediaFileAttributes attributes;
        //    string name;
        //    if (contentType == WPD.CONTENT_TYPE_FUNCTIONAL_OBJECT)
        //    {
        //        name = prop.Name;
        //        attributes = MediaFileAttributes.Object;
        //    }
        //    else if (contentType == WPD.CONTENT_TYPE_FOLDER)
        //    {
        //        name = prop.OriginalFileName;
        //        attributes = MediaFileAttributes.Directory;
        //    }
        //    else
        //    {
        //        name = prop.OriginalFileName;
        //        attributes = MediaFileAttributes.Normal;
        //    }

        //    attributes |= prop.CanDelete ? MediaFileAttributes.CanDelete : 0;
        //    attributes |= prop.IsSystem ? MediaFileAttributes.System : 0;
        //    attributes |= prop.IsHidden ? MediaFileAttributes.Hidden : 0;
        //    attributes |= prop.IsDRMProtected ? MediaFileAttributes.DRMProtected : 0;

        //    fileSystemInfo.Name = name;
        //    fileSystemInfo.Length = prop.Size;
        //    fileSystemInfo.CreationTime = prop.DateCreated;
        //    fileSystemInfo.LastWriteTime = prop.DateModified;
        //    fileSystemInfo.DateAuthored = prop.DateAuthored;
        //    fileSystemInfo.Attributes = attributes;
        //}

        #endregion

        #region Private Methods

        internal static bool IsPath(string path)
        {
            return !string.IsNullOrWhiteSpace(path) && path.IndexOfAny(Path.GetInvalidPathChars()) < 0;
        }

        internal Item GetItem(string id)
        {
            Item item = new Item() { Id = id };
            ObjectProperties prop = new ObjectProperties(this.deviceProperties, id);
            Guid contentType = prop.ContentType;

            //IPortableDeviceKeyCollection keys;
            //IPortableDeviceValues values;
            //string name = string.Empty;
            ////bool isFolder = false;
            //Guid contentType;
            //ItemType itemType;
            //this.deviceProperties.GetSupportedProperties(objectId, out keys);
            //this.deviceProperties.GetValues(objectId, keys, out values);
            //values.GetGuidValue(WPD_OBJECT_CONTENT_TYPE, out contentType);
            //isFolder = contentType == WPD_CONTENT_TYPE_FOLDER || contentType == WPD_CONTENT_TYPE_FUNCTIONAL_OBJECT;

            if (contentType == WPD.CONTENT_TYPE_FUNCTIONAL_OBJECT)
            {
                item.Name = prop.Name;
                item.Type = ItemType.Object;
            }
            else if (contentType == WPD.CONTENT_TYPE_FOLDER)
            {
                item.Name = prop.OriginalFileName;
                item.Type = ItemType.Folder;
            }
            else
            {
                item.Name = prop.OriginalFileName;
                item.Type = ItemType.File;
            }

            return item;
        }

        private string GetParent(string objectId)
        {
            ObjectProperties prop = new ObjectProperties(this.deviceProperties, objectId);
            return prop.ParentId;
            //IPortableDeviceKeyCollection keys;
            //IPortableDeviceValues values;
            //string parentId = string.Empty;
            //this.deviceProperties.GetSupportedProperties(objectId, out keys);
            //this.deviceProperties.GetValues(objectId, keys, out values);

            //values.GetStringValue(WPD_OBJECT_PARENT_ID, out parentId);
            //return parentId;
        }

        internal string GetPath(string objectId)
        {
            StringBuilder sb = new StringBuilder();
            do
            {
                sb.Insert(0, GetItem(objectId).Name);
                sb.Insert(0, DirectorySeparatorChar);

            } while ((objectId = GetParent(objectId)) != Item.Root.Id);
            return sb.ToString();
        }

        //private PropVariant GetProperty(PropertyKey propertyKey)
        //{
        //    if (!this.IsConnected)
        //    {
        //        throw new NotConnectedException("Not connected");
        //    }

        //    try
        //    {
        //        PROPVARIANT val;
        //        IPortableDeviceValues propertyValues;
        //        this.deviceProperties.GetValues(Item.Root.Id, null, out propertyValues);
        //        propertyValues.GetValue(ref propertyKey, out val);
        //        return val;
        //    }
        //    catch (COMException ex)
        //    {
        //        if ((uint)ex.ErrorCode != E_ELEMENT_NOT_FOUND)
        //        {
        //            Trace.TraceError("{0} - {1} - {2}", this.Description, new StackFrame(1, true).GetMethod().Name, ex.Message);
        //            throw new NotSupportedException($"{this.Description} - {new StackFrame(1, true).GetMethod().Name}", ex);
        //        }
        //        throw;
        //    }
        //}

        //private T GetPropery<T>(PropertyKey propertyKey)
        //{
        //    if (!this.IsConnected)
        //    {
        //        throw new NotConnectedException("Not connected");
        //    }
        //    try
        //    {
        //        PROPVARIANT val;
        //        IPortableDeviceValues propertyValues;
        //        this.deviceProperties.GetValues(Item.Root.Id, null, out propertyValues);
        //        propertyValues.GetValue(ref propertyKey, out val);

        //        int size = Marshal.SizeOf(typeof(PROPVARIANT));
        //        IntPtr ptrValue = Marshal.AllocHGlobal(size);
        //        Marshal.StructureToPtr(val, ptrValue, false);

        //        return (T)Marshal.GetObjectForNativeVariant(ptrValue);
        //    }
        //    catch (COMException ex)
        //    {
        //        if ((uint)ex.ErrorCode != E_ELEMENT_NOT_FOUND)
        //        {
        //            throw new NotSupportedException($"{this.Description} - {new StackFrame(1, true).GetMethod().Name}", ex);
        //        }
        //        throw;
        //    }
        //}

        private string GetStringProperty(PropertyKey propertyKey)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            string val = string.Empty;
            try
            {
                IPortableDeviceValues propertyValues;
                this.deviceProperties.GetValues(Item.Root.Id, null, out propertyValues);
                propertyValues.GetStringValue(ref propertyKey, out val);
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != (uint)HResult.E_ELEMENT_NOT_FOUND)
                {
                    Trace.TraceError("{0} - {1} - {2}", this.Description, new StackFrame(1, true).GetMethod().Name, ex.Message);
                    throw new NotSupportedException($"{this.Description} - {new StackFrame(1, true).GetMethod().Name}", ex);

                }
            }
            return val;
        }

        private void SetStringProperty(PropertyKey propertyKey, string val)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            try
            {
                IPortableDeviceValues propertyValues;
                IPortableDeviceValues propertyValuesRes;
                this.deviceProperties.GetValues(Item.Root.Id, null, out propertyValues);
                propertyValues.SetStringValue(ref propertyKey, val);

                this.deviceProperties.SetValues(Item.Root.Id, propertyValues, out propertyValuesRes);
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != (uint)HResult.E_ELEMENT_NOT_FOUND)
                {
                    Trace.TraceError("{0} - {1} - {2}", this.Description, new StackFrame(1, true).GetMethod().Name, ex.Message);
                    throw new NotSupportedException($"{this.Description} - {new StackFrame(1, true).GetMethod().Name}", ex);
                }
                throw;
            }
        }

        private int GetIntegerProperty(PropertyKey propertyKey)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            int val = -1;
            try
            {
                PortableDeviceApiLib.IPortableDeviceValues propertyValues;
                this.deviceProperties.GetValues(Item.Root.Id, null, out propertyValues);
                propertyValues.GetSignedIntegerValue(ref propertyKey, out val);
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != (uint)HResult.E_ELEMENT_NOT_FOUND)
                {
                    Trace.TraceError("{0} - {1} - {2}", this.Description, new StackFrame(1, true).GetMethod().Name, ex.Message);
                    throw new NotSupportedException($"{this.Description} - {new StackFrame(1, true).GetMethod().Name}", ex);
                }
            }
            return val;
        }

        private ulong GetULongProperty(PropertyKey propertyKey)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            ulong val = 0;
            try
            {
                PortableDeviceApiLib.IPortableDeviceValues propertyValues;
                this.deviceProperties.GetValues(Item.Root.Id, null, out propertyValues);
                propertyValues.GetUnsignedLargeIntegerValue(ref propertyKey, out val);
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != (uint)HResult.E_ELEMENT_NOT_FOUND)
                {
                    Trace.TraceError("{0} - {1} - {2}", this.Description, new StackFrame(1, true).GetMethod().Name, ex.Message);
                    throw new NotSupportedException($"{this.Description} - {new StackFrame(1, true).GetMethod().Name}", ex);
                }
            }
            return val;
        }

        private bool GetBoolProperty(PropertyKey propertyKey)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            int val = 0;
            try
            {
                PortableDeviceApiLib.IPortableDeviceValues propertyValues;
                this.deviceProperties.GetValues(Item.Root.Id, null, out propertyValues);
                propertyValues.GetBoolValue(ref propertyKey, out val);
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != (uint)HResult.E_ELEMENT_NOT_FOUND)
                {
                    Trace.TraceError("{0} - {1} - {2}", this.Description, new StackFrame(1, true).GetMethod().Name, ex.Message);
                    throw new NotSupportedException($"{this.Description} - {new StackFrame(1, true).GetMethod().Name}", ex);
                }
            }
            return val > 0;
        }

        private DateTime? GetDateTimeProperty(PropertyKey propertyKey)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            object obj = null;
            try
            {
                PortableDeviceApiLib.IPortableDeviceValues propertyValues;
                this.deviceProperties.GetValues(Item.Root.Id, null, out propertyValues);
                propertyValues.GetIUnknownValue(ref propertyKey, out obj);
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != (uint)HResult.E_ELEMENT_NOT_FOUND)
                {
                    Trace.TraceError(ex.Message);
                    throw new NotSupportedException($"{this.Description} - {new StackFrame(1, true).GetMethod().Name}", ex);
                }
            }
            return (DateTime?)obj;
        }

        private object GetObjectProperty(PropertyKey propertyKey)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            object val = null;
            try
            {
                PortableDeviceApiLib.IPortableDeviceValues propertyValues;
                this.deviceProperties.GetValues(Item.Root.Id, null, out propertyValues);
                propertyValues.GetIUnknownValue(ref propertyKey, out val);
            }
            catch (COMException ex)
            {
                if ((uint)ex.ErrorCode != (uint)HResult.E_ELEMENT_NOT_FOUND)
                {
                    Trace.TraceError("{0} - {1} - {2}", this.Description, new StackFrame(1, true).GetMethod().Name, ex.Message);
                    throw new NotSupportedException($"{this.Description} - {new StackFrame(1, true).GetMethod().Name}", ex);
                }
            }
            return val;
        }

        private Item FindFolder(string path)
        {
            var item = Item.Root;
            var folders = path.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var folder in folders)
            {
                item = GetChildren(item.Id).FirstOrDefault(i => i.Type != ItemType.File && i.Name == folder);     // check all if folder             
                if (item == null)
                {
                    return null;
                }
            }
            return item;
        }

        private Item FindFile(string path)
        {
            var item = Item.Root;
            var folders = path.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var folder in folders)
            {
                item = GetChildren(item.Id).FirstOrDefault(i => i.Name == folder);
                if (item == null)
                {
                    return null;
                }
            }
            return item.Type == ItemType.File ? item : null;    // check only last if not folder
        }

        private Item FindItem(string path)
        {
            var item = Item.Root;
            var folders = path.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var folder in folders)
            {
                item = GetChildren(item.Id).FirstOrDefault(i => i.Name == folder);
                if (item == null)
                {
                    return null;
                }
            }
            return item;
        }

        internal IEnumerable<Item> GetChildren(string id)
        {
            IEnumPortableDeviceObjectIDs objectIds;
            this.deviceContent.EnumObjects(0, id, null, out objectIds);

            uint fetched = 0;
            string objectId;
            objectIds.Next(1, out objectId, ref fetched);
            while (fetched > 0)
            {
                yield return this.GetItem(objectId);
                objectIds.Next(1, out objectId, ref fetched);
            }
        }

        internal IEnumerable<Item> GetChildren(string id, string searchPattern, SearchOption searchOption)
        {
            string pattern = MediaDevice.FilterToRegex(searchPattern);

            IEnumPortableDeviceObjectIDs objectIds;
            this.deviceContent.EnumObjects(0, id, null, out objectIds);

            uint fetched = 0;
            string objectId;
            objectIds.Next(1, out objectId, ref fetched);
            while (fetched > 0)
            {
                Item item = this.GetItem(objectId);
                if (Regex.IsMatch(item.Name, pattern, RegexOptions.IgnoreCase))
                {
                    yield return item;
                }
                if (searchOption == SearchOption.AllDirectories && item.Type != ItemType.File)
                {
                    var children = GetChildrenRecursive(item.Id, pattern);
                    foreach (var c in children)
                    {
                        yield return c;
                    }
                }
                objectIds.Next(1, out objectId, ref fetched);
            }
        }

        internal IEnumerable<Item> GetChildrenRecursive(string id, string pattern)
        {
            IEnumPortableDeviceObjectIDs objectIds;
            this.deviceContent.EnumObjects(0, id, null, out objectIds);

            uint fetched = 0;
            string objectId;
            objectIds.Next(1, out objectId, ref fetched);
            while (fetched > 0)
            {
                Item item = this.GetItem(objectId);
                if (Regex.IsMatch(item.Name, pattern, RegexOptions.IgnoreCase))
                {
                    yield return item;
                }
                foreach (var c in GetChildrenRecursive(item.Id, pattern))
                {
                    yield return c;
                }
                objectIds.Next(1, out objectId, ref fetched);
            }
        }

        internal Item CreateSubdirectory(string path, string id = Item.RootId)
        {
            Item child = null;
            var folders = path.Split(new char[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var folder in folders)
            {
                child = GetChildren(id).FirstOrDefault(i => i.Name == folder);
                if (child == null)
                {
                    // create a new directory
                    IPortableDeviceValues deviceValues = (IPortableDeviceValues)new PortableDeviceValues();
                    deviceValues.SetStringValue(ref WPD.OBJECT_PARENT_ID, id);
                    deviceValues.SetStringValue(ref WPD.OBJECT_NAME, folder);
                    deviceValues.SetStringValue(ref WPD.OBJECT_ORIGINAL_FILE_NAME, folder);
                    deviceValues.SetGuidValue(ref WPD.OBJECT_CONTENT_TYPE, ref WPD.CONTENT_TYPE_FOLDER);
                    this.deviceContent.CreateObjectWithPropertiesOnly(deviceValues, ref id);
                }
                else if (child.Type == ItemType.File)
                {
                    // folder is already a file
                    throw new Exception($"A path of the path {folder} is a file");
                }
                else
                {
                    // folder exists
                    id = child.Id;
                }
            }
            return child;
        }

        internal static string FilterToRegex(string filter)
        {
            StringBuilder s = new StringBuilder(Path.GetFileName(filter));
            s.Replace(".", @"\.");
            s.Replace("+", @"\+");
            s.Replace("$", @"\$");
            s.Replace("(", @"\(");
            s.Replace(")", @"\)");
            s.Replace("[", @"\[");
            s.Replace("]", @"\]");
            s.Replace("?", ".?");
            s.Replace("*", ".*");
            return s.ToString();
        }

        #endregion

        #region helper

        private static FieldInfo[] propertyKeyFields = null;

        private string FindPropertyKeyName(PropertyKey propertyKey)
        {
            if (propertyKeyFields == null)
            {
                propertyKeyFields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Static).Where(f => f.FieldType == typeof(PropertyKey)).ToArray();
            }

            return propertyKeyFields.
                Select(f => new { FI = f, PK = (PropertyKey)f.GetValue(this) }).
                Where(n => n.PK.fmtid == propertyKey.fmtid && n.PK.pid == propertyKey.pid).
                Select(n => n.FI.Name).
                FirstOrDefault();
        }

        private static FieldInfo[] guidFields = null;

        private string FindGuidName(PROPVARIANT value)
        {
            if (guidFields == null)
            {
                guidFields = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Static).Where(f => f.FieldType == typeof(Guid)).ToArray();
            }

            Guid guid = (PropVariant)value;
            return guidFields.
                Select(f => new { FI = f, Guid = (Guid)f.GetValue(this) }).
                Where(n => n.Guid == guid).
                Select(n => n.FI.Name).
                FirstOrDefault();
        }


        private Guid GetAttrGuidFromEnum<T>(T val)
        {
            return val.GetType().GetField(val.ToString()).GetCustomAttribute<GuidAttribute>().Guid;
        }

        private T GetEnumFromAttrGuid<T>(Guid guid)
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Where(e => GetAttrGuidFromEnum(e) == guid).FirstOrDefault();
        }

        private bool IsAttrKeyFromEnum<T>(T val, PropertyKey key)
        {
            KeyAttribute attr = val.GetType().GetField(val.ToString()).GetCustomAttribute<KeyAttribute>();
            return attr.Guid == key.fmtid && attr.Id == key.pid;
        }

        private T GetEnumFromAttrKey<T>(PropertyKey key)
        {
            return Enum.GetValues(typeof(T)).Cast<T>().Where(e => IsAttrKeyFromEnum(e, key)).FirstOrDefault();
        }

        private bool CheckCommonResult(IPortableDeviceValues result)
        {
            int error = 0;
            result.GetErrorValue(WPD.PROPERTY_COMMON_HRESULT, out error);
            //uint deviceErrorCode = 0;
            //result.GetUnsignedIntegerValue(WPD.PROPERTY_COMMON_DRIVER_ERROR_CODE, out deviceErrorCode);

            this.lastError = (HResult)error;
            return error == 0;
        }


        #endregion
    }
}