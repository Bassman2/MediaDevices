using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace GeneratorLibrary
{
    
    public class Field(IFieldSymbol symbol) : BaseAttributes
    {
        public string Name => symbol.Name;

        public TypeSym Type => new(symbol.Type);
               

        public override IEnumerable<Attribute> Attributes => symbol.GetAttributes().Select(a => new Attribute(a));

    }
}
