using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.ID
{
    public class IndexAccesorNode : AccesorNode
    {
        public ExpressionNode IndexExpression { get; set; }

    }
}