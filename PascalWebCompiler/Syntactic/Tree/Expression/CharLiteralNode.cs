using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    internal class CharLiteralNode : ExpressionNode
    {
        public char Value { get; set; }
        public override BaseType ValidateSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}