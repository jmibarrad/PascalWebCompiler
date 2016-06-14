namespace PascalWebCompiler.Syntactic.Tree
{
    public abstract class SentenceNode
    {
        public abstract void ValidateNodeSemantic();
        public abstract string GenerateCode();
    }
}
