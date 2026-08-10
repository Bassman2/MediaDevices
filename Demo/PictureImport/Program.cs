namespace PictureImport;

internal class Program
{
    static int Main(string[] args)
    {
        string picturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        string picturesMask = "%manufacturer%\\%name%\\%date%";

        RootCommand rootCommand = new("Picture Importer");

        var copyCommand = new Command("copy", "Copy all pictures from a camera device. The pictures on the device will not be deleted.");
        var moveCommand = new Command("move", "Move all pictures from a camera device. The pictures on the device will be deleted.");
        var clearCommand = new Command("clear", "Remove all pictures from a camera device.");

        rootCommand.Subcommands.Add(copyCommand);
        rootCommand.Subcommands.Add(moveCommand);
        rootCommand.Subcommands.Add(clearCommand);

        Option<string> deviceOption = new("--device", "-d") { Description = "Name of the device to import from.", Required = true };
        Option<string> pathOption = new("--path", "-p") { Description = "Local import path", DefaultValueFactory = _ => picturesPath };
        Option<string> maskOption = new("--mask", "-m") { Description = "Mask of the additional import path.", DefaultValueFactory = _ => picturesMask };
        Option<bool> rawOption = new("--raw", "-r") { Description = "Separate raw files in sub folders.", DefaultValueFactory = _ => true };
        Option<bool> overrideOption = new("--override", "-o") { Description = "Override existing files.", DefaultValueFactory = _ => false };


        copyCommand.Options.Add(deviceOption);
        copyCommand.Options.Add(pathOption);
        copyCommand.Options.Add(maskOption);
        copyCommand.Options.Add(rawOption);
        copyCommand.Options.Add(overrideOption);

        moveCommand.Options.Add(deviceOption); 
        moveCommand.Options.Add(pathOption);
        moveCommand.Options.Add(maskOption);
        moveCommand.Options.Add(rawOption);
        moveCommand.Options.Add(overrideOption);

        clearCommand.Options.Add(deviceOption);

        copyCommand.SetAction(parseResult =>      
            Importer.Copy(
                parseResult.GetValue(deviceOption)!, 
                parseResult.GetValue(pathOption)!, 
                parseResult.GetValue(maskOption)!, 
                parseResult.GetValue(rawOption),
                parseResult.GetValue(overrideOption)));

        moveCommand.SetAction(parseResult =>
            Importer.Move(
                parseResult.GetValue(deviceOption)!, 
                parseResult.GetValue(pathOption)!, 
                parseResult.GetValue(maskOption)!, 
                parseResult.GetValue(rawOption),
                parseResult.GetValue(overrideOption)));


        clearCommand.SetAction(parseResult =>
            Importer.Clear(
                parseResult.GetValue(deviceOption)!));
        
        return rootCommand.Parse(args).Invoke();
    }
}
