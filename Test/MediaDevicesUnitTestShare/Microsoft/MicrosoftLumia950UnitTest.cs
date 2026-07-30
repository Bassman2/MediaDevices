namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Microsoft")]
public class MicrosoftLumia950UnitTest : WritableUnitTest
{
    public MicrosoftLumia950UnitTest()
    {
        // Device Test
        this.deviceDescription = "Lumia 950";
        this.deviceFriendlyName = "";
        this.deviceManufacture = "Microsoft";
        this.deviceFirmwareVersion = "10.0.15254.0";
        this.deviceModel = "Lumia 650 Dual SIM";
        this.deviceSerialNumber = "9aaa36ebd8901685d39337ced4b30893";
        this.deviceDeviceType = DeviceType.Phone;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.Battery;

        // Capability Test
        this.supportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated];
        this.supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.supportedContents = [ContentType.Image];
        this.functionalCategories = [FunctionalCategory.Storage, FunctionalCategory.RenderingInformation];

        // ContentLocation Test
        this.contentLocations = [@"\Phone\Pictures", @"\Phone\Pictures", @"\SD card\Pictures"];

        this.workingFolder = @"\Phone\Documents";

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
        //this.readonlyTestFileLength = 232663ul;
        //this.readonlyTestFileCreationTime = new DateTime(2015, 01, 30, 22, 47, 17);
        //this.readonlyTestFileLastWriteTime = new DateTime(2015, 01, 30, 22, 47, 22);

        //this.infoFileParentName = "Pictures";
        //this.infoFileParentPath = @"\SD card\Pictures";
        //this.readonlyTestFolderCreationTime = new DateTime(2014, 03, 21, 19, 02, 04);
        //this.readonlyTestFolderLastWriteTime = new DateTime(2017, 01, 07, 16, 54, 38);

        //this.readonlyTestEnumPath = @"\Phone\Pictures";
        //this.readonlyTestEnumFolderSearchPattern = "S*";
        //this.readonlyTestEnumFileSearchPattern = "desk*";
        //this.readonlyTestEnumItemSearchPattern = "*es*";

        //this.readonlyTestEnumFoldersAll = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };
        //this.readonlyTestEnumFoldersSearchPattern = new List<string> { @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp" };

        //this.readonlyTestEnumFilesAll = new List<string> { @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyTestEnumFilesSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini" };
        //this.readonlyTestEnumFilesSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Saved Pictures\desktop.ini" };

        //this.readonlyTestEnumItemsAll = new List<string> { @"\Phone\Pictures\Camera Roll", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Screenshots", @"\Phone\Pictures\WhatsApp", @"\Phone\Pictures\bs.jpg", @"\Phone\Pictures\desktop.ini" };
        //this.readonlyTestEnumItemsSearchPattern = new List<string> { @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures" };
        //this.readonlyTestEnumItemsSearchPatternRecursive = new List<string> { @"\Phone\Pictures\Camera Roll\desktop.ini", @"\Phone\Pictures\desktop.ini", @"\Phone\Pictures\Sample Pictures", @"\Phone\Pictures\Saved Pictures", @"\Phone\Pictures\Saved Pictures\desktop.ini" };
    }
}
