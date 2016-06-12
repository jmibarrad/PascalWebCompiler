using System.Collections.Generic;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class IfNode : SentenceNode
    {
        public ExpressionNode Condition;
        public List<SentenceNode> FalseStaments;
        public List<SentenceNode> TruStatements;
    }
}