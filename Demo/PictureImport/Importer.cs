namespace PictureImport;

internal static class Importer
{
    private static readonly string[] endings = {".jpg", ".jpeg", ".cr3", ".png", ".mov" };

    public static int Copy(string deviceName, string path, string mask, bool raw, bool overrideExisting)
    {
        var device = MediaDevice.GetDevices()?.FirstOrDefault(d => d.Description == deviceName);
        if (device == null) 
        {
            Console.Error.WriteLine($"Device '{deviceName}' not found."); 
            return -1;
        }

        device.Connect();

        var list = GetAllPictures(device);
        int num = list.Count;
        int index = 1;
        foreach (var file in list)
        {
            Console.WriteLine($"{index++} / {num}");
            Console.CursorLeft = 0;

            var outputPath = CreateOutputPath(path, mask, raw, device, file);

            if (overrideExisting || !File.Exists(outputPath))
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);
                    file.CopyTo(outputPath);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error copying file '{file.Name}': {ex.Message}");
                }
            }
        }

        device.Disconnect();
        return 0;
    }

    public static int Move(string deviceName, string path, string mask, bool raw, bool overrideExisting)
    {
        
        var device = MediaDevice.GetDevices()?.FirstOrDefault(d => d.Description == deviceName);
        if (device == null)
        {
            Console.Error.WriteLine($"Device '{deviceName}' not found.");
            return -1;
        }

        device.Connect();

        var list = GetAllPictures(device);
        int num = list.Count;
        int index = 1;
        foreach (var file in list)
        {
            Console.WriteLine($"{index++ / num:D3}");
            Console.CursorLeft = 0;

            var outputPath = CreateOutputPath(path, mask, raw, device, file);
            if (overrideExisting || !File.Exists(outputPath))
            {
                try
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath)!);

                    //file.MoveTo(outputPath);
                    //file.CopyTo(outputPath);
                    //file.Delete();
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error moving file '{file.Name}': {ex.Message}");
                }
            }
        }
        device.Disconnect();

        return 0;
    }

    public static int Clear(string deviceName)
    {
        
        var device = MediaDevice.GetDevices()?.FirstOrDefault(d => d.Description == deviceName);

        if (device == null)
        {
            Console.Error.WriteLine($"Device '{deviceName}' not found.");
            return -1;
        }

        device.Connect();

        var list = GetAllPictures(device);
        int num = list.Count;
        int index = 1;
        foreach (var file in list)
        {
            Console.WriteLine($"{index++ / num:D3}");
            Console.CursorLeft = 0;

            try
            {
                //file.Delete();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error deleting file '{file.Name}': {ex.Message}");
            }
        }
        device.Disconnect();

        return 0;
    }

    private static List<MediaFileInfo> GetAllPictures(MediaDevice device)
    {
        return [.. device.GetRootDirectory().EnumerateFiles("*.*", SearchOption.AllDirectories).Where(f =>
            endings.Any(e => f.Name.EndsWith(e, StringComparison.OrdinalIgnoreCase)))];
    }       

    private static string CreateOutputPath(string basePath, string mask, bool raw, MediaDevice device, MediaFileInfo file)
    {
        var maskResult = mask
            .Replace("%manufacturer%", device.Manufacturer, StringComparison.InvariantCultureIgnoreCase)
            .Replace("%name%", device.Description, StringComparison.InvariantCultureIgnoreCase)
            .Replace("%date%", file.CreationTime?.ToString("yyyy-MM-dd") ?? "0000-00-00", StringComparison.InvariantCultureIgnoreCase)
            .Replace("%month%", file.CreationTime?.ToString("yyyy-MM") ?? "0000-00", StringComparison.InvariantCultureIgnoreCase)
            .Replace("%year%", file.CreationTime?.ToString("yyyy") ?? "0000", StringComparison.InvariantCultureIgnoreCase);

        return raw && file.Name.EndsWith(".cr3", StringComparison.OrdinalIgnoreCase) ?
            Path.Combine(basePath, maskResult, ".CR3", file.Name) :
            Path.Combine(basePath, maskResult, file.Name);
    }
}
