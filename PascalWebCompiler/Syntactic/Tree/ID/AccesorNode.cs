using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.ID
{
    public abstract class AccesorNode
    {
        public abstract BaseType Validate(BaseType type);
    }
}