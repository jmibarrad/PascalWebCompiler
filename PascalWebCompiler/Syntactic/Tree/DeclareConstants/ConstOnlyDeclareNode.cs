using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareConstants
{
    public class ConstOnlyDeclareNode : ConstNode
    {
        public override void ValidateNodeSemantic()
        {
            var expreType = Expression.ValidateSemantic();
            if (!(expreType is IntegerType || expreType is BooleanType || expreType is StringType || expreType is RealType))
                throw new SemanticException($"{expreType} can't be assigned to the constant {IdNode.Value}");

            var type = expreType.ToString().ToLower(); 
            SymbolTable.Instance.DeclareVariable(IdNode.Value, type);
            SymbolTable.Instance.AddConstant(IdNode.Value);
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}