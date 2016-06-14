using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Relational
{
    public class NotNode : ExpressionNode
    {
        public ExpressionNode ExpressionNode;

        public override BaseType ValidateSemantic()
        {
            var type = ExpressionNode.ValidateSemantic();
            if (!(type is BooleanType))
                 throw new SemanticException($"Expression: {type} can't be negated..");

            return new BooleanType();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}