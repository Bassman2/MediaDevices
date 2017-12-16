using MediaDevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MediaDevicesUnitTest
{
    public abstract class WritableUnitTest : UnitTest
    {
        protected string workingFolder;

        [TestMethod]
        [Description("Test event handling.")]
        public void EventTest()
        {
            //if (!this.supEvent) return;

            AutoResetEvent fired = new AutoResetEvent(false);

            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.ObjectRemoved += (s, a) => fired.Set();
            device.Connect();

            string filePath = Path.Combine(this.workingFolder, "Test.txt");
            if (device.FileExists(filePath))
            {
                device.DeleteFile(filePath);
            }

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("This is a test.")))
            {
                device.UploadFile(stream, filePath);
            }

            device.DeleteFile(filePath);

            bool isFired = fired.WaitOne(new TimeSpan(0, 10, 0));
            device.Disconnect();

            Assert.IsTrue(isFired);
        }

        [TestMethod]
        [Description("Creating a new folder.")]
        public void CreateFolderTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            string newFolder = Path.Combine(this.workingFolder, "Test");
            var exists1 = device.DirectoryExists(this.workingFolder);
            device.CreateDirectory(newFolder);
            var exists2 = device.DirectoryExists(newFolder);
            device.DeleteDirectory(newFolder, true);
            var exists3 = device.DirectoryExists(newFolder);

            device.Disconnect();

            Assert.IsTrue(exists1, "exists1");
            Assert.IsTrue(exists2, "exists2");
            Assert.IsFalse(exists3, "exists3");
        }

        [TestMethod]
        [Description("Upload a file to the target.")]
        public void UploadTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            string filePath = Path.Combine(this.workingFolder, "Test.txt");
            if (device.FileExists(filePath))
            {
                device.DeleteFile(filePath);
            }

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("This is a test.")))
            {
                device.UploadFile(stream, filePath);
            }
            var exists1 = device.FileExists(filePath);
            device.DeleteFile(filePath);
            var exists2 = device.FileExists(@"\Phone\Downloads\Test.txt");

            device.Disconnect();

            Assert.IsTrue(exists1, "exists1");
            Assert.IsFalse(exists2, "exists2");
        }

        [TestMethod]
        [Description("Upload a file to the target.")]
        public void UploadFileTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            string sourceFile = Path.GetFullPath(@".\..\..\..\TestData\TestFile.txt");
            string destFile = Path.Combine(this.workingFolder, "TestFile.txt");

            var exists1 = device.FileExists(destFile);
            if (exists1)
            {
                device.DeleteFile(destFile);
            }

            device.UploadFile(sourceFile, destFile);

            var exists = device.FileExists(destFile);

            device.DeleteFile(destFile);

            device.Disconnect();

            Assert.IsTrue(exists, "exists");

        }

        [TestMethod]
        [Description("Upload a tree to the target.")]
        public void UploadTreeTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            string sourceFolder = Path.GetFullPath(@".\..\..\..\TestData\UploadTree");
            string destFolder = Path.Combine(this.workingFolder, "UploadTree");

            var exists1 = device.DirectoryExists(destFolder);
            if (exists1)
            {
                device.DeleteDirectory(destFolder, true);
            }


            device.UploadFolder(sourceFolder, destFolder);

            //var exists = device.FileExists(destFile);

            //device.DeleteDirectory(destFolder, true);

            device.Disconnect();

            //Assert.IsTrue(exists, "exists");

        }

        [TestMethod]
        [Description("Download a file to the target.")]
        public void DownloadTreeTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            string sourceFolder = Path.GetFullPath(@".\..\..\..\TestData\UploadTree");
            string destFolder = Path.Combine(this.workingFolder, "UploadTree");

            var exists1 = device.DirectoryExists(destFolder);
            if (exists1)
            {
                device.DeleteDirectory(destFolder, true);
            }


            device.UploadFolder(sourceFolder, destFolder);

            string downloadFolder = Path.GetFullPath(@".\..\..\..\TestData\DownloadTree");

            if (Directory.Exists(downloadFolder))
            {
                Directory.Delete(downloadFolder, true);
            }

            device.DownloadFolder(destFolder, downloadFolder);

            device.Disconnect();

            //Assert.IsTrue(File.Exists(tempFile), "Exists");

        }
    }
}
