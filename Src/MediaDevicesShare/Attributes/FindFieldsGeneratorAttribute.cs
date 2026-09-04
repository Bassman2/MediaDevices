namespace MediaDevices;

internal enum FindType
{
    Guid = 1,
    PropertyKey = 2,
    All = 3
}


[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
internal class FindFieldsGeneratorAttribute(FindType findType = FindType.All) : Attribute
{
    public FindType FindType => findType;
}



