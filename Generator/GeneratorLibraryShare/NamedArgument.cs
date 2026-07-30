using Microsoft.CodeAnalysis;

namespace GeneratorLibrary
{
    public class NamedArgument(string name, TypedConstant arg) : ConstructorArgument(arg)
    {
        public string Name => name;
    }
}
