using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class ForNode : Loop
    {
        public ExpressionNode Condition;
        public IdNode IdNode;
        public ExpressionNode CounterValue;

        public override void ValidateNodeSemantic()
        {
            var validateSemantic = IdNode.ValidateSemantic();
            if (!(validateSemantic is IntegerType)) throw new SemanticException("Not an Integer type.");

            var counterValueType = validateSemantic.IsAssignable(CounterValue.ValidateSemantic());
            if (!counterValueType) throw new SemanticException("Value cant be assign");

            if (Condition.ValidateSemantic() is IntegerType)
            {
                foreach (var sentenceNode in Statements)
                {
                    sentenceNode.ValidateNodeSemantic();
                }
            }
            else
            {
                throw new SemanticException("Not an integer type");
            }
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}