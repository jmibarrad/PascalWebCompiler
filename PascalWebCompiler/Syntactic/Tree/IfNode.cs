using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class IfNode : SentenceNode
    {
        public ExpressionNode Condition;
        public List<SentenceNode> FalseStaments = new List<SentenceNode>();
        public List<SentenceNode> TruStatements;
        public override void ValidateNodeSemantic()
        {
            if (Condition.ValidateSemantic() is BooleanType)
            {
                foreach (var sentenceNode in FalseStaments)
                {
                    sentenceNode.ValidateNodeSemantic();
                }

                foreach (var sentenceNode in TruStatements)
                {
                    sentenceNode.ValidateNodeSemantic();
                }
            }
            else
            {
                throw new SemanticException("Not a Boolean type");
            }
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}