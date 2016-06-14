using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.DeclareConstants
{
    public abstract class ConstNode : SentenceNode
    {
        public IdNode IdNode;
        public ExpressionNode Expression;
        public abstract override void ValidateNodeSemantic();

        public abstract override string GenerateCode();
    }
}