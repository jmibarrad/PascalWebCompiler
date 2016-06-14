using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public abstract class TypeDeclarationNode : SentenceNode
    {
        public string TypeName;
        public abstract override void ValidateNodeSemantic();

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }

        public abstract BaseType GetBaseType();
    }
}