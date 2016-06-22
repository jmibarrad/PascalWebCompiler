using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class ForInNode : Loop
    {
        public IdNode IdNode;
        public IdNode IdNodeCollection;

        public override void ValidateNodeSemantic()
        {
            var validateSemantic = IdNode.ValidateSemantic();
            if (!(validateSemantic is IntegerType)) throw new SemanticException("Not an Integer type.");

            if (IdNodeCollection.ValidateSemantic() is ArrayType)
            {
                foreach (var sentenceNode in Statements)
                {
                    sentenceNode.ValidateNodeSemantic();
                }
            }
            else
            {
                throw new SemanticException("Not an iterable variable.");
            }
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}