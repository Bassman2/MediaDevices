namespace MediaDevices;

public enum OperationCodes : ushort
{

    GetDeviceInfo = 0x1001,
    OpenSession = 0x1002,
    CloseSession = 0x1003,

    GetStorageIDs = 0x1004,

    SendObjectInfo = 0x100C,
    SendObject = 0x100D
}
