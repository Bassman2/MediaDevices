//namespace MediaDevices.AbstractionLayer;

//internal class MtpDeviceLinux : IMtpDevice
//{
//    private MtpDeviceContext? _context;
//    private readonly LibUsbDotNet.Main.UsbRegistry _usbRegistry;

//    public string DeviceId => $"{_usbRegistry.Vid:X4}:{_usbRegistry.Pid:X4}:{_usbRegistry.SymbolicName}";
//    public string FriendlyName => _usbRegistry.Name;
//    public string Manufacturer => "Generic PTP/MTP Device";

//    public UnixMtpDevice(LibUsbDotNet.Main.UsbRegistry usbRegistry)
//    {
//        _usbRegistry = usbRegistry;
//    }

//    public void Connect()
//    {
//        if (!_usbRegistry.Open(out var device))
//            throw new IOException("Failed to claim native USB hardware interface context.");

//        _context = new MtpDeviceContext(device);
//        _context.OpenSession(sessionId: 1);
//    }

//    public List<string> GetStorageIds()
//    {
//        if (_context == null) throw new InvalidOperationException("Device not connected.");

//        // Map 0x1004 GetStorageIDs command
//        _context.ExecuteTransaction(PtpOperationCode.GetStorageIDs, null, out byte[]? data, out PtpResponseCode resp);
//        if (resp != PtpResponseCode.OK || data == null) return new List<string>();

//        // Parse PTP Array structure (First 4 bytes = element count)
//        uint count = BitConverter.ToUInt32(data, 0);
//        var list = new List<string>();
//        for (int i = 0; i < count; i++)
//        {
//            uint storageId = BitConverter.ToUInt32(data, 4 + (i * 4));
//            list.Add($"0x{storageId:X8}");
//        }
//        return list;
//    }

//    public List<MtpObjectInfo> GetChildren(string parentObjectId)
//    {
//        if (_context == null) throw new InvalidOperationException("Device not connected.");

//        uint parentId = parentObjectId == "/" ? 0xFFFFFFFF : Convert.ToUInt32(parentObjectId, 16);
//        uint[] parameters = new uint[] { 0xFFFFFFFF, 0, parentId }; // All storages, all formats

//        // Map 0x1007 GetObjectHandles command
//        _context.ExecuteTransaction(PtpOperationCode.GetObjectHandles, parameters, out byte[]? data, out PtpResponseCode resp);
//        if (resp != PtpResponseCode.OK || data == null) return new List<MtpObjectInfo>();

//        uint count = BitConverter.ToUInt32(data, 0);
//        var results = new List<MtpObjectInfo>();

//        for (int i = 0; i < count; i++)
//        {
//            uint handle = BitConverter.ToUInt32(data, 4 + (i * 4));
//            // Fetch info block metadata for each handle via 0x1008 GetObjectInfo
//            results.Add(FetchObjectInfo(handle));
//        }

//        return results;
//    }

//    private MtpObjectInfo FetchObjectInfo(uint handle)
//    {
//        _context!.ExecuteTransaction(PtpOperationCode.GetObjectInfo, new uint[] { handle }, out byte[]? data, out _);
//        if (data == null || data.Length < 12)
//            return new MtpObjectInfo($"0x{handle:X8}", "Unknown", 0, false, null);

//        // Fast parsing sample of basic layout boundaries
//        uint storageId = BitConverter.ToUInt32(data, 0);
//        ushort formatCode = BitConverter.ToUInt16(data, 4);
//        uint objectSize = BitConverter.ToUInt32(data, 8);

//        bool isFolder = formatCode == 0x3001; // Standard Association/Folder entry format

//        return new MtpObjectInfo($"0x{handle:X8}", $"Object_{handle}", objectSize, isFolder, DateTime.UtcNow);
//    }

//    public void DownloadFile(string objectId, Stream destinationStream)
//    {
//        if (_context == null) throw new InvalidOperationException("Device not connected.");
//        uint handle = Convert.ToUInt32(objectId, 16);

//        // Map 0x1009 GetObject command
//        _context.ExecuteTransaction(PtpOperationCode.GetObject, new uint[] { handle }, out byte[]? data, out PtpResponseCode resp);
//        if (resp == PtpResponseCode.OK && data != null)
//        {
//            destinationStream.Write(data, 0, data.Length);
//        }
//    }

//    public void UploadFile(string parentObjectId, string fileName, Stream sourceStream) => throw new NotImplementedException();
//    public void DeleteObject(string objectId) => throw new NotImplementedException();

//    public void Disconnect() => _context?.Dispose();
//    public void Dispose() => Disconnect();
//}

