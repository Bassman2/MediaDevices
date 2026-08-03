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

        // PersistentUniqueId
        //this.FolderPersistentUniqueId = "{00000023-0001-0001-0000-000000000000}";
        //this.FolderPersistentUniqueIdPath = @"\Interner Speicher\Download";
        //this.FilePersistentUniqueId = "{0000002B-0001-0001-0000-000000000000}";
        //this.FilePersistentUniqueIdPath = @"\Interner Speicher\Android\data\com.amazon.ags.app\files\cardcache\version";

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
        readonlyFileCreationTime = null; // new DateTime(2026, 07, 23, 17, 20, 41);
        readonlyFileLastWriteTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFileAuthoredTime = null; // new DateTime(2024, 06, 25, 21, 53, 17);
        readonlyFileAttributes = MediaFileAttributes.Normal | MediaFileAttributes.CanDelete;

        readonlyFileParentPath = @"\Speichergerät\Test_ReadonlyFile\Pictures";
        readonlyFileParentCreationTime = null; // new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFileParentLastWriteTime = new DateTime(2026, 08, 03, 19, 24, 13);
        readonlyFileParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        // folder 
        readonlyFolderPath = @"\Speichergerät\Test_ReadonlyFile\Pictures";
        readonlyFolderCreationTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFolderLastWriteTime = new DateTime(2026, 07, 23, 17, 20, 33);
        readonlyFolderAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;

        readonlyFolderParentPath = @"\Speichergerät\Test_ReadonlyFile";
        readonlyFolderParentCreationTime = new DateTime(2026, 07, 23, 19, 06, 10);
        readonlyFolderParentLastWriteTime = new DateTime(2026, 07, 23, 19, 06, 10);
        readonlyFolderParentAttributes = MediaFileAttributes.Directory | MediaFileAttributes.CanDelete;


        // Writable Tests
        //this.writeableWorkingFolder = @"\Interner Speicher\tmp";


        //// Exists Test
        ////this.existingFile = @"\Interner Speicher\Download\14.jpg";

        //infoDirectoryName = "Pictures";
        //infoDirectoryPath = @"\SD card\Pictures";
        //infoDirectoryCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
        //infoDirectoryLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

        //infoDirectoryParentName = "SD card";
        //infoDirectoryParentPath = @"\SD card";
        //infoDirectoryParentCreationTime = null;
        //infoDirectoryParentLastWriteTime = null;

        //this.infoFileName = "Frank2.jpg";
        //this.infoFilePath = @"\SD card\Pictures\Frank2.jpg";
        //this.readonlyFileLength = 232663ul;
        //this.readonlyFileCreationTime = new DateTime(2015, 01, 30, 22, 47, 17);
        //this.readonlyFileLastWriteTime = new DateTime(2015, 01, 30, 22, 47, 22);

        //this.infoFileParentName = "Pictures";
        //this.infoFileParentPath = @"\SD card\Pictures";
        //this.readonlyFolderCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
        //this.readonlyFolderLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

        //this.readonlyEnumPath = @"\Phone\Pictures";
        //this.readonlyEnumSearchPatternFolders = "S*";
        //this.readonlyEnumSearchPatternFiles = "desk*";
        //this.readonlyEnumSearchPatternItems = "*es*";

        //this.readonlyEnumFolders = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };
        //this.readonlyEnumFoldersSearchPattern = new List<string> { @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };

        //this.readonlyEnumFiles = new List<string> { @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumFilesSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

        //this.readonlyEnumItems = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp", @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyEnumItemsSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures" };
        //this.readonlyEnumItemsSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

        #endregion

        //writeableWorkingFolder = @"\Speichergerät\Test_Writeable";
    }
}