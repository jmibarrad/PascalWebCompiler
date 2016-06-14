namespace PascalWebCompiler.Semantic.Types
{
    public class StringType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is StringType;
        }
    }
}
