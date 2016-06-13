using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class ForNode : Loop
    {
        public ExpressionNode Condition;
        public IdNode IdNode;
        public ExpressionNode CounterValue;

    }
}