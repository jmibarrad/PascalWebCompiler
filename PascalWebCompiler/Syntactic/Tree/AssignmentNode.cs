using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class AssignmentNode : SentenceNode
    {
        public IdNode ValueIdNode;
        public ExpressionNode Value;

        public override void ValidateNodeSemantic()
        {
            var idType = ValueIdNode.ValidateSemantic();
            var expressionType = Value.ValidateSemantic();

            

            if (!idType.IsAssignable(expressionType)) throw new SemanticException($"Type Mismatch Exception between {idType} and {expressionType}");
            if (SymbolTable.Instance.GetConstant(ValueIdNode.Value)) throw new SemanticException($"Constant variable: {ValueIdNode.Value} can't be assign.");
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}