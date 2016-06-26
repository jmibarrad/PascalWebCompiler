using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class WhileNode : Loop
    {
        public ExpressionNode Condition;
        public override void ValidateNodeSemantic()
        {
            if (!(Condition.ValidateSemantic() is BooleanType)) throw new SemanticException($"{Condition.GenerateCode()} Not a Boolean type");
            
            foreach (var sentenceNode in Statements)
            {
                sentenceNode.ValidateNodeSemantic();
            }
        }

        public override string GenerateCode()
        {
            var whileCode = $"while({Condition.GenerateCode()}){{\n";
            foreach (var sentenceNode in Statements)
            {
                whileCode += sentenceNode.GenerateCode() + "\n";
            }
            return whileCode + "}";
        }
    }
}