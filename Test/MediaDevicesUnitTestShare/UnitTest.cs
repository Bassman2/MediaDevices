namespace MediaDevicesUnitTest;

public abstract class UnitTest
{
    public enum DateMode { NotSupported, FileTime, Now }


    [Flags]
    public enum Ignore : ulong
    {
        None = 0,
        FriendlyName = 1,
    }

    protected MediaDeviceManager manager = MediaDeviceManager.Instance;

    // Device Select
    protected Func<MediaDevice, bool>? deviceSelect;
   
    // Ignore tests
    protected Ignore ignoreTests = Ignore.None;


    // Device Properties Test
    protected string? deviceDescription = null;
    protected string? deviceFriendlyName = null;
    protected string? deviceManufacture = null;

    protected string? deviceName = null;

    protected string? deviceSyncPartner = null;                                     // SamsungA40: "Longhorn Sync Engine"
    protected string? deviceFirmwareVersion = null;
    protected const bool devicePowerLevelHasValue = true;
    protected PowerSource? devicePowerSource = PowerSource.Battery;                 // TascamDR40 & PhilipsUFD: External
    protected string? deviceProtocol = "MTP: 1.00";                                 // PhilipsUFD & TascamDR40: "MSC:", CanonEos60D: "MTP: 2.00"
    protected string? deviceModel = null;
    protected string? deviceSerialNumber = null;
    protected bool? deviceSupportsNonConsumable = false;                            // PhilipsUFD & TascamDR40: null
    protected bool deviceDateTimeHasValue = false;                                  // NiconCoolpixA300 = true
    protected readonly string[]? deviceSupportedDrmSchemes = null;
    protected readonly bool? deviceSupportedFormatsAreOrdered = null;
    protected DeviceType? deviceDeviceType = DeviceType.Generic;
    protected DeviceTransport? deviceTransport = DeviceTransport.USB;               // PhilipsUFD & TascamDR40: null
    protected DeviceTransport? deviceUseDeviceStage = null;                         // CanonEosR6m2, NiconCoolpixA300 & CanonEos60D: USB

#if DEBUG
    protected const string deviceId = "DEVICE";
    protected const string deviceParentId = "";
    protected const ContentType deviceContentType = ContentType.FunctionalObject;
    protected const string devicePersistentUniqueId = "DEVICE";
    protected const ObjectFormat deviceObjectFormat = ObjectFormat.PropertiesOnly;

    protected bool? deviceIsHidden = null;                                          // PhilipsUFD & TascamDR40: true
    protected const bool deviceCanDelete = false;
    protected string? deviceContainerFunctionalObjectId = "DEVICE";                 // PhilipsUFD & TascamDR40: null
    protected const FunctionalCategory deviceFunctionalObjectCategory = FunctionalCategory.Device;

    protected readonly ulong? deviceNetworkIdentifier = null;
    protected readonly uint? deviceFunctionalUniqueId = null;
    protected readonly uint? deviceModelUniqueId = null;

    protected const string? deviceEdpItentifier = null;
#endif

    // Device Capability Test
    protected List<Events>? deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated];
    protected List<Commands>? deviceSupportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
    protected List<ContentType>? deviceSupportedContents = [ContentType.Image];
    protected List<FunctionalCategory>? deviceFunctionalCategories = [FunctionalCategory.Storage];

    // Device ContentLocation Test
    protected List<string> deviceContentLocationsImages = [];
    protected List<string> deviceContentLocationsVideos = [];
    protected List<string> deviceContentLocationsAudios = [];
    protected List<string> deviceContentLocationsContacts = [];
    protected List<string> deviceContentLocationsCalendars = [];
    protected List<string> deviceContentLocationsAll = [];

    // Device Drive Test
    protected List<string> deviceDrives = [];

    // Device File Dates Test
    protected DateMode deviceCreationTimeMode = DateMode.NotSupported;
    protected DateMode deviceLastWriteTimeMode = DateMode.NotSupported;
    protected DateMode deviceDateAuthoredMode = DateMode.NotSupported;

    // Device Vendor Test
    protected List<uint>? deviceVendorOpcodes = null;
    protected string? deviceVendorExtentionDescription = null;

    //public TestContext TestContext { get; set; }

    ///// <summary>
    ///// Gets or sets the test context which provides information about and functionality for the current test run.
    /////</summary>
    //public TestContext TestContext
    //{
    //    get { return testContextInstance; }
    //    set { testContextInstance = value; }
    //}

    public UnitTest()
    {
        this.deviceSelect = d => d.Description == this.deviceDescription && d.Manufacturer == this.deviceManufacture;
    }

    [TestInitialize]
    public void TestInitialize()
    {
        if (this.ignoreTests.HasFlag(Ignore.FriendlyName)) return;

        var device = GetDevice();
        device.Connect();
        device.FriendlyName = this.deviceFriendlyName;
        string? friendlyName = device.FriendlyName;
        device.Disconnect();

        Assert.AreEqual(this.deviceFriendlyName, friendlyName, "friendlyName");
    }

    [TestCleanup]
    public void TestCleanup()
    {
    }

    protected void CheckIgnoreTest(Ignore ignore)
    {
        if (this.ignoreTests.HasFlag(ignore))
        {
            Assert.Inconclusive();
        }
    }
   

    //protected void FindDeviceLetter(string pnpDeviceId)
    //{
    //    foreach (ManagementObject mediaDevice in new ManagementObjectSearcher(@"SELECT * FROM Win32_DiskDrive WHERE InterfaceType LIKE 'USB%'").Get())
    //    {
    //        string s1 = ((string)mediaDevice.GetPropertyValue("DeviceID"));
    //        string s2 = ((string)mediaDevice.GetPropertyValue("PNPDeviceID"));


    //        foreach (ManagementObject partition in new ManagementObjectSearcher(
    //            "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + mediaDevice.Properties["DeviceID"].Value
    //            + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition").Get())
    //        {
    //            foreach (ManagementObject disk in new ManagementObjectSearcher(
    //                        "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='"
    //                            + partition["DeviceID"]
    //                            + "'} WHERE AssocClass = Win32_LogicalDiskToPartition").Get())
    //            {
    //                string s3 = ("Drive letter " + disk["Name"]);
    //            }
    //        }
    //    }
    //}

    protected MediaDevice GetDevice()
    {
        Assert.IsNotNull(manager, "Manager");
        var devices = manager.GetDevices()?.ToArray();
        var device = devices?.FirstOrDefault(this.deviceSelect!);
        Assert.IsNotNull(device, "Device");
        return device ?? throw new InvalidOperationException("Device not found");
    }

    #region Device Tests

    [TestMethod]
    [Description("Device connect and desconnect test")]
    public void DeviceConnectTest()
    {
        var device = GetDevice();

        bool connected1 = device.IsConnected;
        device.Connect();
        bool connected2 = device.IsConnected;
        device.Disconnect();
        bool connected3 = device.IsConnected;
        device.Connect();
        bool connected4 = device.IsConnected;
        device.Disconnect();
        bool connected5 = device.IsConnected;

        Assert.IsFalse(connected1, nameof(connected1));
        Assert.IsTrue(connected2, nameof(connected2));
        Assert.IsFalse(connected3, nameof(connected3));
        Assert.IsTrue(connected4, nameof(connected4));
        Assert.IsFalse(connected5, nameof(connected5));
    }

    [TestMethod]
    [Description("Device properties tests")]
    public void DevicePropertiesTest()
    {
        var device = GetDevice();

        string? description = device.Description;
        string? friendlyName = device.FriendlyName;
        string? manufacture1 = device.Manufacturer;

        device.Connect();
        string? name = device.Name;
        string? syncPartner = device.SyncPartner;
        string? firmwareVersion = device.FirmwareVersion;
        uint? powerLevel = device.PowerLevel ?? 0;
        PowerSource? powerSource = device.PowerSource;
        string? protocol = device.Protocol;
        string? manufacture2 = device.Manufacturer;
        string? model = device.Model;
        string? serialNumber = device.SerialNumber;
        bool? supportsNonConsumable = device.SupportsNonConsumable;
        DateTime? dateTime = device.DateTime;
        string[]? supportedDrmSchemes = device.SupportedDrmSchemes;
        bool? supportedFormatsAreOrdered = device.SupportedFormatsAreOrdered;
        DeviceType? deviceType = device.DeviceType;
        DeviceTransport? transport = device.Transport;
        DeviceTransport? useDeviceStage = device.UseDeviceStage;
#if DEBUG
        string? id = device.Id;
        string? parentId = device.ParentId;
        ContentType? contentType = device.ContentType;
        string? persistentUniqueId = device.PersistentUniqueId;
        ObjectFormat? objectFormat = device.ObjectFormat;
        bool? isHidden = device.IsHidden;
        bool? canDelete = device.CanDelete;
        string? containerFunctionalObjectId = device.ContainerFunctionalObjectId;
        FunctionalCategory? functionalObjectCategory = device.FunctionalObjectCategory;
        ulong? networkIdentifier = device.NetworkIdentifier;
        uint? functionalUniqueId = device.FunctionalUniqueId;
        uint? modelUniqueId = device.ModelUniqueId;
        string? edpItentifier = device.EdpItentifier;
#endif
        device.Disconnect();

        Assert.AreEqual(deviceDescription, description, nameof(deviceDescription));
        Assert.AreEqual(deviceFriendlyName, friendlyName, nameof(deviceFriendlyName));
        Assert.AreEqual(deviceManufacture, manufacture1, nameof(deviceManufacture) + " 1");
        Assert.AreEqual(deviceName, name, nameof(deviceName));
        Assert.AreEqual(deviceSyncPartner, syncPartner, nameof(deviceSyncPartner));
        Assert.AreEqual(deviceFirmwareVersion, firmwareVersion, nameof(deviceFirmwareVersion));
        Assert.AreEqual(devicePowerLevelHasValue, powerLevel.HasValue, nameof(devicePowerLevelHasValue)); // value changes
        Assert.AreEqual(devicePowerSource, powerSource, nameof(devicePowerSource));
        Assert.AreEqual(deviceProtocol, protocol, nameof(deviceProtocol));
        Assert.AreEqual(deviceManufacture, manufacture2, nameof(deviceManufacture) + " 2");
        Assert.AreEqual(deviceModel, model, nameof(deviceModel));
        Assert.AreEqual(deviceSerialNumber, serialNumber, nameof(deviceSerialNumber));
        Assert.AreEqual(deviceSupportsNonConsumable, supportsNonConsumable, nameof(deviceSupportsNonConsumable));
        Assert.AreEqual(deviceDateTimeHasValue, dateTime.HasValue, nameof(deviceDateTimeHasValue));    // value changes
        Assert.AreSequenceEqual(deviceSupportedDrmSchemes, supportedDrmSchemes, SequenceOrder.InAnyOrder, nameof(deviceSupportedDrmSchemes));
        Assert.AreEqual(deviceSupportedFormatsAreOrdered, supportedFormatsAreOrdered, nameof(deviceSupportedFormatsAreOrdered));
        Assert.AreEqual(deviceDeviceType, deviceType, nameof(deviceDeviceType));
        Assert.AreEqual(deviceTransport, transport, nameof(deviceTransport));
        Assert.AreEqual(deviceUseDeviceStage, useDeviceStage, nameof(deviceUseDeviceStage));
#if DEBUG
        Assert.AreEqual(deviceId, id, nameof(deviceId));
        Assert.AreEqual(deviceParentId, parentId, nameof(deviceParentId));
        Assert.AreEqual(deviceContentType, contentType, nameof(deviceContentType));
        Assert.AreEqual(devicePersistentUniqueId, persistentUniqueId, nameof(devicePersistentUniqueId));
        Assert.AreEqual(deviceObjectFormat, objectFormat, nameof(deviceObjectFormat));
        Assert.AreEqual(deviceIsHidden, isHidden, nameof(deviceIsHidden));
        Assert.AreEqual(deviceCanDelete, canDelete, nameof(deviceCanDelete));
        Assert.AreEqual(deviceContainerFunctionalObjectId, containerFunctionalObjectId, nameof(deviceContainerFunctionalObjectId));
        Assert.AreEqual(deviceFunctionalObjectCategory, functionalObjectCategory, nameof(deviceFunctionalObjectCategory));
        Assert.AreEqual(deviceNetworkIdentifier, networkIdentifier, nameof(deviceNetworkIdentifier));
        Assert.AreEqual(deviceFunctionalUniqueId, functionalUniqueId, nameof(deviceFunctionalUniqueId));
        Assert.AreEqual(deviceModelUniqueId, modelUniqueId, nameof(deviceModelUniqueId));
        Assert.AreEqual(deviceEdpItentifier, edpItentifier, nameof(deviceEdpItentifier));
#endif

        Trace.WriteLine($"DateTime: {dateTime}");
    }

    [TestMethod]
    [Description("Check mediaDevice compatibility informations.")]
    public void DeviceCapabilityTest()
    {
        var device = GetDevice();
        device.Connect();

        var events = device.SupportedEvents()?.ToList() ?? [];
        var commands = device.SupportedCommands()?.ToList() ?? [];
        var contents = device.SupportedContentTypes(FunctionalCategory.All)?.ToList() ?? [];
        var categories = device.FunctionalCategories()?.ToList() ?? [];

        var stillImageCaptureObjects = device.FunctionalObjects(FunctionalCategory.StillImageCapture)?.ToList();
        var storageObjects = device.FunctionalObjects(FunctionalCategory.Storage)?.ToList();
        var smsObjects = device.FunctionalObjects(FunctionalCategory.SMS)?.ToList();

        device.Disconnect();

        Assert.IsNotNull(stillImageCaptureObjects, "stillImageCaptureObjects");
        Assert.IsNotNull(storageObjects, "storageObjects");
        Assert.IsNotNull(smsObjects, "smsObjects");

        Assert.AreSequenceEqual(deviceSupportedEvents, events, SequenceOrder.InAnyOrder, nameof(deviceSupportedEvents));
        Assert.AreSequenceEqual(deviceSupportedCommands, commands, SequenceOrder.InAnyOrder, nameof(deviceSupportedCommands));
        Assert.AreSequenceEqual(deviceSupportedContents, contents, SequenceOrder.InAnyOrder, nameof(deviceSupportedContents));
        Assert.AreSequenceEqual(deviceFunctionalCategories, categories, SequenceOrder.InAnyOrder, nameof(deviceFunctionalCategories));
    }



    [TestMethod]
    [Description("Check mediaDevice content locations functionality.")]
    public void DeviceContentLocationTest()
    {
        var device = GetDevice();
        device.Connect();
        var images = device.GetContentLocations(ContentType.Image)?.ToList() ?? [];
        var videos = device.GetContentLocations(ContentType.Video)?.ToList() ?? [];
        var audios = device.GetContentLocations(ContentType.Audio)?.ToList() ?? [];
        var contacts = device.GetContentLocations(ContentType.Contact)?.ToList() ?? [];
        var calendars = device.GetContentLocations(ContentType.Calendar)?.ToList() ?? [];
        var all = device.GetContentLocations(ContentType.All)?.ToList() ?? [];
        device.Disconnect();

        Assert.AreSequenceEqual(this.deviceContentLocationsImages, images, SequenceOrder.InAnyOrder, nameof(deviceContentLocationsImages));
        Assert.AreSequenceEqual(this.deviceContentLocationsVideos, videos, SequenceOrder.InAnyOrder, nameof(deviceContentLocationsVideos));
        Assert.AreSequenceEqual(this.deviceContentLocationsAudios, audios, SequenceOrder.InAnyOrder, nameof(deviceContentLocationsAudios));
        Assert.AreSequenceEqual(this.deviceContentLocationsContacts, contacts, SequenceOrder.InAnyOrder, nameof(deviceContentLocationsContacts));
        Assert.AreSequenceEqual(this.deviceContentLocationsCalendars, calendars, SequenceOrder.InAnyOrder, nameof(deviceContentLocationsCalendars));
        Assert.AreSequenceEqual(this.deviceContentLocationsAll, all, SequenceOrder.InAnyOrder, nameof(deviceContentLocationsAll));
    }

    [TestMethod]
    //[IgnoreFeature(IgnoreFeatures.FriendlyName)]
    [Description("Check persistent unique id functionality.")]
    public void DeviceFriendlyNameTest()
    {
        CheckIgnoreTest(Ignore.FriendlyName);
       
        var device = GetDevice();

        string? disconnectedFriendlyName = device.FriendlyName;

        device.Connect();

        string? connectedFriendlyName = device.FriendlyName;

        // some devices use only upper letters in friendly names
        device.FriendlyName = "DUMMY";

        string? dummyFriendlyName = device.FriendlyName;

        device.Disconnect();

        string? disconnectedDummyFriendlyName = device.FriendlyName;

        device.Connect();

        string? connectedDummyFriendlyName = device.FriendlyName;

        device.FriendlyName = connectedFriendlyName;

        device.Disconnect();


        Assert.AreEqual(this.deviceFriendlyName, disconnectedFriendlyName, "disconnectedFriendlyName");
        Assert.AreEqual(this.deviceFriendlyName, connectedFriendlyName, "connectedFriendlyName");
        Assert.AreEqual("DUMMY", dummyFriendlyName, "dummyFriendlyName");
        Assert.AreEqual("DUMMY", disconnectedDummyFriendlyName, "disconnectedDummyFriendlyName");
        Assert.AreEqual("DUMMY", connectedDummyFriendlyName, "connectedDummyFriendlyName");
    }
        
    [TestMethod]
    [Description("Drives test.")]
    public void DeviceDrivesTest()
    {
        var device = GetDevice();
        device.Connect();

        var drives = device.GetDrives().ToList();

        List<string> volumeLabels = drives?.Select(d => d.VolumeLabel ?? "").ToList() ?? [];
        
        device.Disconnect();

        Assert.AreSequenceEqual(this.deviceDrives, volumeLabels, SequenceOrder.InAnyOrder, nameof(volumeLabels));
    }

    [TestMethod]
    [Description("Disable cache test.")]
    public void DeviceDisableCacheTest()
    {
        var device = GetDevice();
        //device.Connect(enableCache: false);
        device.Connect( MediaDeviceAccess.Default, MediaDeviceShare.Default, false);

        var drives = device.GetDrives().ToList();

        List<string> volumeLabels = drives?.Select(d => d.VolumeLabel ?? "").ToList() ?? [];

        device.Disconnect();

        Assert.AreSequenceEqual(this.deviceDrives, volumeLabels, SequenceOrder.InAnyOrder, nameof(volumeLabels));
    }

#endregion

    #region Service Tests

    [TestMethod]
    [Description("GetServices")]
    public void ServiceGetServicesTest()
    {
        var device = GetDevice();
        device.Connect();
        var all = device.GetServices(MediaDeviceServices.All)?.Select(s => s.Name).ToList();
        var contact = device.GetServices(MediaDeviceServices.Contact)?.Select(s => s.Name).ToList();
        var calendar = device.GetServices(MediaDeviceServices.Calendar)?.Select(s => s.Name).ToList();
        var notes = device.GetServices(MediaDeviceServices.Notes)?.Select(s => s.Name).ToList();
        var task = device.GetServices(MediaDeviceServices.Task)?.Select(s => s.Name).ToList();
        var status = device.GetServices(MediaDeviceServices.Status)?.Select(s => s.Name).ToList();
        var hints = device.GetServices(MediaDeviceServices.Hints)?.Select(s => s.Name).ToList();
        var metadata = device.GetServices(MediaDeviceServices.Metadata)?.Select(s => s.Name).ToList();
        var ringtone = device.GetServices(MediaDeviceServices.Ringtone)?.Select(s => s.Name).ToList();
        var enumerationSynchronization = device.GetServices(MediaDeviceServices.EnumerationSynchronization)?.Select(s => s.Name).ToList();
        var anchorSynchronization = device.GetServices(MediaDeviceServices.AnchorSynchronization)?.Select(s => s.Name).ToList();
        var apps = device.GetServices(MediaDeviceServices.Apps)?.Select(s => s.Name).ToList();
        var authentication = device.GetServices(MediaDeviceServices.Authentication)?.Select(s => s.Name).ToList();
        var wpdCompanionService = device.GetServices(MediaDeviceServices.WpdCompanionService)?.Select(s => s.Name).ToList();
        var mediaLibraryService = device.GetServices(MediaDeviceServices.MediaLibraryService)?.Select(s => s.Name).ToList();
        var mtpDuDeviceService = device.GetServices(MediaDeviceServices.MtpDuDeviceService)?.Select(s => s.Name).ToList();
        var storageInfo = device.GetServices(MediaDeviceServices.StorageInfo)?.Select(s => s.Name).ToList();
        device.Disconnect();

        Assert.AreSequenceEqual([], all, SequenceOrder.InAnyOrder, "AllServices");
        Assert.AreSequenceEqual([], contact, SequenceOrder.InAnyOrder, "contact");
        Assert.AreSequenceEqual([], calendar, SequenceOrder.InAnyOrder, "calendar");
        Assert.AreSequenceEqual([], notes, SequenceOrder.InAnyOrder, "notes");
        Assert.AreSequenceEqual([], task, SequenceOrder.InAnyOrder, "task");
        Assert.AreSequenceEqual([], status, SequenceOrder.InAnyOrder, "status");
        Assert.AreSequenceEqual([], hints, SequenceOrder.InAnyOrder, "hints");
        Assert.AreSequenceEqual([], metadata, SequenceOrder.InAnyOrder, "metadata");
        Assert.AreSequenceEqual([], ringtone, SequenceOrder.InAnyOrder, "ringtone");
        Assert.AreSequenceEqual([], enumerationSynchronization, SequenceOrder.InAnyOrder, "enumerationSynchronization");
        Assert.AreSequenceEqual([], anchorSynchronization, SequenceOrder.InAnyOrder, "anchorSynchronization");
        Assert.AreSequenceEqual([], apps, SequenceOrder.InAnyOrder, "apps");
        Assert.AreSequenceEqual([], authentication, SequenceOrder.InAnyOrder, "authentication");
        Assert.AreSequenceEqual([], wpdCompanionService, SequenceOrder.InAnyOrder, "wpdCompanionService");
        Assert.AreSequenceEqual([], mediaLibraryService, SequenceOrder.InAnyOrder, "mediaLibraryService");
        Assert.AreSequenceEqual([], mtpDuDeviceService, SequenceOrder.InAnyOrder, "mtpDuDeviceService");
        Assert.AreSequenceEqual([], storageInfo, SequenceOrder.InAnyOrder, "storageInfo");
    }

    #endregion

    #region Vendor Tests

    [TestMethod]
    [Description("Vendor opcodes test.")]
    public void DeviceVendorOpcodesTest()
    {
        var device = GetDevice();
        device.Connect();

        var opcodes = device.VendorOpcodes().ToList();

        device.Disconnect();

        Assert.AreSequenceEqual(this.deviceVendorOpcodes, opcodes, SequenceOrder.InAnyOrder, nameof(deviceVendorOpcodes));
    }

    [TestMethod]
    [Description("Vendor extension description test.")]
    public void DeviceVendorExtentionDescriptionTest()
    {
        var device = GetDevice();
        device.Connect();

        var description = device.VendorExtentionDescription();

        device.Disconnect();

        if (deviceVendorExtentionDescription?.StartsWith('^') ?? false)
        {
            Assert.MatchesRegex(deviceVendorExtentionDescription, description, nameof(deviceVendorExtentionDescription));
        }
        else
        {
            Assert.AreEqual(deviceVendorExtentionDescription, description, nameof(deviceVendorExtentionDescription));
        }
    }

    #endregion

    #region Speed Tests

    [TestMethod]
    [Ignore("Takes too long for allday testing")]
    [Description("Speed test.")]
    public void SpeedTest()
    {
        var device = GetDevice();
        device.Connect();

        var root = device.GetRootDirectory();
        var stopwatch = Stopwatch.StartNew();

        var _ = root.EnumerateFileSystemInfos("*", SearchOption.AllDirectories).ToList();

        stopwatch.Stop();

        device.Disconnect();

        double milliseconds = ((double)stopwatch.ElapsedTicks / Stopwatch.Frequency) * 1000;

        Assert.AreEqual(0.0, milliseconds, "time");
    }

    #endregion
}
