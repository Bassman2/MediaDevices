namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Asus")]
public class Nexus7UnitTest : WritableUnitTest
{
    public Nexus7UnitTest()
    {
        // Device Test
        this.deviceDescription = "Nexus 7";
        this.deviceFriendlyName = "My Nexus 7";
        this.deviceManufacture = "asus";
        this.deviceFirmwareVersion = "1.0";
        this.deviceModel = "Nexus 7";
        this.deviceSerialNumber = "09ecf73a";
        this.deviceDeviceType = DeviceType.MediaPlayer;
        this.deviceTransport = DeviceTransport.USB;
        this.devicePowerSource = PowerSource.Battery;

        // Capability Test
        this.supportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.ObjectAdded];
        this.supportedCommands = [Commands.ObjectEnumerationStartFind, Commands.ObjectManagementDeleteObjects];
        this.supportedContents = [ContentType.Image, ContentType.Audio, ContentType.Playlist, ContentType.Video, ContentType.Document, ContentType.Unspecified, ContentType.Folder];

        // ContentLocation Test
        this.contentLocations = [@"\SD card\Pictures", @"\Phone\Pictures", @"\SD card\Pictures"];


        this.workingFolder = @"\Internal storage\Download";

        // Exists Test
        //this.existingFile = @"\Internal storage\Ringtones\hangouts_message.ogg";

        

        //this.infoDirectoryName = "Ringtones";
        //this.infoDirectoryPath = @"\Internal storage\Ringtones";
        //this.infoDirectoryCreationTime = null; 
        //this.infoDirectoryLastWriteTime = new DateTime(2015, 10, 06, 13, 41, 07);

        //this.infoDirectoryParentName = "Internal storage";
        //this.infoDirectoryParentPath = @"\Internal storage";
        //this.infoDirectoryParentCreationTime = null;
        //this.infoDirectoryParentLastWriteTime = null;

        //this.infoFileName = "hangouts_video_call.ogg";
        //this.infoFilePath = @"\Internal storage\Ringtones\hangouts_video_call.ogg";
        //this.readonlyFileLength = 70149ul;
        //this.readonlyFileCreationTime = null;
        //this.readonlyFileLastWriteTime = new DateTime(2015, 10, 06, 13, 34, 47);

        //this.infoFileParentName = "Ringtones";
        //this.infoFileParentPath = @"\Internal storage\Ringtones";
        //this.readonlyFolderCreationTime = null;
        //this.readonlyFolderLastWriteTime = new DateTime(2015, 10, 06, 13, 41, 07);

        //this.readonlyEnumPath = @"\Internal storage\Download\UnitTest";
        //this.readonlyEnumFolderSearchPattern = "x_*";
        //this.readonlyEnumFileSearchPattern = "p_*";
        //this.readonlyEnumItemSearchPattern = "x_*";

        //this.readonlyEnumFoldersAll = new List<string> { @"\Internal storage\Download\UnitTest\Sub", @"\Internal storage\Download\UnitTest\x_sub" };
        //this.readonlyEnumFoldersSearchPattern = new List<string> { @"\Internal storage\Download\UnitTest\x_sub" };

        //this.readonlyEnumFilesAll = new List<string> { @"\Internal storage\Download\UnitTest\p_03g.jpg", @"\Internal storage\Download\UnitTest\p-06g.jpg", @"\Internal storage\Download\UnitTest\x_12g.jpg", @"\Internal storage\Download\UnitTest\x_avatar.png" };
        //this.readonlyEnumFilesSearchPattern = new List<string> { @"\Internal storage\Download\UnitTest\p_03g.jpg" };
        //this.readonlyEnumFilesSearchPatternRecursive = new List<string> { @"\Internal storage\Download\UnitTest\p_03g.jpg", @"\Internal storage\Download\UnitTest\Sub\p_Android_x.jpg" };

        //this.readonlyEnumItemsAll = new List<string> { @"\Internal storage\Download\UnitTest\Sub", @"\Internal storage\Download\UnitTest\x_sub", @"\Internal storage\Download\UnitTest\p_03g.jpg", @"\Internal storage\Download\UnitTest\p-06g.jpg", @"\Internal storage\Download\UnitTest\x_12g.jpg", @"\Internal storage\Download\UnitTest\x_avatar.png" };
        //this.readonlyEnumItemsSearchPattern = new List<string> { @"\Internal storage\Download\UnitTest\x_12g.jpg", @"\Internal storage\Download\UnitTest\x_sub", @"\Internal storage\Download\UnitTest\x_avatar.png" };
        //this.readonlyEnumItemsSearchPatternRecursive = new List<string> { @"\Internal storage\Download\UnitTest\x_12g.jpg", @"\Internal storage\Download\UnitTest\x_sub", @"\Internal storage\Download\UnitTest\x_sub\x_5890017.png", @"\Internal storage\Download\UnitTest\x_avatar.png" };
    }
}
