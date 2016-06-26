namespace PascalWebCompiler.Semantic.Types
{
    public class BooleanType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is BooleanType;
        }

        public override string ToString()
        {
            return "Boolean";
        }

        public override string ToJavaString()
        {
            return "boolean";
        }
    }
}