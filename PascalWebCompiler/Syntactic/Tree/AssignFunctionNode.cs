using System.Collections.Generic;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class AssignFunctionNode : ExpressionNode
    {
        public List<ExpressionNode> Parameters;
        public IdNode IdNode;
    }
}