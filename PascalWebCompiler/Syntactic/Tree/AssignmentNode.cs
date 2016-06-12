using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class AssignmentNode : SentenceNode
    {
        public IdNode ValueIdNode;
        public ExpressionNode Value;
    }
}