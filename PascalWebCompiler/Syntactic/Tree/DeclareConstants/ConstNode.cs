using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.DeclareConstants
{
    public class ConstNode : SentenceNode
    {
        public IdNode IdNode;
        public ExpressionNode Expression;
        public override void ValidateNodeSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }

    public class ConstWithTypeNode : ConstNode
    {
        public string Type;
    }
    public class ConstOnlyDeclareNode : ConstNode
    {

    }

}