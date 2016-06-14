namespace PascalWebCompiler.Semantic.Types
{
    public class StringType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is StringType;
        }

        public override string ToString()
        {
            return "String";
        }
    }
}
