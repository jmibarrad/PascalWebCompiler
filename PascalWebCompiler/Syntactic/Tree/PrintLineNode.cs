using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class PrintLineNode : SentenceNode
    {
        public ExpressionNode Expression { get; set; }

        public override void ValidateNodeSemantic()
        {
            Expression.ValidateSemantic();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }

    }
}