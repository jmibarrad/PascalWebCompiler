namespace PascalWebCompiler.Semantic.Types
{
    public class ArrayType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is ArrayType;
        }
    }
}