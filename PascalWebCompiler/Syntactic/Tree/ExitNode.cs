using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class ExitNode : SentenceNode
    {
        public ExpressionNode ReturnValue;
        public override void ValidateNodeSemantic()
        {
            //throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            return $"return {ReturnValue.GenerateCode()};";
        }
    }
}