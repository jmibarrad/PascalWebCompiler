using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.DeclareConstants
{
    public class ConstNode : SentenceNode
    {
        public IdNode IdNode;
        public ExpressionNode Expression;
    }

    public class ConstWithTypeNode : ConstNode
    {
        public string Type;
    }
    public class ConstOnlyDeclareNode : ConstNode
    {

    }

}