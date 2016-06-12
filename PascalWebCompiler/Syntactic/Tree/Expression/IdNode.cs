using System.Collections.Generic;
using PascalWebCompiler.Syntactic.Tree.ID;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public class IdNode : ExpressionNode
    {
        public string Value;
        public List<AccesorNode> Accesors;

    }
}