using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public abstract class TypeDeclarationNode : SentenceNode
    {
        public string TypeName;
        public abstract override void ValidateNodeSemantic();

        public abstract override string GenerateCode();

        public abstract BaseType GetBaseType();
    }
}