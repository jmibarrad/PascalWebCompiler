namespace PascalWebCompiler.Syntactic.Tree
{
    public class HtmlNode : SentenceNode
    {
        public string Content;
        public override void ValidateNodeSemantic()
        {
            
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}