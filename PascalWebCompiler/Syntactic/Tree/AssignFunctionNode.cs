using System.Collections.Generic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class AssignFunctionNode : ExpressionNode
    {
        public List<ExpressionNode> Parameters;
        public IdNode IdNode;
        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}