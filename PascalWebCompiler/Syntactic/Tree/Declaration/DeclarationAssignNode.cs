using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Declaration
{
    public class DeclarationAssignNode : DeclarationNode
    {
        public IdNode IdNode;
        public ExpressionNode Value;
        public override void ValidateNodeSemantic()
        {
            var idType = TypesTable.Instance.GetType(Type);
            var valueType = Value.ValidateSemantic();
            if (idType != valueType) throw new SemanticException($"{idType} and {valueType} ReturnType Mismatch");
            
            SymbolTable.Instance.DeclareVariable(IdNode.Value, Type);
        }

        public override string GenerateCode()
        {
            var javaType = TypesTable.Instance.GetType(Type);
            
            return $"{javaType.ToJavaString()} {IdNode.GenerateCode()} = {Value.GenerateCode()};";
        }
    }
}