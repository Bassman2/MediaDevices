using MediaDevices.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MediaDevices
{
    /// <summary>
    /// Represents a portable device.
    /// </summary>
    [DebuggerDisplay("{FriendlyName}, {Manufacturer}, {Description}")]
    public sealed class MediaDevice : IDisposable
    {
        // https://msdn.microsoft.com/en-us/ie/aa645736%28v=vs.94%29?f=255&MSPPError=-2147217396

        #region Fields

        internal IPortableDevice device;
        internal IPortableDeviceContent deviceContent;
        internal IPortableDeviceProperties deviceProperties;
        private IPortableDeviceCapabilities deviceCapabilities;
        private IPortableDeviceValues deviceValues;
        private string friendlyName = string.Empty;
        private string eventCookie;
        private EventCallback eventCallback;        

        #endregion

        #region events

        /// <summary>
        /// This event is sent after a new object is available on the device.
        /// </summary>
        public event EventHandler<ObjectAddedEventArgs> ObjectAdded;

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

        private static readonly IPortableDeviceManager portableDeviceManager;

        private static List<MediaDevice> devices;
        private static List<MediaDevice> privateDevices;

        static MediaDevice()
        {
            try
            {
                PortableDeviceManager inst = new PortableDeviceManager();
                portableDeviceManager = (IPortableDeviceManager)inst;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

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

            if (devices == null)
            {
                devices = deviceIds.Select(d => new MediaDevice(d)).ToList();
            }
            else
            {
                UpdateDeviceList(devices, deviceIds);
            }
            return devices;
        }

        private static void UpdateDeviceList(List<MediaDevice> deviceList, string[] deviceIdList)
        {
            var idList = deviceIdList.ToList();

            // remove
            var remove = deviceList.Where(d => !idList.Contains(d.DeviceId)).Select(d => d.DeviceId).ToList();
            deviceList.RemoveAll(d => remove.Contains(d.DeviceId));

            // add
            var add = idList.Where(id => !deviceList.Select(d => d.DeviceId).Contains(id)).ToList();
            deviceList.AddRange(add.Select(id => new MediaDevice(id)));
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

            if (count == 0)
            {
                return new List<MediaDevice>();
            }

            // get device IDs
            var deviceIds = new string[count];
            portableDeviceManager.GetPrivateDevices(deviceIds, ref count);

            if (privateDevices == null)
            {
                privateDevices = deviceIds.Select(d => new MediaDevice(d)).ToList();
            }
            else
            {
                UpdateDeviceList(privateDevices, deviceIds);
            }
            return privateDevices;
        }

        #endregion

        #region constructor

        private MediaDevice(string deviceId)
        {
            this.DeviceId = deviceId;
            this.IsCaseSensitive = false;

            
            uint count = 256;
            try
            {
                count = 256;
                StringBuilder sb = new StringBuilder((int)count);
                portableDeviceManager.GetDeviceDescription(deviceId, sb, ref count);
                this.Description = sb.ToString(); //new string(buffer, 0, (int)count - 1);
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
                this.Description = string.Empty;
            }
            try
            {
                count = 256;
                StringBuilder sb = new StringBuilder((int)count);
                portableDeviceManager.GetDeviceFriendlyName(deviceId, sb, ref count);
                this.friendlyName = sb.ToString();
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
                this.friendlyName = string.Empty;
            }
            try
            {
                count = 256;
                StringBuilder sb = new StringBuilder((int)count);
                portableDeviceManager.GetDeviceManufacturer(deviceId, sb, ref count);
                this.Manufacturer = sb.ToString();
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
                this.Description = string.Empty;
            }

            //this.device = new PortableDeviceApiLib.PortableDevice();
            this.device = (IPortableDevice)new PortableDevice();
        }

        /// <summary>
        /// Releases the resources used by the PortableDevices.PortableDevice.
        /// </summary>
        public void Dispose()
        {
            Disconnect();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Is portable device connected.
        /// </summary>
        public bool IsConnected { get; private set; }

        /// <summary>
        /// Select if path is case sensitive or not. Default is not. 
        /// </summary>
        public bool IsCaseSensitive { get; private set; }

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
            get
            {
                if (IsConnected)
                {
                    if (this.deviceValues.TryGetStringValue(WPD.DEVICE_FRIENDLY_NAME, out string val))
                    {
                        return val;
                    }
                    else
                    {
                        return this.friendlyName;
                    }
                }
                else
                {
                    return this.friendlyName;
                }
            }
            set
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                // set new friendly name
                IPortableDeviceValues devValues = (IPortableDeviceValues)new PortableDeviceValues();
                devValues.SetStringValue(ref WPD.DEVICE_FRIENDLY_NAME, value);
                this.deviceProperties.SetValues(Item.RootId, devValues, out devValues);

                // reload device values with new friendly name 
                this.deviceProperties.GetValues(Item.RootId, null, out this.deviceValues);

                // reload disconnected friendly name
                try
                {
                    char[] buffer = new char[260];
                    uint count = 256;
                    StringBuilder sb = new StringBuilder((int)count);
                    portableDeviceManager.GetDeviceFriendlyName(this.DeviceId, sb, ref count);
                    this.friendlyName = sb.ToString();
                }
                catch (COMException ex)
                {
                    Trace.WriteLine(ex.ToString());
                    this.friendlyName = string.Empty;
                }
            }
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
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetStringValue(WPD.DEVICE_SYNC_PARTNER, out string val);
                return val;
            }
        }

        /// <summary>
        /// Firmware version of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string FirmwareVersion
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetStringValue(WPD.DEVICE_FIRMWARE_VERSION, out string val);
                return val;
            }
        }

        /// <summary>
        /// Battery level of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public int PowerLevel
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetSignedIntegerValue(WPD.DEVICE_POWER_LEVEL, out int val);
                return val;
            }
        }

        /// <summary>
        /// Power source of the device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public PowerSource PowerSource
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                if (this.deviceValues.TryGetSignedIntegerValue(WPD.DEVICE_POWER_SOURCE, out int val))
                {
                    return (PowerSource)val;
                }
                else
                {
                    return PowerSource.Unknown;
                }
            }
        }

        /// <summary>
        /// Protocol of the device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string Protocol
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetStringValue(WPD.DEVICE_PROTOCOL, out string val);
                return val;
            }
        }

        /// <summary>
        /// Model of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string Model
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetStringValue(WPD.DEVICE_MODEL, out string val);
                return val;
            }
        }

        /// <summary>
        /// Serial number of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string SerialNumber
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetStringValue(WPD.DEVICE_SERIAL_NUMBER, out string val);
                return val;
            }
        }

        /// <summary>
        /// Supports non consumable.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public bool? SupportsNonConsumable
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                if (this.deviceValues.TryGetBoolValue(WPD.DEVICE_SUPPORTS_NON_CONSUMABLE, out bool val))
                {
                    return val;
                }
                return null;
            }
        }

        /// <summary>
        /// Date and time of the media device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public DateTime? DateTime
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetDateTimeValue(WPD.DEVICE_DATETIME, out DateTime? val);
                return val;
            }
        }

        /// <summary>
        /// Supported formats are ordered.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public bool? SupportedFormatsAreOrdered
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                if (this.deviceValues.TryGetBoolValue(WPD.DEVICE_SUPPORTED_FORMATS_ARE_ORDERED, out bool val))
                {
                    return val;
                }
                return null;
            }
        }

        /// <summary>
        /// Device type of the portable device.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public DeviceType DeviceType
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetSignedIntegerValue(WPD.DEVICE_TYPE, out int val);
                return (DeviceType)val;
            }
        }

        /// <summary>
        /// Network Identifier
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public ulong NetworkIdentifier
        {
            get
            {
                
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetUnsignedLargeIntegerValue(WPD.DEVICE_NETWORK_IDENTIFIER, out ulong val);
                return val;
            }
        }

        /// <summary>
        /// Functional unique id od the media device
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public byte[] FunctionalUniqueId
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryByteArrayValue(WPD.DEVICE_FUNCTIONAL_UNIQUE_ID, out byte[] val);
                return val;
            }
        }

        /// <summary>
        /// Model unique id od the media device
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public byte[] ModelUniqueId
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryByteArrayValue(WPD.DEVICE_MODEL_UNIQUE_ID, out byte[] value);
                return value;
            }
        }

        /// <summary>
        /// Device transport.
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public DeviceTransport Transport
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetSignedIntegerValue(WPD.DEVICE_TRANSPORT, out int val);
                return (DeviceTransport)val;
            }
        }

        /// <summary>
        /// Use device stage
        /// </summary>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public DeviceTransport UseDeviceStage
        {
            get
            {
                if (!this.IsConnected)
                {
                    throw new NotConnectedException("Not connected");
                }

                this.deviceValues.TryGetUnsignedIntegerValue(WPD.DEVICE_USE_DEVICE_STAGE, out uint val);
                return (DeviceTransport)val;
            }
        }

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

                this.device.GetPnPDeviceID(out string pnPDeviceID);
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
            this.deviceProperties.GetValues(Item.RootId, null, out this.deviceValues);

            ComTrace.WriteObject(this.deviceValues);

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

            Item item = Item.FindFolder(this, path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return item.GetChildren().Where(i => i.Type != ItemType.File).Select(i => i.FullName);
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

            Item item = Item.FindFolder(this, path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return item.GetChildren(FilterToRegex(searchPattern), searchOption).Where(i => i.Type != ItemType.File).Select(i => i.FullName);
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

            Item item = Item.FindFolder(this, path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return item.GetChildren().Where(i => i.Type == ItemType.File).Select(i => i.FullName);
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

            Item item = Item.FindFolder(this, path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            string pattern = MediaDevice.FilterToRegex(searchPattern);
            return item.GetChildren(pattern, searchOption).Where(i => i.Type == ItemType.File).Select(i => i.FullName);
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

            Item item = Item.FindFolder(this, path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            return item.GetChildren().Select(i => i.FullName);
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

            Item item = Item.FindFolder(this, path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }
            
            return item.GetChildren(FilterToRegex(searchPattern), searchOption).Select(i => i.FullName);
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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string[] GetDirectories(string path)
        {
            return EnumerateDirectories(path).ToArray();
        }

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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return EnumerateDirectories(path, searchPattern, searchOption).ToArray();
        }

        /// <summary>
        /// Returns an array of file names in a specified path.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <returns>An array of file names in the directory specified by path.</returns>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string[] GetFiles(string path)
        {
            return EnumerateFiles(path).ToArray();
        }

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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return EnumerateFiles(path, searchPattern, searchOption).ToArray();
        }

        /// <summary>
        /// Returns an array of file-system entries in a specified path.
        /// </summary>
        /// <param name="path">The directory to search.</param>
        /// <returns>An array of file-system entries in the directory specified by path.</returns>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string[] GetFileSystemEntries(string path)
        {
            return EnumerateFileSystemEntries(path).ToArray();
        }

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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            return EnumerateFileSystemEntries(path, searchPattern, searchOption).ToArray();
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

            Item.GetRoot(this).CreateSubdirectory(path);
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

            Item item = Item.FindFolder(this, path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Director {path} not found.");
            }

            item.Delete(recursive);
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
            return Item.FindFolder(this, path) != null;
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

            Item item = Item.FindFile(this, path);
            if (item == null)
            {
                throw new FileNotFoundException($"File {path} not found.");
            }
            
            using (Stream sourceStream = item.OpenRead())
            {
                sourceStream.CopyTo(stream);
            }
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
            Item item = Item.FindFolder(this, folder);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"Directory {folder} not found.");
            }

            if (item.GetChildren().Any(i => EqualsName(i.Name, fileName)))
            {
                throw new IOException($"File {path} already exists");
            }

            item.UploadFile(fileName, stream);
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
            var objectId = Item.FindFile(this, path);
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

            Item item = Item.FindFile(this, path); 
            if (item == null)
            {
                throw new FileNotFoundException($"File {path} not found.");
            }

            item.Delete();
        }

        /// <summary>
        /// Rename a file or folder.
        /// </summary>
        /// <param name="path">Path to the file or folder to rename.</param>
        /// <param name="newName">New name of the file or folder.</param>
        public void Rename(string path, string newName)
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
            if (string.IsNullOrEmpty(newName))
            {
                throw new ArgumentNullException("newName");
            }

            Item item = Item.FindItem(this, path);
            if (item == null)
            {
                throw new FileNotFoundException($"Path {path} not found.");
            }

            item.Rename(newName);
        }

        /// <summary>
        /// Gets a new instance of the MediaFileInfo class, which acts as a wrapper for a file path.
        /// </summary>
        /// <param name="path">The fully qualified name of the file, directory or object.</param>
        /// <returns>New instance of the MediaFileInfo class</returns>
        /// <exception cref="System.IO.IOException">path is a file name.</exception>
        /// <exception cref="System.ArgumentException">path is a zero-length string, contains only white space, or contains invalid characters as defined by System.IO.Path.GetInvalidPathChars.</exception>
        /// <exception cref="System.ArgumentNullException">path is null.</exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
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

            var item = Item.FindItem(this, path);
            if (item == null)
            {
                throw new FileNotFoundException($"{path} not found.");
            }

            return new MediaFileInfo(this, item);
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
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
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

            var item = Item.FindFolder(this, path);
            if (item == null)
            {
                throw new DirectoryNotFoundException($"{path} not found.");
            }

            return new MediaDirectoryInfo(this, item);
        }

        /// <summary>
        /// Get all drives of the device.
        /// </summary>
        /// <returns>Array with all drives of the device.</returns>
        public MediaDriveInfo[] GetDrives()
        {
            return this.FunctionalObjects(FunctionalCategory.Storage)?.Select(o => new MediaDriveInfo(this, o)).ToArray();
        }

        /// <summary>
        /// Gets a new instance of the root MediaDirectoryInfo class, which acts as a wrapper for the root directory path.
        /// </summary>
        /// <returns>New instance of the root MediaDirectoryInfo class</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public MediaDirectoryInfo GetRootDirectory()
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            return new MediaDirectoryInfo(this, Item.GetRoot(this));
        }


        /// <summary>
        /// Download data from a file on a portable device to a stream identified by a Persistent Unique Id.
        /// </summary>
        /// <param name="persistentUniqueId">Persistent Unique Id of the file.</param>
        /// <param name="stream">The stream to download to.</param>
        /// <exception cref="System.ArgumentNullException">persistentUniqueId is null or empty.</exception>
        /// <exception cref="System.ArgumentNullException">stream is null.</exception>
        /// <exception cref="System.IO.FileNotFoundException">persistentUniqueId not found.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void DownloadFileFromPersistentUniqueId(string persistentUniqueId, Stream stream)
        {
            if (string.IsNullOrEmpty(persistentUniqueId))
            {
                throw new ArgumentNullException("persistentUniqueId");
            }
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            using (Stream sourceStream = OpenReadFromPersistentUniqueId(persistentUniqueId))
            {
                sourceStream.CopyTo(stream);
            }
        }

        /// <summary>
        /// Opens a files stream from an Persistent Unique ID to read from.
        /// </summary>
        /// <param name="persistentUniqueId">Persistent unique ID of the item.</param>
        /// <returns>A new read-only FileStream object.</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        /// <exception cref="System.ArgumentNullException">persistentUniqueId is null or empty.</exception>
        /// <exception cref="System.IO.FileNotFoundException">persistentUniqueId not found.</exception>
        public Stream OpenReadFromPersistentUniqueId(string persistentUniqueId)
        {
            if (string.IsNullOrEmpty(persistentUniqueId))
            {
                throw new ArgumentNullException("persistentUniqueId");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = Item.GetFromPersistentUniqueId(this, persistentUniqueId);
            if (item == null || !item.IsFile)
            {
                throw new FileNotFoundException($"{persistentUniqueId} not found.");
            }
            return item.OpenRead();
        }

        /// <summary>
        /// Opens a stream reader with UTF-8 encoding from an Persistent Unique ID to read from.
        /// </summary>
        /// <param name="persistentUniqueId">Persistent unique ID of the item.</param>
        /// <returns>A new StreamReader object.</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        /// <exception cref="System.ArgumentNullException">persistentUniqueId is null or empty.</exception>
        /// <exception cref="System.IO.FileNotFoundException">persistentUniqueId not found.</exception>
        public StreamReader OpenTextFromPersistentUniqueId(string persistentUniqueId)
        {
            if (string.IsNullOrEmpty(persistentUniqueId))
            {
                throw new ArgumentNullException("persistentUniqueId");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = Item.GetFromPersistentUniqueId(this, persistentUniqueId);
            if (item == null || !item.IsFile)
            {
                throw new FileNotFoundException($"{persistentUniqueId} not found.");
            }
            return item == null ? null : new StreamReader(item.OpenRead());
        }

        /// <summary>
        /// Create a <see cref="MediaFileSystemInfo"/> instance from the Persistent Unique Id.
        /// </summary>
        /// <param name="persistentUniqueId">Persistent Unique Id of the file or folder.</param>
        /// <returns>New instance of the <see cref="MediaFileInfo"/> or <see cref="MediaDirectoryInfo"/> class.</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        /// <exception cref="System.ArgumentNullException">persistentUniqueId is null or empty.</exception>
        /// <exception cref="System.IO.FileNotFoundException">persistentUniqueId not found.</exception>
        public MediaFileSystemInfo GetFileSystemInfoFromPersistentUniqueId(string persistentUniqueId)
        {
            if (string.IsNullOrEmpty(persistentUniqueId))
            {
                throw new ArgumentNullException("persistentUniqueId");
            }
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Item item = Item.GetFromPersistentUniqueId(this, persistentUniqueId);
            if (item == null)
            {
                throw new FileNotFoundException($"{persistentUniqueId} not found.");
            }

            if (item.IsFile)
            {
                return new MediaFileInfo(this, item);
            }
            else
            {
                return new MediaDirectoryInfo(this, item);
            }
        }

        #endregion

        #region Device Capabilities

        /// <summary>
        /// Retrieves all commands supported by the device.
        /// </summary>
        /// <returns>List with supported commands</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<Commands> SupportedCommands()
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            try
            {
                IPortableDeviceKeyCollection commands;
                this.deviceCapabilities.GetSupportedCommands(out commands);
                return commands.ToEnum<Commands>();
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Retrieves all functional categories by the device.
        /// </summary>
        /// <returns>List with functional categories</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<FunctionalCategory> FunctionalCategories()
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            try
            {
                IPortableDevicePropVariantCollection categories;
                this.deviceCapabilities.GetFunctionalCategories(out categories);
                return categories.ToEnum<FunctionalCategory>();
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// Retrieves all functional objects of a functional category by the device.
        /// </summary>
        /// <param name="functionalCategory">Select functional category</param>
        /// <returns>List with functional objects</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<string> FunctionalObjects(FunctionalCategory functionalCategory)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            try
            {
                var g = functionalCategory.Guid();
                IPortableDevicePropVariantCollection objects;
                Guid guid = functionalCategory.Guid();
                this.deviceCapabilities.GetFunctionalObjects(ref guid, out objects);
                ComTrace.WriteObject(objects);
                return objects.ToStrings();
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return null;
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

            try
            {
                IPortableDevicePropVariantCollection types;
                Guid guid = functionalCategory.Guid();
                this.deviceCapabilities.GetSupportedContentTypes(ref guid, out types);
                return types.ToEnum<ContentType>();
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return null;
        }


        /// <summary>
        /// Retrieves all events supported by the device.
        /// </summary>
        /// <returns>List with supported events</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<Events> SupportedEvents()
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            try
            { 
                IPortableDevicePropVariantCollection events;
                this.deviceCapabilities.GetSupportedEvents(out events);
                return events.ToEnum<Events>();
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return null;
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
        /// <returns>List with the location paths.</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<string> GetContentLocations(ContentType contentType)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            try
            {
                Command cmd = Command.Create(WPD.COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION);
                cmd.Add(WPD.PROPERTY_DEVICE_HINTS_CONTENT_TYPE, contentType.Guid());
                if (!cmd.Send(this.device))
                {
                    cmd.WriteResults();
                    return new List<string>();
                }
                
                return cmd.GetPropVariants(WPD.PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS).Select(c => Item.Create(this, c).FullName);
            }
            catch (COMException ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return null;
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
        /// <returns>true is success and false if not supported.</returns>
        public bool EjectStorage(string path)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }

            Item item = Item.FindFolder(this, path);
            return InternalEject(item.Id);
        }

        internal bool InternalEject(string id)
        {
            Command cmd = Command.Create(WPD.COMMAND_STORAGE_EJECT);
            cmd.Add(WPD.PROPERTY_STORAGE_OBJECT_ID, id);
            return cmd.Send(this.device);
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

            Item item = Item.FindFolder(this, path);
            Format(item.Id);
            //Command cmd = Command.Create(WPD.COMMAND_STORAGE_FORMAT);
            //cmd.Add(WPD.PROPERTY_STORAGE_OBJECT_ID, item.Id);
            //cmd.Send(this.device);
        }

        internal void Format(string id)
        {
            Command cmd = Command.Create(WPD.COMMAND_STORAGE_FORMAT);
            cmd.Add(WPD.PROPERTY_STORAGE_OBJECT_ID, id);
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
            
            Command cmd = Command.Create(WPD.COMMAND_SMS_SEND);
            cmd.Add(WPD.PROPERTY_COMMON_COMMAND_TARGET, functionalObject);
            cmd.Add(WPD.PROPERTY_SMS_RECIPIENT, recipient);
            cmd.Add(WPD.PROPERTY_SMS_MESSAGE_TYPE, (uint)SmsMessageType.Text);
            cmd.Add(WPD.PROPERTY_SMS_TEXT_MESSAGE, text);
            return cmd.Send(this.device);
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
            
            Command cmd = Command.Create(WPD.COMMAND_STILL_IMAGE_CAPTURE_INITIATE);
            cmd.Add(WPD.PROPERTY_COMMON_COMMAND_TARGET, functionalObject);
            return cmd.Send(this.device);
        }

        internal void CallEvent(IPortableDeviceValues eventParameters)
        {
            //ComTrace.WriteObject(eventParameters);
            Guid eventGuid;
            eventParameters.GetGuidValue(ref WPD.EVENT_PARAMETER_EVENT_ID, out eventGuid);
            Events eventEnum = eventGuid.GetEnumFromAttrGuid<Events>();

            switch (eventEnum)
            {
            case Events.ObjectAdded:
                this.ObjectAdded?.Invoke(this, new ObjectAddedEventArgs(eventEnum, this, eventParameters));
                break;
            case Events.ObjectRemoved:
                this.ObjectRemoved?.Invoke(this, new MediaDeviceEventArgs(eventEnum, this, eventParameters));
                break;
            case Events.ObjectUpdated:
                this.ObjectUpdated?.Invoke(this, new MediaDeviceEventArgs(eventEnum, this, eventParameters));
                break;
            case Events.DeviceReset:
                this.DeviceReset?.Invoke(this, new MediaDeviceEventArgs(eventEnum, this, eventParameters));
                break;
            case Events.DeviceCapabilitiesUpdated:
                this.DeviceCapabilitiesUpdated?.Invoke(this, new MediaDeviceEventArgs(eventEnum, this, eventParameters));
                break;
            case Events.StorageFormat:
                this.StorageFormat?.Invoke(this, new MediaDeviceEventArgs(eventEnum, this, eventParameters));
                break;
            case Events.ObjectTransferRequest:
                this.ObjectTransferRequest?.Invoke(this, new MediaDeviceEventArgs(eventEnum, this, eventParameters));
                break;
            case Events.DeviceRemoved:
                this.DeviceRemoved?.Invoke(this, new MediaDeviceEventArgs(eventEnum, this, eventParameters));
                break;
            case Events.ServiceMethodComplete:
                this.ServiceMethodComplete?.Invoke(this, new MediaDeviceEventArgs(eventEnum, this, eventParameters));
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
            keys.Add(ref WPD.STORAGE_TYPE);
            keys.Add(ref WPD.STORAGE_FILE_SYSTEM_TYPE);
            keys.Add(ref WPD.STORAGE_CAPACITY);
            keys.Add(ref WPD.STORAGE_FREE_SPACE_IN_BYTES);
            keys.Add(ref WPD.STORAGE_FREE_SPACE_IN_OBJECTS);
            keys.Add(ref WPD.STORAGE_DESCRIPTION);
            keys.Add(ref WPD.STORAGE_SERIAL_NUMBER);
            keys.Add(ref WPD.STORAGE_MAX_OBJECT_SIZE);
            keys.Add(ref WPD.STORAGE_CAPACITY_IN_OBJECTS);
            keys.Add(ref WPD.STORAGE_ACCESS_CAPABILITY);

            try
            {
                MediaStorageInfo info = new MediaStorageInfo();

                this.deviceProperties.GetSupportedProperties(storageObjectId, out IPortableDeviceKeyCollection ppKeys);
                ComTrace.WriteObject(ppKeys);
                this.deviceProperties.GetValues(storageObjectId, keys, out IPortableDeviceValues values);
           
                values.TryGetUnsignedIntegerValue(WPD.STORAGE_TYPE, out uint type);
                info.Type = (StorageType)type;

                values.TryGetStringValue(WPD.STORAGE_FILE_SYSTEM_TYPE, out string fileSystemType);
                info.FileSystemType = fileSystemType;

                values.TryGetUnsignedLargeIntegerValue(WPD.STORAGE_CAPACITY, out ulong capacity);
                info.Capacity = capacity;

                values.TryGetUnsignedLargeIntegerValue(WPD.STORAGE_FREE_SPACE_IN_BYTES, out ulong freeBytes);
                info.FreeSpaceInBytes = freeBytes;

                values.TryGetUnsignedLargeIntegerValue(WPD.STORAGE_FREE_SPACE_IN_OBJECTS, out ulong freeObjects);
                info.FreeSpaceInObjects = freeObjects;

                values.TryGetStringValue(WPD.STORAGE_DESCRIPTION, out string description);
                info.Description = description;

                values.TryGetStringValue(WPD.STORAGE_SERIAL_NUMBER, out string serialNumber);
                info.SerialNumber = serialNumber;

                values.TryGetUnsignedLargeIntegerValue(WPD.STORAGE_MAX_OBJECT_SIZE, out ulong maxObjectSize);
                info.MaxObjectSize = maxObjectSize;

                values.TryGetUnsignedLargeIntegerValue(WPD.STORAGE_CAPACITY_IN_OBJECTS, out ulong capacityInObjects);
                info.CapacityInObjects = capacityInObjects;

                values.TryGetUnsignedIntegerValue(WPD.STORAGE_ACCESS_CAPABILITY, out uint accessCapability);
                info.AccessCapability = (StorageAccessCapability)accessCapability;

                return info;
            }
            catch (FileNotFoundException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return null;
        }

        #endregion

        #region MTP_EXT_VENDOR

        /// <summary>
        /// Queries for vendor extended operation code.
        /// </summary>
        /// <returns>List of vendor extended operation code.</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<int> VendorOpcodes()
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_GET_SUPPORTED_VENDOR_OPCODES);
            cmd.Send(this.device);
            var list = cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_VENDOR_OPERATION_CODES);
            return list.Select(p => p.ToInt());
        }

        /// <summary>
        /// Execute a vendor command.
        /// </summary>
        /// <param name="opCode">Operational code of the vendor command.</param>
        /// <param name="inputParams">Input parameters.</param>
        /// <param name="respCode">Response code</param>
        /// <returns>Output parameters</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<int> VendorExcecute(int opCode, IEnumerable<int> inputParams, out int respCode)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_EXECUTE_COMMAND_WITHOUT_DATA_PHASE);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_CODE, opCode);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_PARAMS, inputParams);
            cmd.Send(this.device);
            respCode = cmd.GetInt(WPD.PROPERTY_MTP_EXT_RESPONSE_CODE);
            return cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_RESPONSE_PARAMS).Select(p => p.ToInt());
        }

        /// <summary>
        /// Sends a MTP command block followed by a data phase with data from Device to Host.
        /// </summary>
        /// <param name="opCode">Operational code of the vendor command.</param>
        /// <param name="inputParams">Input parameters.</param>
        /// <returns>Returned as a context identifier for subsequent data transfer</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<int> VendorExcecuteRead(int opCode, IEnumerable<int> inputParams)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_READ);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_CODE, opCode);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_PARAMS, inputParams);
            cmd.Send(this.device);
            var list = cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_VENDOR_OPERATION_CODES).ToList();
            return list.Select(p => p.ToInt()); //.ToList();
        }

        /// <summary>
        /// Sends a MTP command block followed by a data phase with data from Host to Device 
        /// </summary>
        /// <param name="opCode">Operational code of the vendor command.</param>
        /// <param name="inputParams">Input parameters.</param>
        /// <returns>Returned as a context identifier for subsequent data transfer</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public IEnumerable<int> VendorExcecuteWrite(int opCode, IEnumerable<int> inputParams)
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_EXECUTE_COMMAND_WITH_DATA_TO_WRITE);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_CODE, opCode);
            cmd.Add(WPD.PROPERTY_MTP_EXT_OPERATION_PARAMS, inputParams);
            cmd.Send(this.device);
            var list = cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_VENDOR_OPERATION_CODES).ToList();
            return list.Select(p => p.ToInt()); //.ToList();
        }

        /*
        public IEnumerable<byte> VendorRead(string context, int bytesToRead, byte[] input, out int bytesRead)
        {
            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_READ_DATA);
            cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_CONTEXT, opCode);
            cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_NUM_BYTES_TO_READ, inputParams);
            cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_DATA, inputParams);
            cmd.Send(this.device);
            var list = cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_VENDOR_OPERATION_CODES).ToList();
            return list.Select(p => p.ToInt()).ToList();
        }

        public int VendorWrite(string context, int bytesToWrite, byte[] buffer )
        {
            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_WRITE_DATA);
            cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_CONTEXT, context);
            cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_NUM_BYTES_TO_WRITE, bytesToWrite);
            cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_DATA, buffer);
            cmd.Send(this.device);
            return cmd.GetInt(WPD.PROPERTY_MTP_EXT_TRANSFER_NUM_BYTES_WRITTEN);
        }

        public IEnumerable<int> VendorEndTransfer(string context, out int respCode)
        {
            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_END_DATA_TRANSFER);
            cmd.Add(WPD.PROPERTY_MTP_EXT_TRANSFER_CONTEXT, context);
            cmd.Send(this.device);
            respCode = cmd.GetInt(WPD.PROPERTY_MTP_EXT_RESPONSE_CODE);
            return cmd.GetPropVariants(WPD.PROPERTY_MTP_EXT_RESPONSE_PARAMS).Select(p => p.ToInt());
        }
        */

        /// <summary>
        /// Retrieves the vendor extension description string.
        /// </summary>
        /// <returns>Vendor extension description string</returns>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public string VendorExtentionDescription()
        {
            if (!this.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            Command cmd = Command.Create(WPD.COMMAND_MTP_EXT_GET_VENDOR_EXTENSION_DESCRIPTION);
            cmd.Send(this.device);
            string description = cmd.GetString(WPD.PROPERTY_MTP_EXT_VENDOR_EXTENSION_DESCRIPTION);
            return description;
        }

        #endregion

        #region Internal Methods
        
        internal static bool IsPath(string path)
        {
            return !string.IsNullOrWhiteSpace(path) && path.IndexOfAny(Path.GetInvalidPathChars()) < 0;
        }

        internal bool EqualsName(string a, string b)
        {
            return this.IsCaseSensitive ? a == b : string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
        }
        
        internal static string FilterToRegex(string filter)
        {
            if (filter == null || filter == "*" || filter == "*.*")
            {
                return null;
            }

            StringBuilder s = new StringBuilder(filter);
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
    }
}