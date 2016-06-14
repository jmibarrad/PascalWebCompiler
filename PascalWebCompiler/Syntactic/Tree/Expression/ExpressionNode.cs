using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public abstract class ExpressionNode
    {
        public abstract BaseType ValidateSemantic();
        public abstract string GenerateCode();
    }
}
