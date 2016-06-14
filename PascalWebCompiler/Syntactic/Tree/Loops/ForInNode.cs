using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class ForInNode : Loop
    {
        public IdNode IdNode;
        public IdNode IdNodeCollection;

        public override void ValidateNodeSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}