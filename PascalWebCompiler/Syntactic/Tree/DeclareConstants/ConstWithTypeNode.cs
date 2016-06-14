using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareConstants
{
    public class ConstWithTypeNode : ConstNode
    {
        public string Type;
        public override void ValidateNodeSemantic()
        {
            var idType = TypesTable.Instance.GetType(Type);
            var expreType = Expression.ValidateSemantic();
            if (!(expreType is IntegerType || expreType is BooleanType || expreType is StringType || expreType is RealType))
                throw new SemanticException($"{expreType} can't be assigned to the constant {IdNode.Value}");

            if (idType == expreType)
            {
                SymbolTable.Instance.DeclareVariable(IdNode.Value, Type);
                SymbolTable.Instance.AddConstant(IdNode.Value);
            }
            else
            {
                throw new SemanticException($"Type Mismatch Exception: Expression can't be assigned to {idType}");
            }
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}