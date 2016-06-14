using System.Collections.Generic;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class CallFunctionNode : SentenceNode
    {
        public List<ExpressionNode> Parameters;
        public IdNode IdNode;
        public override void ValidateNodeSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}