using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class RepeatNode : Loop
    {
        public ExpressionNode Condition;
        public override void ValidateNodeSemantic()
        {
            if (Condition.ValidateSemantic() is BooleanType)
            {
                foreach (var sentenceNode in Statements)
                {
                    sentenceNode.ValidateNodeSemantic();
                }
            }
            else
            {
                throw new SemanticException("Not a Boolean type");
            }
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}