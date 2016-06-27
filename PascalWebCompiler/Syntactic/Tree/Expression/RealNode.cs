using System.Globalization;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public class RealNode : ExpressionNode
    {
        public double Value;
        public override BaseType ValidateSemantic()
        {
            return TypesTable.Instance.GetType("real");
        }

        public override string GenerateCode()
        {
            return $"{Value.ToString(CultureInfo.InvariantCulture).Replace(',','.')}";
        }
    }
}