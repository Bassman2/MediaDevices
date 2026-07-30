using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorLibrary
{

    public class Attribute(AttributeData data)
    {
        public string Name => data.AttributeClass?.Name ?? string.Empty;

        public string NameSpace => data.AttributeClass?.ContainingNamespace?.ToDisplayString() ?? string.Empty;
        
        public string FullName => data.AttributeClass?.ToDisplayString() ?? string.Empty;

        #region constructor arguments

        public IEnumerable<ConstructorArgument> ConstructorArguments => data.ConstructorArguments.Select(a => new ConstructorArgument(a));

        public ConstructorArgument? GetConstructorArgument(int index = 0) => data.ConstructorArguments.Length > index ? new ConstructorArgument(data.ConstructorArguments[index]) : null;

        public int ConstructorArgumentsLength => data.ConstructorArguments.Length;

        #endregion

        #region named arguments

        public IEnumerable<NamedArgument> NamedArguments => data.NamedArguments.Select(a => new NamedArgument(a.Key, a.Value));

        public bool HasNamedArgument(string name) => data.NamedArguments.Any(a => a.Key == name);
        public NamedArgument? GetNamedArgument(string name) => data.NamedArguments.Where(a => a.Key == name).Select(a => new NamedArgument(a.Key, a.Value)).FirstOrDefault();

        public bool TryGetNamedArgument(string name, out NamedArgument? namedArgument)
        {
            if (data.NamedArguments.Any(a => a.Key == name))
            {
                namedArgument = data.NamedArguments.Where(a => a.Key == name).Select(a => new NamedArgument(a.Key, a.Value)).First();
                return true;
            }
            else
            {
                namedArgument = null;
                return false;
            }
        }

        #endregion
    }
}
