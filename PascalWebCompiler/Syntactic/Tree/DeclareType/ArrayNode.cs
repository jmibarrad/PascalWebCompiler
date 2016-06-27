using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public class ArrayNode : TypeDeclarationNode
    {
        public List<Range> Ranges;
        public string ArrayType;

        public override void ValidateNodeSemantic()
        {
            var type = TypesTable.Instance.GetType(ArrayType);
            foreach (var range in Ranges)
            {
                if (range.InferiorLimit.Value > range.SuperiorLimit.Value) throw new SemanticException("Invalid range: inferior limit is bigger than superior limit.");
                type = new ArrayType { JavaType = TypeName, InferiorLimit = range.InferiorLimit.Value, SuperiorLimit = range.SuperiorLimit.Value, Type = type };
            }
            SymbolTable.Instance.DeclareVariable(TypeName, "array");
            TypesTable.Instance.RegisterType(TypeName, type);
        }

        public override string GenerateCode()
        {
            var arrType = TypesTable.Instance.GetType(ArrayType).ToJavaString();

            var arrayCode = $"{arrType} _{TypeName}";
            //var basicType = SymbolTable.Instance.GetVariable(TypeName);
            //if (basicType is ArrayType)
            //{
                
            //}
            var arrayInitializeCode = string.Empty;
            Ranges.Reverse();
            foreach (var range in Ranges)
            {
                arrayCode += "[]";
                arrayInitializeCode += $"[{range.SuperiorLimit.Value-range.InferiorLimit.Value+1}]";
            }
            return $"{arrayCode} = new {arrType}{arrayInitializeCode};\n";
        }

        public override BaseType GetBaseType()
        {
            var type = TypesTable.Instance.GetType(ArrayType);
            foreach (var range in Ranges)
            {
                type = new ArrayType { InferiorLimit = range.InferiorLimit.Value, SuperiorLimit = range.SuperiorLimit.Value, Type = type };
            }
            return type;
        }
    }
}