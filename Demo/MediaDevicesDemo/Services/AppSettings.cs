namespace MediaDevicesDemo.Services;

[JsonSourceGenerationOptions(WriteIndented = true, PropertyNameCaseInsensitive = true, UseStringEnumConverter = true)]
[JsonSerializable(typeof(AppSettingsBase))]
internal partial class AppSettingsBaseContext : JsonSerializerContext
{ }

public class AppSettings : AppSettingsBase
{
}
