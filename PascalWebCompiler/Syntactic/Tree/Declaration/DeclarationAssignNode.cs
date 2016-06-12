using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Declaration
{
    public class DeclarationAssignNode : DeclarationNode
    {
        public IdNode IdNode;
        public ExpressionNode Value;
    }
}