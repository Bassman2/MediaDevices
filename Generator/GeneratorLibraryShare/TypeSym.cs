using Microsoft.CodeAnalysis;

namespace GeneratorLibrary
{
    public class TypeSym(ITypeSymbol symbol) 
    {
        public string Name => symbol.Name;

        public string FullName => symbol.ToDisplayString();

        public string NameSpace => symbol.ContainingNamespace?.ToDisplayString() ?? string.Empty;

        public TypeKind TypeKind => symbol.TypeKind;


        public string BaseTypeName => GetInnerType(symbol)?.Name ?? "";

        public string BaseTypeFullName => GetInnerType(symbol)?.ToDisplayString() ?? "";


        public bool IsReferenceType => symbol.IsReferenceType;

        public bool IsValueType => symbol.IsValueType;

        public bool IsEnum => symbol.TypeKind == Microsoft.CodeAnalysis.TypeKind.Enum;

        ITypeSymbol? GetInnerType(ITypeSymbol type, int index = 0)
        {
            if (type is INamedTypeSymbol named && named.TypeArguments.Length > index)
            {
                var arg = named.TypeArguments[index];
                // If the symbol is an unbound generic (type parameter) there's no concrete inner type:
                if (arg is ITypeParameterSymbol)
                    return null;
                return arg;
            }

            if (type is IArrayTypeSymbol arr)
                return arr.ElementType;

            if (type is IPointerTypeSymbol ptr)
                return ptr.PointedAtType;

            return null;
        }
    }
}
