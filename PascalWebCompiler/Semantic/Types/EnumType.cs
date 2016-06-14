namespace PascalWebCompiler.Semantic.Types
{
    public class EnumType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is EnumType;
        }
    }
}