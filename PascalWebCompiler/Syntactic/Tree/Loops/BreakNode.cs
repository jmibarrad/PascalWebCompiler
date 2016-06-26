namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class BreakNode : SentenceNode
    {
        public override void ValidateNodeSemantic()
        {
            //Nothing
        }

        public override string GenerateCode()
        {
            return "break;";
        }
    }
}