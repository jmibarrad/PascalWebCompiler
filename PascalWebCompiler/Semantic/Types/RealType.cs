namespace PascalWebCompiler.Semantic.Types
{
    public class RealType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is RealType || otherType is IntegerType;

        }

        public override string ToString()
        {
            return "Real";
        }

        public override string ToJavaString()
        {
            return "double";
        }
    }
}