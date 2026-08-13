namespace MediaDevices;

public class MediaProperty
{
    internal MediaProperty(PropVariantFacade propVariantFacade)
    {
        Name = propVariantFacade.KeyName;
        Value = propVariantFacade.ToString();
    }

    public string Name { get; }

    public string Value { get; }
}
