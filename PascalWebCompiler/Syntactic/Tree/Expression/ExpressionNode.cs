using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public abstract class ExpressionNode
    {
        public BaseType IntegerType = TypesTable.Instance.GetType("integer");
        public BaseType StringType = TypesTable.Instance.GetType("string");
        public BaseType RealType = TypesTable.Instance.GetType("real");
        public BaseType BooleanType = TypesTable.Instance.GetType("boolean");
        public BaseType CharType = TypesTable.Instance.GetType("char");

        public abstract BaseType ValidateSemantic();
        public abstract string GenerateCode();
    }
}
