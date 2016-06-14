using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public class StringLiteralNode : ExpressionNode
    {
        public string Value;
        public override BaseType ValidateSemantic()
        {
            return TypesTable.Instance.GetType("string");
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}