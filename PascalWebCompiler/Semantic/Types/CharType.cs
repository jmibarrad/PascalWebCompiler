namespace PascalWebCompiler.Semantic.Types
{
    public class CharType: BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is CharType;
        }

        public override string ToString()
        {
            return "Char";
        }
    }
}