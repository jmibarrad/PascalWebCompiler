namespace PascalWebCompiler.Semantic.Types
{
    public abstract class BaseType
    {
        public abstract bool IsAssignable(BaseType otherType);
    }
}
