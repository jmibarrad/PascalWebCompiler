namespace PascalWebCompiler.Semantic.Types
{
    public class TypeDefType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is TypeDefType;
        }
    }
}