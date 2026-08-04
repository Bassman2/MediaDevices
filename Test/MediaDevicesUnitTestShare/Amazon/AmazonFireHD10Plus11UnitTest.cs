namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Amazon")]
public class AmazonFireHD10Plus11UnitTest : WritableUnitTest
{
    public AmazonFireHD10Plus11UnitTest()
        : base("\\Speichergerät")
    {
        #region Device Tests

        // Device Properties Test
        deviceDescription = "Fire";
        deviceFriendlyName = "FireHD10Plus11";
        deviceManufacture = "Amazon";
        deviceFirmwareVersion = "1.0";
        deviceModel = "Fire";
        deviceSerialNumber = "G001MG0613460HLU";
        //this.deviceDeviceType = DeviceType.MediaPlayer;
        //this.deviceTransport = DeviceTransport.USB;
        //this.devicePowerSource = PowerSource.Battery;
        deviceSyncPartner = "";
        deviceSupportsNonConsumable = false;
        deviceDateTimeHasValue = false;
        deviceSupportedFormatsAreOrdered = null;

        // Capability Test
        //this.deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated];
        //this.deviceSupportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        //this.deviceSupportedContents = [ContentType.Image];
        //this.deviceFunctionalCategories = [FunctionalCategory.Storage];

        // ContentLocation Test
        this.deviceContentLocationsImages = []; // new List<string> { @"\Phone\Pictures", @"\Phone\Pictures", @"\SD card\Pictures" };

        // DriveTest
        this.deviceDrives = ["Speichergerät"];

        // Vendor Test
        deviceVendorOpcodes = [38337, 38338, 38339, 38340, 38341];
        deviceVendorExtentionDescription = "microsoft.com: 1.0; android.com: 1.0;";


        #endregion

        #region Readonly Tests

        // file
        readonlyFilePath = @"\Speichergerät\Test_ReadonlyFile\Pictures\Sundown.jpg";
        readonlyFileLength = 3675020ul;
        readonlyFileLastWriteTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFileAttributes = MediaFileAttributes.Normal | MediaFileAttributes.CanDelete;

        readonlyFileParentPath = @"\Speichergerät\Test_ReadonlyFile\Pictures";
        readonlyFileParentLastWriteTime = new DateTime(2026, 08, 03, 19, 24, 13);
        readonlyFileParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        // folder 
        readonlyFolderPath = @"\Speichergerät\Test_ReadonlyFile\Pictures";
        readonlyFolderLastWriteTime = new DateTime(2026, 08, 03, 19, 24, 13);
        readonlyFolderAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        readonlyFolderParentPath = @"\Speichergerät\Test_ReadonlyFile";
        readonlyFolderParentLastWriteTime = new DateTime(2026, 08, 03, 19, 24, 13);
        readonlyFolderParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        readonlyFileDownloadIcon = false;
        readonlyFileDownloadThumbnail = true;

        #endregion
    }
}