namespace MediaDevicesUnitTest;

partial class ReadonlyUnitTest
{
    [TestMethod]
    [Description("Check directory enum.")]
    public async Task ReadonlyMediaDeviceEnumDirectoriesAsyncTest()
    {
        var device = GetDevice();
        device.Connect();

        var enum1 = await device.EnumerateDirectoriesAsync(readonlyEnumPath).ToListAsync();
        var enum2 = await device.EnumerateDirectoriesAsync(readonlyEnumPath, "", SearchOption.AllDirectories).ToListAsync();
        var enum3 = await device.EnumerateDirectoriesAsync(readonlyEnumPath, readonlyEnumSearchPatternFolders).ToListAsync();
        var enum4 = await device.EnumerateDirectoriesAsync(readonlyEnumPath, readonlyEnumSearchPatternFolders, SearchOption.AllDirectories).ToListAsync();

        device.Disconnect();

        if (this.readonlyEnumFoldersMode == EnumerableMode.Sequence)
        {
            Assert.AreSequenceEqual(readonlyEnumFolders, enum1, SequenceOrder.InAnyOrder, nameof(readonlyEnumFolders));
            Assert.AreSequenceEqual(readonlyEnumFoldersRecursive, enum2, SequenceOrder.InAnyOrder, nameof(readonlyEnumFoldersRecursive));
            Assert.AreSequenceEqual(readonlyEnumFoldersSearchPattern, enum3, SequenceOrder.InAnyOrder, nameof(readonlyEnumFoldersSearchPattern));
            Assert.AreSequenceEqual(readonlyEnumFoldersSearchPatternRecursive, enum4, SequenceOrder.InAnyOrder, nameof(readonlyEnumFoldersSearchPatternRecursive));
        }
        else
        {
            CollectionAssert.IsSubsetOf(readonlyEnumFolders, enum1, nameof(readonlyEnumFolders));
            CollectionAssert.IsSubsetOf(readonlyEnumFoldersRecursive, enum2, nameof(readonlyEnumFoldersRecursive));
            CollectionAssert.IsSubsetOf(readonlyEnumFoldersSearchPattern, enum3, nameof(readonlyEnumFoldersSearchPattern));
            CollectionAssert.IsSubsetOf(readonlyEnumFoldersSearchPatternRecursive, enum4, nameof(readonlyEnumFoldersSearchPatternRecursive));
        }
    }
}
