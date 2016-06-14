namespace PascalWebCompiler.Semantic.Types
{
    public class IntegerType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is IntegerType;
        }
    }
}
