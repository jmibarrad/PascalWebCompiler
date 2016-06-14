using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public class NumberNode : ExpressionNode
    {
        public int Value;
        public override BaseType ValidateSemantic()
        {
            return TypesTable.Instance.GetType("integer");
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}