namespace PascalWebCompiler.Semantic.Types
{
    public class StringType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is StringType || otherType is CharType;
        }

        public override string ToString()
        {
            return "String";
        }

        public override string ToJavaString()
        {
            return "String ";
        }
    }
}
