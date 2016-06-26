using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class ForNode : Loop
    {
        public ExpressionNode Condition;
        public IdNode IdNode;
        public ExpressionNode CounterValue;
        public SymbolTable ForSymbolTable = new SymbolTable();

        public override void ValidateNodeSemantic()
        {
            var validateSemantic = IdNode.ValidateSemantic();
            if (!(validateSemantic is IntegerType)) throw new SemanticException("Not an Integer type.");

            var counterValueType = validateSemantic.IsAssignable(CounterValue.ValidateSemantic());
            if (!counterValueType) throw new SemanticException($"{CounterValue} can't be assign.");

            if (Condition.ValidateSemantic() is IntegerType)
            {
                SymbolTable.AddSymbolTable(ForSymbolTable);
                foreach (var sentenceNode in Statements)
                {
                    sentenceNode.ValidateNodeSemantic();
                }
                SymbolTable.RemoveSymbolTable();
            }
            else
            {
                throw new SemanticException("Not an integer type.");
            }
        }

        public override string GenerateCode()
        {
            var counter = IdNode.GenerateCode();
            var forCode = $"for ({counter} = {CounterValue.GenerateCode()}; {counter} < {Condition.GenerateCode()}; {counter}++){{\n";
            foreach (var sentenceNode in Statements)
            {
                forCode += sentenceNode.GenerateCode();
            }
            return forCode + "\n}\n";
        }
    }
}