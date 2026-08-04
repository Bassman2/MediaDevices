using static System.Net.Mime.MediaTypeNames;

namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Google")]
public class GooglePixel6aUnitTest : WritableUnitTest
{
    public GooglePixel6aUnitTest()
        : base("")
    {
        // Device Select
        this.deviceSelect = device => device.Description == this.deviceDescription;

        // Ignore tests
        //this.ignoreTests = Ignore.DownloadIcon;

        #region Device Tests

        // Device Properties Test
        deviceDescription = "Pixel 6a";
        deviceFriendlyName = "Pixel 6a";
        deviceManufacture = "Google";
        deviceSyncPartner = "";         // TODO check for NULL
        deviceFirmwareVersion = "1.0";
        deviceModel = "Pixel 6a";
        deviceSerialNumber = "B165F4325D7024A91DA6E32BD7DFDCF4";
        deviceDeviceType = DeviceType.Phone;
        //this.deviceTransport = DeviceTransport.USB;
        //this.devicePowerSource = PowerSource.Battery;
        //this.deviceProtocol = "MTP: 1.00";
        deviceSupportsNonConsumable = false;
        deviceDateTimeHasValue = false;
        deviceSupportedFormatsAreOrdered = null;

        // Capability Test
        //this.deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.ObjectAdded];
        //this.deviceSupportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        //this.deviceSupportedContents = [ContentType.Image];
        //this.deviceFunctionalCategories = [FunctionalCategory.Storage, FunctionalCategory.RenderingInformation];

        // ContentLocation Test
        this.deviceContentLocationsImages = [];

        // Drive Test
        deviceDrives = ["Interner gemeinsamer Speicher"];

        // Vendor Test
        deviceVendorOpcodes = [38337, 38338, 38339, 38340, 38341];
        deviceVendorExtentionDescription = "microsoft.com: 1.0; android.com: 1.0;";

        #endregion

        #region Readonly Tests

        // Exists Test
        //this.existingFile = @"\Phone\Music\Artist\05 - Decoupage.mp3";

        //this.infoDirectoryName = "Pictures";
        //this.infoDirectoryPath = @"\SD card\Pictures";
        //this.infoDirectoryCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
        //this.infoDirectoryLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

        //this.infoDirectoryParentName = "SD card";
        //this.infoDirectoryParentPath = @"\SD card";
        //this.infoDirectoryParentCreationTime = null;
        //this.infoDirectoryParentLastWriteTime = null;

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

        #region WriteableTests

        writeableWorkingFolder = "\\Interner gemeinsamer Speicher\\Test";

        #endregion
    }
}
