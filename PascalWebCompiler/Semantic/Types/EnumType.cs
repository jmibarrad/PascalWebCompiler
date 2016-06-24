namespace PascalWebCompiler.Semantic.Types
{
    public class EnumType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is EnumType;
        }

        public override string ToString()
        {
            return "Enum";
        }

        public override string ToJavaString()
        {
            throw new System.NotImplementedException();
        }
    }
}