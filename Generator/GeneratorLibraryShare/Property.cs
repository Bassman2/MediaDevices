using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorLibrary
{
    public class Property(IPropertySymbol symbol) : BaseAttributes
    {
        public string Name => symbol.Name;

        public TypeSym Type => new(symbol.Type);
        

        public bool HasGet = symbol.GetMethod != null;

        public bool HasSet = symbol.SetMethod != null;

        public override IEnumerable<Attribute> Attributes => symbol.GetAttributes().Select(a => new Attribute(a));
                
        public override string ToString() => $"{Type.Name} {Name} {{ {(HasGet ? "get; " : "")}{(HasSet ? "set;" : "")} }}";
    }
}
