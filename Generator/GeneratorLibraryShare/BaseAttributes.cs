using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorLibrary
{
    public abstract class BaseAttributes
    {
        public abstract IEnumerable<Attribute> Attributes { get; }

        public bool HasAttribute(string nameWithNamespace) 
            => Attributes.Any(a => a.FullName == nameWithNamespace);

        public Attribute? GetAttribute(string nameWithNamespace) 
            => Attributes.FirstOrDefault(a => a.FullName == nameWithNamespace);

        public bool TryGetAttribute(string nameWithNamespace, out Attribute? attribute)
        {
            if (Attributes.Any(a => a.FullName == nameWithNamespace))
            {
                attribute = Attributes.First(a => a.FullName == nameWithNamespace);
                return true;
            }
            else
            {
                attribute = null;
                return false;
            }       
        }
    }
}
