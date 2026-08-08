namespace MediaDevices.Attributes;

[AttributeUsage(AttributeTargets.Interface)]
internal class CLSIDAttribute(string clsid) : Attribute
{
    public string Value { get; } = clsid;
}
