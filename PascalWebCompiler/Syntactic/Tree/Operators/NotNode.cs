using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Operators
{
    public class NotNode : ExpressionNode
    {
        public ExpressionNode ExpressionNode;
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