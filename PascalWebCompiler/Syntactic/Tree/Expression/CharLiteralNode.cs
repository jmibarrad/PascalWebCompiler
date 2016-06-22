using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    internal class CharLiteralNode : ExpressionNode
    {
        public string Value { get; set; }
        public override BaseType ValidateSemantic()
        {
            return TypesTable.Instance.GetType("char");
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}