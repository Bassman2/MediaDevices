namespace MediaDevicesUnitTest;

[TestClass]
[TestCategory("Canon")]
public class CanonEos60DUnitTest : CanonEosUnitTest
{
    public CanonEos60DUnitTest()
        : base("")
    {
        // Device Test
        deviceDescription = "Canon EOS 60D";
        deviceFriendlyName = "Canon EOS 60D";
        deviceManufacture = "Canon Inc.";

        deviceName = "Canon EOS 60D";

        deviceFirmwareVersion = "3-1.1.2";
        deviceProtocol = "MTP: 2.00";
        deviceModel = "Canon EOS 60D";
        deviceSerialNumber = "ff76057ad3e84a228e406f41cdd778a6";
        deviceDeviceType = DeviceType.Camera;
        deviceUseDeviceStage = DeviceTransport.USB;

        // Capability Test
        deviceSupportedEvents = [Events.DeviceReset, Events.ObjectRemoved, Events.ObjectUpdated, Events.StorageFormat, Events.Unknown, Events.ObjectTransferRequest, Events.ObjectAdded];
        deviceSupportedCommands = [
            Commands.ObjectEnumerationStartFind,
            Commands.ObjectManagementDeleteObjects,
            Commands.ObjectEnumerationFindNext,
            Commands.ObjectEnumerationEndFind,
            Commands.ObjectPropertiesGetSupported,
            Commands.ObjectPropertiesGet,
            Commands.ObjectPropertiesGetAll,
            Commands.ObjectPropertiesGetAttribute,
            Commands.ObjectResourcesGetSupported,
            Commands.ObjectResourcesGetAttributes,
            Commands.ObjectResourcesOpen,
            Commands.ObjectResourcesRead,
            Commands.ObjectResourcesClose,
            Commands.CapabilitiesGetSupportedCommands,
            Commands.CapabilitiesGetCommandOptions,
            Commands.CapabilitiesGetSupportedFunctionalCategories,
            Commands.CapabilitiesGetFunctionalObjects,
            Commands.CapabilitiesGetSupportedContentTypes,
            Commands.CapabilitiesGetSupportedFormats,
            Commands.CapabilitiesGetSupportedFormatProperties,
            Commands.CapabilitiesGetFixedPropertyAttributes,
            Commands.CapabilitiesGetSupportedEvents,
            Commands.CapabilitiesGetEventOptions,
            Commands.MtpExtVendorGetSupportedVendorOpcodes,
            Commands.MtpExtVendorGetVendorExtensionDescription,
            Commands.MtpExtVendorExecuteCommandWithoutDataPhase,
            Commands.MtpExtVendorExecuteCommandWithDataToRead,
            Commands.MtpExtVendorExecuteCommandWithDataToWrite,
            Commands.MtpExtVendorReadData,
            Commands.MtpExtVendorWriteData,
            Commands.MtpExtVendorEndDataTransfer,
            Commands.Unknown,
            Commands.Unknown,
            Commands.ObjectManagementCreateObjectWithPropertiesOnly,
            Commands.ObjectManagementCreateObjectWithPropertiesAndData,
            Commands.ObjectManagementWriteObjectData,
            Commands.ObjectManagementCommitObject,
            Commands.ObjectManagementRevertObject,
            Commands.ObjectPropertiesSet,
            Commands.StorageFormat,
            Commands.ObjectPropertiesBulkGetValuesByObjectListStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectListNext,
            Commands.ObjectPropertiesBulkGetValuesByObjectListEnd,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatStart,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatNext,
            Commands.ObjectPropertiesBulkGetValuesByObjectFormatEnd,
            Commands.GenerateKeypair,
            Commands.CommitKeypair];
        deviceSupportedContents = [ContentType.Image, ContentType.Audio, ContentType.Video, ContentType.Document, ContentType.Unspecified, ContentType.Folder, ContentType.Certificate, ContentType.WirelessProfile];

        // ContentLocation Test
        deviceContentLocationsImages = [];


        // Exists Test
        this.readonlyFilePath = @"\SD\DCIM\100CANON\IMG_2568.JPG";


        //this.infoDirectoryName = "DCIM";
        //this.infoDirectoryPath = @"\Internal Storage\DCIM";
        //this.infoDirectoryCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        //this.infoDirectoryLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        //this.infoDirectoryParentName = "Internal Storage";
        //this.infoDirectoryParentPath = @"\Internal Storage";
        //this.infoDirectoryParentCreationTime = null;
        //this.infoDirectoryParentLastWriteTime = null;

        //this.infoFilePath = @"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG";
        this.readonlyFileLength = 467430ul;
        this.readonlyFileCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.readonlyFileLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        //this.infoFileParentName = "800AAAAA";
        //this.infoFileParentPath = @"\Internal Storage\DCIM\800AAAAA";
        this.readonlyFolderCreationTime = new DateTime(2000, 1, 27, 19, 47, 54);
        this.readonlyFolderLastWriteTime = new DateTime(2000, 1, 27, 19, 47, 54);

        this.readonlyEnumPath = @"\Internal Storage\DCIM\800AAAAA";
        this.readonlyEnumSearchPatternFolders = "*";
        this.readonlyEnumSearchPatternFiles = "*_0002*";
        this.readonlyEnumSearchPatternItems = "*_0003*";

        this.readonlyEnumFolders = [];
        this.readonlyEnumFoldersSearchPattern = [];

        this.readonlyEnumFiles = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumFilesSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];
        this.readonlyEnumFilesSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG"];

        this.readonlyEnumItems = [@"\Internal Storage\DCIM\800AAAAA\IMG_0001.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0002.JPG", @"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumItemsSearchPattern = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];
        this.readonlyEnumItemsSearchPatternRecursive = [@"\Internal Storage\DCIM\800AAAAA\IMG_0003.JPG"];

        deviceVendorOpcodes = [
            OpCodesCanon.EOS_CancelTransferDT,
            OpCodesCanon.EOS_ClickWB,
            OpCodesCanon.EOS_Zoom,
            OpCodesCanon.EOS_ZoomPosition,
            OpCodesCanon.EOS_SetLiveAfFrame,
            OpCodesCanon.EOS_ExecuteEventProc,
            OpCodesCanon.EOS_GetEventProcResult,
            OpCodesCanon.EOS_RequestDevicePropValue, 
            OpCodesCanon.EOS_RemoteReleaseOn,
            OpCodesCanon.EOS_RemoteReleaseOff, 
            OpCodesCanon.EOS_FAPIMessageTX,
            OpCodesCanon.EOS_GetEventProcList, 
            OpCodesCanon.EOS_ChangePhotoStudioMode,
            OpCodesCanon.EOS_FAPIMessageRX,
            OpCodesCanon.EOS_AfCancel,
            OpCodesCanon.EOS_ExecuteEventProcAsync,
            OpCodesCanon.EOS_GetPartialObjectEx,
            OpCodesCanon.EOS_GetEventProcActiveList, 
            OpCodesCanon.EOS_ReSizeImageData, 
            OpCodesCanon.EOS_TerminateEventProc, 
            OpCodesCanon.EOS_GetReSizeData, 
            OpCodesCanon.EOS_ReleaseReSizeData,
            OpCodesCanon.EOS_ResetMirrorLockupState, 
            OpCodesCanon.EOS_InitiateGetPartialObjectEx, 
            OpCodesCanon.EOS_EndGetPartialObjectEx, 
            OpCodesCanon.EOS_GetCounterValues,
            OpCodesCanon.EOS_MovieSelectSWOn, 
            OpCodesCanon.EOS_MovieSelectSWOff, 
            OpCodesCanon.EOS_InitiateGetViewfinderData,
            OpCodesCanon.EOS_TerminateGetViewfinderData,
            OpCodesCanon.EOS_InitiateGetViewfinderDataEx, 
            OpCodesCanon.EOS_SetObjectTime, 
            OpCodesCanon.EOS_TransferComplete, 
            OpCodesCanon.EOS_CancelTransfer,
            OpCodesCanon.EOS_PCHDDCapacity, 
            OpCodesCanon.EOS_SetUILock, 
            OpCodesCanon.EOS_TransferComplete2,
            OpCodesCanon.EOS_CancelTransfer2, 
            OpCodesCanon.EOS_SetNullEventMode, 
            OpCodesCanon.EOS_SetDisplayMonitor,
            OpCodesCanon.EOS_GetStorageIDs,
            OpCodesCanon.EOS_GetStorageInfo, 
            OpCodesCanon.EOS_GetObjectInfo,
            OpCodesCanon.EOS_GetObject,
            OpCodesCanon.EOS_DeleteObject,
            OpCodesCanon.EOS_FormatStore,
            OpCodesCanon.EOS_GetPartialObject,
            OpCodesCanon.EOS_GetDeviceInfoEx,
            OpCodesCanon.EOS_GetObjectInfoEx, 
            OpCodesCanon.EOS_GetThumbEx,
            OpCodesCanon.EOS_SendPartialObject, 
            OpCodesCanon.EOS_SetObjectAttributes,
            OpCodesCanon.EOS_RemoteRelease,
            OpCodesCanon.EOS_SetDevicePropValueEx, 
            OpCodesCanon.EOS_GetRemoteMode,
            OpCodesCanon.EOS_SetRemoteMode,
            OpCodesCanon.EOS_SetEventMode,
            OpCodesCanon.EOS_GetEvent,
            OpCodesCanon.EOS_ResetUILock,
            OpCodesCanon.EOS_KeepDeviceOn,
            OpCodesCanon.EOS_DoAf,
            OpCodesCanon.EOS_DriveLens,
            OpCodesCanon.EOS_TransferCompleteDT,
            OpCodesCanon.EOS_GetViewFinderDat];
        deviceVendorExtentionDescription = "";
    }
}
