using Avalonia.Styling;
using System.Runtime.InteropServices;

namespace MediaDevicesDemo.Services;

public class ApplicationService : IApplicationService
{
    public void ExitApplication()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }

    public void SetThemeVariant(ThemeVariants themeVariant)
    {
        if (Avalonia.Application.Current is { } app)
        {
            app.RequestedThemeVariant = themeVariant switch
            {
                ThemeVariants.Light => ThemeVariant.Light,
                ThemeVariants.Dark => ThemeVariant.Dark,
                _ => throw new InvalidOperationException()
            };
        }
    }

    public void OpenUrl(string url)
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
        }
        catch
        { }
    }
}
