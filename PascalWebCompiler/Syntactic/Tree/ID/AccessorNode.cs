using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.ID
{
    public abstract class AccessorNode
    {
        public abstract BaseType Validate(BaseType type);
        public abstract string GenerateCode();

    }
}