namespace PascalWebCompiler.Semantic.Types
{
    public class EnumType : BaseType
    {
        public string Name { get; set; }
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
            return $"_{Name}";
        }
    }
}