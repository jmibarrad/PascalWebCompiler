namespace PascalWebCompiler.Syntactic.Tree.Declaration
{
    public abstract class DeclarationNode : SentenceNode
    {
        public string Type;
        public abstract override void ValidateNodeSemantic();

        public abstract override string GenerateCode();
    }
}