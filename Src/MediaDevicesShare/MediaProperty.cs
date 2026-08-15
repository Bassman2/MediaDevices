namespace MediaDevices;

/// <summary>
/// Represents a media device property with a name and value.
/// </summary>
public class MediaProperty
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MediaProperty"/> class.
    /// </summary>
    /// <param name="propVariantFacade">The property variant facade containing the property data.</param>
    internal MediaProperty(PropVariantFacade propVariantFacade)
    {
        Name = propVariantFacade.KeyName;
        Value = propVariantFacade.ToString();
    }

    /// <summary>
    /// Gets the name of the media property.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the value of the media property as a string.
    /// </summary>
    public string Value { get; }
}