namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class ContinueNode : SentenceNode
    {
        public override void ValidateNodeSemantic()
        {
            //Nothing
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}