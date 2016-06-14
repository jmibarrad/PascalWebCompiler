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
            if (idType == Value.ValidateSemantic())
            {
                SymbolTable.Instance.DeclareVariable(IdNode.Value, Type);
            }
            else
            {
                throw new SemanticException("Type Mismatch");
            }

        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}