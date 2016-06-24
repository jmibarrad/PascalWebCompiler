using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class RepeatNode : Loop
    {
        public ExpressionNode Condition;
        public SymbolTable RepeatSymbolTable = new SymbolTable();
        public override void ValidateNodeSemantic()
        {
            if (Condition.ValidateSemantic() is BooleanType)
            {
                SymbolTable.AddSymbolTable(RepeatSymbolTable);
                foreach (var sentenceNode in Statements)
                {
                    sentenceNode.ValidateNodeSemantic();
                }
                SymbolTable.RemoveSymbolTable();
            }
            else
            {
                throw new SemanticException($"{Condition} is not a Boolean type.");
            }
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}