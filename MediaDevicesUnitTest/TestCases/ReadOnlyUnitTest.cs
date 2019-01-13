using MediaDevices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaDevicesUnitTest
{
    public abstract class ReadonlyUnitTest : UnitTest
    {
        // Exists Test
        protected string existingFile;

        // parent is object and grandparent is root
        protected string infoDirectoryName;
        protected string infoDirectoryPath;
        protected DateTime? infoDirectoryCreationTime;
        protected DateTime? infoDirectoryLastWriteTime;
        protected DateTime? infoDirectoryAuthoredTime;

        // object and root is parent
        protected string infoDirectoryParentName;
        protected string infoDirectoryParentPath;
        protected DateTime? infoDirectoryParentCreationTime;
        protected DateTime? infoDirectoryParentLastWriteTime;
        protected DateTime? infoDirectoryParentAuthoredTime;

        protected string infoFileName;
        protected string infoFilePath;
        protected ulong infoFileLength;
        protected DateTime? infoFileCreationTime;
        protected DateTime? infoFileLastWriteTime;
        protected DateTime? infoFileAuthoredTime;

        protected string infoFileParentName;
        protected string infoFileParentPath;
        protected DateTime? infoFileParentCreationTime;
        protected DateTime? infoFileParentLastWriteTime;
        protected DateTime? infoFileParentAuthoredTime;

        protected string enumDirectory;
        protected string enumFolderMask;
        protected string enumFilesmask;
        protected string enumItemMask;

        protected List<string> enumAllFolders;
        protected List<string> enumMaskFolders;

        protected List<string> enumAllFiles;
        protected List<string> enumMaskFiles;
        protected List<string> enumMaskRecursiveFiles;

        protected List<string> enumAllItems;
        protected List<string> enumMaskItems;
        protected List<string> enumMaskRecursiveItems;

        [TestMethod]
        [Description("Check if files and folders exists.")]
        public void ExistsTest()
        {
            string existingDirectory = Path.GetDirectoryName(this.existingFile);

            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            var exists1 = device.DirectoryExists(existingDirectory);
            var exists2 = device.DirectoryExists(this.existingFile);
            var exists3 = device.FileExists(existingDirectory);
            var exists4 = device.FileExists(this.existingFile);

            device.Disconnect();

            Assert.IsTrue(exists1, "exists1");
            Assert.IsFalse(exists2, "exists2");
            Assert.IsFalse(exists3, "exists3");
            Assert.IsTrue(exists4, "exists4");
        }



        [TestMethod]
        [Description("Download a file to the target.")]
        public void DownloadTest()
        {
            long position;
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            bool exists = device.FileExists(this.existingFile);
            Assert.IsTrue(exists, "exists");

            string tempFile = Path.Combine(Path.GetTempPath(), Path.GetFileName(this.existingFile));
            using (MemoryStream stream = new MemoryStream())
            {
                device.DownloadFile(this.existingFile, stream);
                position = stream.Length;

                using (FileStream file = File.Create(tempFile))
                {
                    stream.Position = 0;
                    stream.CopyTo(file);
                }
            }

            device.Disconnect();

            Assert.IsTrue(position > 0, "Position");
            Assert.IsTrue(File.Exists(tempFile), "Exists");

        }



        [TestMethod]
        [Description("Check file infos.")]
        public void FileInfoTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            var file = device.GetFileInfo(this.infoFilePath);
            var parent = file.Directory;

            Assert.AreEqual(this.infoFileName, file.Name, "file Name");
            Assert.AreEqual(this.infoFilePath, file.FullName, "file FullName");
            Assert.AreEqual(this.infoFileLength, file.Length, "file Length");
            Assert.AreEqual(this.infoFileCreationTime, file.CreationTime, "file CreationTime");
            Assert.AreEqual(this.infoFileLastWriteTime, file.LastWriteTime, "file LastWriteTime");
            Assert.AreEqual(this.infoFileAuthoredTime, file.DateAuthored, "file DateAuthored");
            Assert.IsTrue(file.Attributes.HasFlag(MediaFileAttributes.Normal), "file Normal");
            Assert.IsFalse(file.Attributes.HasFlag(MediaFileAttributes.Hidden), "file Hidden");
            Assert.IsFalse(file.Attributes.HasFlag(MediaFileAttributes.System), "file System");
            Assert.IsFalse(file.Attributes.HasFlag(MediaFileAttributes.DRMProtected), "file DRMProtected");

            Assert.AreEqual(this.infoFileParentName, parent.Name, "parent Name");
            Assert.AreEqual(this.infoFileParentPath, parent.FullName, "parent FullName");
            Assert.AreEqual(0ul, parent.Length, "parent Length");
            Assert.AreEqual(this.infoFileParentCreationTime, parent.CreationTime, "parent CreationTime");
            Assert.AreEqual(this.infoFileParentLastWriteTime, parent.LastWriteTime, "parent LastWriteTime");
            Assert.AreEqual(this.infoFileParentAuthoredTime, parent.DateAuthored, "parent DateAuthored");
            Assert.IsTrue(parent.Attributes.HasFlag(MediaFileAttributes.Directory), "parent Directory");
            Assert.IsFalse(parent.Attributes.HasFlag(MediaFileAttributes.Hidden), "parent Hidden");
            Assert.IsFalse(parent.Attributes.HasFlag(MediaFileAttributes.System), "parent System");
            Assert.IsFalse(parent.Attributes.HasFlag(MediaFileAttributes.DRMProtected), "parent DRMProtected");

            using (MemoryStream mem = new MemoryStream())
            {
                using (Stream stream = file.OpenRead())
                {
                    stream.CopyTo(mem);
                }
                Assert.AreEqual(this.infoFileLength, (ulong)mem.Position, "file read size");
            }

            device.Disconnect();

        }

        [TestMethod]
        [Description("Check directory infos.")]
        public void DirectoryInfoTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            var dir = device.GetDirectoryInfo(this.infoDirectoryPath);
            var parent = dir.Parent;
            var root = parent.Parent;
            var empty = root.Parent;

            Assert.AreEqual(this.infoDirectoryName, dir.Name, "dir Name");
            Assert.AreEqual(this.infoDirectoryPath, dir.FullName, "dir FullName");
            Assert.AreEqual(0ul, dir.Length, "dir Length");
            Assert.AreEqual(this.infoDirectoryCreationTime, dir.CreationTime, "dir CreationTime");
            Assert.AreEqual(this.infoDirectoryLastWriteTime, dir.LastWriteTime, "dir LastWriteTime");
            Assert.AreEqual(this.infoDirectoryAuthoredTime, dir.DateAuthored, "dir DateAuthored");
            Assert.IsTrue(dir.Attributes.HasFlag(MediaFileAttributes.Directory), "dir Directory");
            Assert.IsFalse(dir.Attributes.HasFlag(MediaFileAttributes.Hidden), "dir Hidden");
            Assert.IsFalse(dir.Attributes.HasFlag(MediaFileAttributes.System), "dir System");
            Assert.IsFalse(dir.Attributes.HasFlag(MediaFileAttributes.DRMProtected), "dir DRMProtected");

            Assert.AreEqual(this.infoDirectoryParentName, parent.Name, "parent Name");
            Assert.AreEqual(this.infoDirectoryParentPath, parent.FullName, "parent FullName");
            Assert.AreEqual(0ul, parent.Length, "parent Length");
            Assert.AreEqual(this.infoDirectoryParentCreationTime, parent.CreationTime, "parent CreationTime");
            Assert.AreEqual(this.infoDirectoryParentLastWriteTime, parent.LastWriteTime, "parent LastWriteTime");
            Assert.AreEqual(this.infoDirectoryParentAuthoredTime, parent.DateAuthored, "parent DateAuthored");
            Assert.IsTrue(parent.Attributes.HasFlag(MediaFileAttributes.Object), "parent Object");
            Assert.IsFalse(parent.Attributes.HasFlag(MediaFileAttributes.Hidden), "parent Hidden");
            Assert.IsFalse(parent.Attributes.HasFlag(MediaFileAttributes.System), "parent System");
            Assert.IsFalse(parent.Attributes.HasFlag(MediaFileAttributes.DRMProtected), "parent DRMProtected");

            Assert.AreEqual(@"\", root.Name, "root Name");
            Assert.AreEqual(@"\", root.FullName, "root FullName");
            Assert.AreEqual(0ul, root.Length, "root Length");
            Assert.AreEqual(null, root.CreationTime, "root CreationTime");
            Assert.AreEqual(null, root.LastWriteTime, "root LastWriteTime");
            Assert.AreEqual(null, root.DateAuthored, "root DateAuthored");
            Assert.IsTrue(root.Attributes.HasFlag(MediaFileAttributes.Object), "root Object");
            Assert.IsFalse(root.Attributes.HasFlag(MediaFileAttributes.Hidden), "root Hidden");
            Assert.IsFalse(root.Attributes.HasFlag(MediaFileAttributes.System), "root System");
            Assert.IsFalse(root.Attributes.HasFlag(MediaFileAttributes.DRMProtected), "root DRMProtected");

            Assert.IsNull(empty, "empty");

            device.Disconnect();
        }

        [TestMethod]
        [Description("Check directory infos enum.")]
        public void DirectoryInfoEnumTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            var dir = device.GetDirectoryInfo(this.enumDirectory);

            var enum1 = dir.EnumerateDirectories().Select(e => e.FullName).ToList();
            var enum2 = dir.EnumerateDirectories(this.enumFolderMask).Select(e => e.FullName).ToList();

            var enum3 = dir.EnumerateFiles().Select(e => e.FullName).ToList();
            var enum4 = dir.EnumerateFiles(this.enumFilesmask).Select(e => e.FullName).ToList();
            var enum5 = dir.EnumerateFiles(this.enumFilesmask, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

            var enum6 = dir.EnumerateFileSystemInfos().Select(e => e.FullName).ToList();
            var enum7 = dir.EnumerateFileSystemInfos(this.enumItemMask).Select(e => e.FullName).ToList();
            var enum8 = dir.EnumerateFileSystemInfos(this.enumItemMask, SearchOption.AllDirectories).Select(e => e.FullName).ToList();

            device.Disconnect();

            CollectionAssert.AreEquivalent(this.enumAllFolders, enum1, "enum1");
            CollectionAssert.AreEquivalent(this.enumMaskFolders, enum2, "enum2");

            CollectionAssert.AreEquivalent(this.enumAllFiles, enum3, "enum3");
            CollectionAssert.AreEquivalent(this.enumMaskFiles, enum4, "enum4");
            CollectionAssert.AreEquivalent(this.enumMaskRecursiveFiles, enum5, "enum5");

            CollectionAssert.AreEquivalent(this.enumAllItems, enum6, "enum6");
            CollectionAssert.AreEquivalent(this.enumMaskItems, enum7, "enum7");
            CollectionAssert.AreEquivalent(this.enumMaskRecursiveItems, enum8, "enum8");
        }



        [TestMethod]
        [Description("Download a file to the target.")]
        public void DownloadFileTest()
        {
            var devices = MediaDevice.GetDevices();
            var device = devices.FirstOrDefault(this.deviceSelect);
            Assert.IsNotNull(device, "Device");
            device.Connect();

            bool exists = device.FileExists(this.existingFile);
            Assert.IsTrue(exists, "exists");

            string tempFile = Path.ChangeExtension(Path.GetTempFileName(), Path.GetExtension(this.existingFile));

            device.DownloadFile(this.existingFile, tempFile);

            device.Disconnect();

            Assert.IsTrue(File.Exists(tempFile), "Exists");

        }
    }
}
