using Microsoft.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;

namespace GeneratorLibrary
{
    public class ConstructorArgument(TypedConstant arg)
    {
        public string Value => FormatTypedConstant(arg);

        public object? PureValue => arg.Value;

        public string TypeName => arg.Type?.ToDisplayString() ?? string.Empty;
        public string TypeEnum => arg.Type?.SpecialType.ToString() ?? string.Empty;

        public string Kind => arg.Kind.ToString();

        private string FormatTypedConstant(TypedConstant constant)
        {
            if (constant.IsNull)
            {
                return "null";
            }
            if (constant.Kind == TypedConstantKind.Array)
            {
                var values = constant.Values.Select(FormatTypedConstant);
                return $"[{string.Join(", ", values)}]";
            }
            if (constant.Type?.TypeKind == TypeKind.Enum)
            {
                var enumType = constant.Type;
                var value = constant.Value;
                if (value != null)
                {
                    var member = enumType.GetMembers()
                        .OfType<IFieldSymbol>()
                        .FirstOrDefault(f => f.HasConstantValue && Equals(f.ConstantValue, value));
                    if (member != null)
                        return $"{enumType.Name}.{member.Name}";
                }
                return $"{enumType.Name}.{value}";
            }
            if (constant.Type?.SpecialType == SpecialType.System_String)
            {
                return $"{constant.Value}";
            }
            return constant.Value?.ToString() ?? "null";
        }

        public byte? ToByte()
        {
            if (arg.Type?.SpecialType == SpecialType.System_Byte)
            {
                return (byte?)arg.Value;
            }
            return null;
        }

        public short? ToInt16()
        {
            if (arg.Type?.SpecialType == SpecialType.System_Int16)
            {
                return (short?)arg.Value;
            }
            return null;
        }

        public ushort? ToUInt16()
        {
            if (arg.Type?.SpecialType == SpecialType.System_UInt16)
            {
                return (ushort?)arg.Value;
            }
            return null;
        }

        public int? ToInt32()
        {
            if (arg.Type?.SpecialType == SpecialType.System_Int32)
            {
                return (int?)arg.Value;
            }
            return null;
        }

        public uint? ToUInt32()
        {
            if (arg.Type?.SpecialType == SpecialType.System_UInt32)
            {
                return (uint?)arg.Value;
            }
            return null;
        }

        public T? ToEnum<T>() 
        {
            if (arg.Type?.SpecialType == SpecialType.System_Enum)
            {
                return (T?)arg.Value;
            }
            return default(T);
        }
    }
}
