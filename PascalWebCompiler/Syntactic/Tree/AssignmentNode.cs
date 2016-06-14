using PascalWebCompiler.Exceptions;
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
            if (idType != Value.ValidateSemantic())
            {
                throw new SemanticException("Type Mismatch Exception");
            }
        }
        
        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}