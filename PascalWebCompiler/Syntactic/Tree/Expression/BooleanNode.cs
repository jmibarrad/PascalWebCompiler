using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public  class BooleanNode : ExpressionNode
    {
        public override BaseType ValidateSemantic()
        {
            return TypesTable.Instance.GetType("boolean");
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }

        public bool Value { get; set; }
    }
}