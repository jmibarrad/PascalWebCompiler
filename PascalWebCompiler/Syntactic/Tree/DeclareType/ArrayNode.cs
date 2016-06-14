using System.Collections.Generic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public class ArrayNode : TypeDeclarationNode
    {
        public List<Range> Ranges;
        public string ArrayType;

        public override void ValidateNodeSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }

        public override BaseType GetBaseType()
        {
            throw new System.NotImplementedException();
        }
    }
}