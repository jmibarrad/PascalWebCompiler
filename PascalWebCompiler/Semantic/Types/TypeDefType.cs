namespace PascalWebCompiler.Semantic.Types
{
    public class TypeDefType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is TypeDefType;
        }

        public override string ToString()
        {
            return "TypeDef";
        }

        public override string ToJavaString()
        {
            throw new System.NotImplementedException();
        }
    }
}