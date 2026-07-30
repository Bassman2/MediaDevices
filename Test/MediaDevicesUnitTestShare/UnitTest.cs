namespace MediaDevicesUnitTest;

public abstract class UnitTest
{
    protected MediaDeviceManager manager = MediaDeviceManager.Instance;

    // Device Select
    protected Func<MediaDevice, bool>? deviceSelect;
   
    // Ignore tests
    protected Ignore ignoreTests = Ignore.None;
    
    // Device Properties Test
    protected string? deviceDescription;
    protected string? deviceFriendlyName;
    protected string? deviceManufacture;
    protected string? deviceSyncPartner;
    protected string? deviceFirmwareVersion;
    protected bool devicePowerLevelHasValue = true;
    protected PowerSource? devicePowerSource = PowerSource.Battery;
    protected string? deviceProtocol = "MTP: 1.00";
    protected string? deviceModel;
    protected string? deviceSerialNumber;
    protected bool? deviceSupportsNonConsumable = true;
    protected bool deviceDateTimeHasValue = true;
    protected bool? deviceSupportedFormatsAreOrdered = true;
    protected DeviceType deviceDeviceType = DeviceType.Generic;
    protected ulong? deviceNetworkIdentifier;
    // FunctionalUniqueId
    // ModelUniqueId
    protected DeviceTransport deviceTransport = DeviceTransport.USB;
    protected DeviceTransport? deviceUseDeviceStage;

    // Capability Test
    protected List<Events>? supportedEvents = [ Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated ];
    protected List<Commands>? supportedCommands = [ Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects ];
    protected List<ContentType>? supportedContents = [ ContentType.Image ];
    protected List<FunctionalCategory>? functionalCategories = [ FunctionalCategory.Storage ];

    // ContentLocation Test
    protected List<string>? contentLocations = [];

    // PersistentUniqueId
    protected string? FolderPersistentUniqueId;
    protected string? FolderPersistentUniqueIdPath;
    protected string? FilePersistentUniqueId;
    protected string? FilePersistentUniqueIdPath;

    protected List<string> drives = [];

    

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
        string? manufacture = device.Manufacturer;

        device.Connect();
        string? syncPartner = device.SyncPartner;
        string? firmwareVersion = device.FirmwareVersion;
        int? powerLevel = device.PowerLevel ?? 0;
        PowerSource? powerSource = device.PowerSource;
        string? protocol = device.Protocol;
        string? model = device.Model;
        string? serialNumber = device.SerialNumber;
        bool? supportsNonConsumable = device.SupportsNonConsumable;
        DateTime? dateTime = device.DateTime;
        bool? supportedFormatsAreOrdered = device.SupportedFormatsAreOrdered;
        DeviceType? deviceType = device.DeviceType;
        ulong? networkIdentifier = device.NetworkIdentifier;
        // FunctionalUniqueId
        // ModelUniqueId
        DeviceTransport? transport = device.Transport;
        DeviceTransport? useDeviceStage = device.UseDeviceStage;
        device.Disconnect();

        Assert.AreEqual(this.deviceDescription, description, "Description");
        Assert.AreEqual(this.deviceFriendlyName, friendlyName, "FriendlyName");
        Assert.AreEqual(this.deviceManufacture, manufacture, "Manufacture");


        Assert.AreEqual(this.deviceSyncPartner, syncPartner, "SyncPartner");
        Assert.AreEqual(this.deviceFirmwareVersion, firmwareVersion, "FirmwareVersion");
        Assert.AreEqual(this.devicePowerLevelHasValue, powerLevel.HasValue, "PowerLevel"); // value changes
        Assert.AreEqual(this.devicePowerSource, powerSource, "PowerSource");
        Assert.AreEqual(this.deviceProtocol, protocol, "Protocol");
        Assert.AreEqual(this.deviceModel, model, "Model");
        Assert.AreEqual(this.deviceSerialNumber, serialNumber, "SerialNumber");
        Assert.AreEqual(this.deviceSupportsNonConsumable, supportsNonConsumable, "SupportsNonConsumable");
        Assert.AreEqual(this.deviceDateTimeHasValue, dateTime.HasValue, "DateTime");    // value changes
        Assert.AreEqual(this.deviceSupportedFormatsAreOrdered, supportedFormatsAreOrdered, "SupportedFormatsAreOrdered");
        Assert.AreEqual(this.deviceDeviceType, deviceType, "DeviceType");
        Assert.AreEqual(this.deviceNetworkIdentifier, networkIdentifier, "NetworkIdentifier");
        // FunctionalUniqueId
        // ModelUniqueId
        Assert.AreEqual(this.deviceTransport, transport, "Transport");
        Assert.AreEqual(this.deviceUseDeviceStage, useDeviceStage, "UseDeviceStage");

        //Assert.IsGreaterThanOrEqualTo(0, powerLevel, "PowerLevel");
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

        CollectionAssert.IsSubsetOf(supportedEvents, events, "Events");
        CollectionAssert.IsSubsetOf(supportedCommands, commands, "Commands");
        CollectionAssert.IsSubsetOf(supportedContents, contents, "Contents");
        Assert.AreSequenceEqual(functionalCategories, categories, SequenceOrder.InAnyOrder, "Categories");
    }



    [TestMethod]
    [Description("Check mediaDevice content locations functionality.")]
    public void DeviceContentLocationTest()
    {
        var device = GetDevice();
        device.Connect();

        var locations = device.GetContentLocations(ContentType.Image)?.ToList() ?? [];

        //var all = mediaDevice.GetContentLocations(ContentType.All)?.ToList() ?? [];

        device.Disconnect();

        Assert.AreSequenceEqual(this.contentLocations, locations, SequenceOrder.InAnyOrder, "Locations");
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

        Assert.AreSequenceEqual(this.drives, volumeLabels, SequenceOrder.InAnyOrder, nameof(volumeLabels));
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

        Assert.AreSequenceEqual(this.drives, volumeLabels, SequenceOrder.InAnyOrder, nameof(volumeLabels));
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
