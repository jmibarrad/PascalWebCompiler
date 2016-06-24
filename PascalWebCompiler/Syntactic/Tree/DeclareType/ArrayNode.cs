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
                type = new ArrayType { InferiorLimit = range.InferiorLimit.Value, SuperiorLimit = range.SuperiorLimit.Value, Type = type };
            }

            TypesTable.Instance.RegisterType(TypeName, type);
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