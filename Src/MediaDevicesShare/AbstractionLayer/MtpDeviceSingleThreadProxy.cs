//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace MediaDevices.AbstractionLayer;

//internal class MtpDeviceSingleThreadProxy : IMtpDevice
//{
//    private readonly IMtpDevice underlyingDevice;

//    public string DeviceId => underlyingDevice.DeviceId;
//    public string FriendlyName => underlyingDevice.FriendlyName;
//    public string Manufacturer => underlyingDevice.Manufacturer;

//    public MtpDeviceSingleThreadProxy(IMtpDevice underlyingDevice)
//    {
//        underlyingDevice = underlyingDevice ?? throw new ArgumentNullException(nameof(underlyingDevice));

//        //// Explicitly allocate a dedicated OS-level thread marked as long-running
//        //_workerThread = new Thread(ProcessQueue)
//        //{
//        //    Name = $"MTP-Worker-{_underlyingDevice.DeviceId}",
//        //    IsBackground = true
//        //};
//        //_workerThread.Start();
//    }

//    public void Connect() =>
//           ExecuteOnWorker(() => _underlyingDevice.Connect());

//    public void Disconnect() =>
//        ExecuteOnWorker(() => _underlyingDevice.Disconnect());

//    public List<string> GetStorageIds() =>
//        ExecuteOnWorker(() => _underlyingDevice.GetStorageIds());

//    public List<MtpObjectInfo> GetChildren(string parentObjectId) =>
//        ExecuteOnWorker(() => _underlyingDevice.GetChildren(parentObjectId));

//    public void DownloadFile(string objectId, Stream destinationStream) =>
//        ExecuteOnWorker(() => _underlyingDevice.DownloadFile(objectId, destinationStream));

//    public void UploadFile(string parentObjectId, string fileName, Stream sourceStream) =>
//        ExecuteOnWorker(() => _underlyingDevice.UploadFile(parentObjectId, fileName, sourceStream));

//    public void DeleteObject(string objectId) =>
//        ExecuteOnWorker(() => _underlyingDevice.DeleteObject(objectId));

//}
