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
        protected List<string> treeList = new List<string>
        {
            "\\UploadTree\\Aaa",
            "\\UploadTree\\Aaa\\A.txt",
            "\\UploadTree\\Aaa\\Abb",
            "\\UploadTree\\Aaa\\Abb\\Acc",
            "\\UploadTree\\Aaa\\Abb\\Acc\\Ctest.txt",
            "\\UploadTree\\Aaa\\Abb\\Add",
            "\\UploadTree\\Aaa\\Abb\\Aee.txt",
            "\\UploadTree\\Aaa\\Abb\\Aff.txt",
            "\\UploadTree\\Aaa\\Abb\\Agg.txt",
            "\\UploadTree\\Aaa\\Abb\\B.txt",
            "\\UploadTree\\Aaa\\Acc",
            "\\UploadTree\\Baa",
            "\\UploadTree\\Baa\\Bxx.txt",
            "\\UploadTree\\Bbb",
            "\\UploadTree\\Caa",
            "\\UploadTree\\Caa\\Cxx.txt",
            "\\UploadTree\\Ccc",
            "\\UploadTree\\Root.txt"
        };
        protected List<string> treeListFull;

        protected void UploadTestTree(MediaDevice device)
        {
            this.treeListFull = treeList.Select(p => workingFolder + p).ToList();

            string sourceFolder = Path.GetFullPath(@".\..\..\..\TestData\UploadTree");

            // create empty folders not checked in
            Directory.CreateDirectory(Path.Combine(sourceFolder, @"Aaa\Abb\Add"));
            Directory.CreateDirectory(Path.Combine(sourceFolder, @"Aaa\Acc"));
            Directory.CreateDirectory(Path.Combine(sourceFolder, "Bbb"));
            Directory.CreateDirectory(Path.Combine(sourceFolder, "Ccc"));

            var l = Directory.EnumerateFileSystemEntries(sourceFolder, "*", SearchOption.AllDirectories).OrderBy(s => s).ToList();
            var x = Directory.GetFileSystemEntries(sourceFolder, "*", SearchOption.AllDirectories).OrderBy(s => s).ToList();

            string destFolder = Path.Combine(this.workingFolder, "UploadTree");
            
            var exists = device.DirectoryExists(destFolder);
            if (exists)
            {
                device.DeleteDirectory(destFolder, true);
            }

            device.UploadFolder(sourceFolder, destFolder);
        }

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

            bool isFired = fired.WaitOne(new TimeSpan(0, 2, 0));
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
            var root = device.GetRootDirectory();
            var list = root.EnumerateFileSystemInfos().ToList();

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

            UploadTestTree(device);
            
            string destFolder = Path.Combine(this.workingFolder, "UploadTree");
            int pathLen = this.workingFolder.Length;
                      
            
            var list = device.EnumerateFileSystemEntries(destFolder, null, SearchOption.AllDirectories).ToList();
            
            device.Disconnect();


            CollectionAssert.AreEquivalent(this.treeListFull, list, "EnumerateFileSystemEntries");
            //CollectionAssert.AreEquivalent(pathes, list, "EnumerateFileSystemEntries");
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

        [TestMethod]
        [Description("Rename a file.")]
        public void RenameFileTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            string filePath = Path.Combine(this.workingFolder, "RenameTest.txt");
            string newName = "NewName.txt";
            string newPath = Path.Combine(this.workingFolder, newName);


            if (device.FileExists(filePath))
            {
                device.DeleteFile(filePath);
            }
            if (device.FileExists(newPath))
            {
                device.DeleteFile(newPath);
            }

            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes("This is a test.")))
            {
                device.UploadFile(stream, filePath);
            }
            var exists1 = device.FileExists(filePath);

            device.Rename(filePath, newName);
            
            var exists2 = device.FileExists(newPath);

            device.DeleteFile(newPath);
            var exists3 = device.FileExists(newPath);

            device.Disconnect();

            Assert.IsTrue(exists1, "exists1");
            Assert.IsTrue(exists2, "exists2");
            Assert.IsFalse(exists3, "exists3");
        }

        [TestMethod]
        [Description("Rename a folder.")]
        public void RenameFolderTest()
        {
                var devices = MediaDevice.GetDevices();
                var device = devices.FirstOrDefault(this.deviceSelect);
                Assert.IsNotNull(device, "Device");
                device.Connect();

                string filePath = Path.Combine(this.workingFolder, "RenameFolder");
                string newName = "NewFolder";
                string newPath = Path.Combine(this.workingFolder, newName);


                if (device.DirectoryExists(filePath))
                {
                    device.DeleteDirectory(filePath);
                }

                if (device.DirectoryExists(newPath))
                {
                    device.DeleteDirectory(newPath);
                }

                device.CreateDirectory(filePath);
            
                var exists1 = device.DirectoryExists(filePath);

                device.Rename(filePath, newName);


                var exists2 = device.DirectoryExists(newPath);

                device.DeleteDirectory(newPath);
                var exists3 = device.DirectoryExists(newPath);

                device.Disconnect();

                Assert.IsTrue(exists1, "exists1");
                Assert.IsTrue(exists2, "exists2");
                Assert.IsFalse(exists3, "exists3");
            }

        //[TestMethod]
        //[Description("Roma Test")]
        //public void RomaTest()
        //{
        //    string res = string.Empty;

        //    var devices = MediaDevice.GetDevices();
        //    var device = devices.FirstOrDefault(this.deviceSelect);
        //    Assert.IsNotNull(device, "Device");
        //    device.Connect();

        //    var fI = device.GetFileInfo(@"\SD card\Documents\note.txt");
        //    using (var stream = fI.OpenText())
        //    {
        //        res = stream.ReadToEnd();
        //    }

        //    device.Disconnect();

        //    Assert.AreEqual("Dies ist ein Test", res, "text");

        //}

        [TestMethod]
        [Description("Writable PersistentUniqueId Test")]
        public void WritablePersistentUniqueIdTest()
        {
                var devices = MediaDevice.GetDevices();
                var device = devices.FirstOrDefault(this.deviceSelect);
                Assert.IsNotNull(device, "Device");
                device.Connect();

                UploadTestTree(device);

                MediaDirectoryInfo dir = device.GetDirectoryInfo(Path.Combine(this.workingFolder, @"UploadTree\Aaa\Abb"));
                string dirPui = dir.PersistentUniqueId;
                MediaDirectoryInfo dirGet = device.GetFileSystemInfoFromPersistentUniqueId(dirPui) as MediaDirectoryInfo;

                MediaFileInfo file = device.GetFileInfo(Path.Combine(this.workingFolder, @"UploadTree\Aaa\Abb\Acc\Ctest.txt"));
                string filePui = file.PersistentUniqueId;
                MediaFileInfo fileGet = device.GetFileSystemInfoFromPersistentUniqueId(filePui) as MediaFileInfo;

                string tmp = Path.GetTempFileName();
                device.DownloadFileFromPersistentUniqueId(filePui, tmp);
                var text = File.ReadAllText(tmp);

                device.Disconnect();            

                Assert.IsNotNull(dirPui, "dirPui");
                Assert.AreEqual(dir, dirGet, "dirGet");

                Assert.IsNotNull(filePui, "filePui");
                Assert.AreEqual(file, fileGet, "fileGet");

                Assert.AreEqual("test", text, "text");
            }


    }
}
