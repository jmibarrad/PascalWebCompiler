using System.Collections.Generic;
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
            SymbolTable.Instance.DeclareVariable(TypeName, ArrayType, Ranges);
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
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