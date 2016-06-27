using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
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
            if (javaType is EnumType) { 
                BaseType enumType = (EnumType) javaType;
                return $"{javaType.ToJavaString()} {IdNode.GenerateCode()} = {enumType.ToJavaString()}.{Value.GenerateCode()};";
            }

            return $"{javaType.ToJavaString()} {IdNode.GenerateCode()} = {Value.GenerateCode()};";
        }
    }
}