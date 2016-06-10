using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class ExpressionNode
    {
        
    }

    public class IdNode : ExpressionNode
    {
        public string Value;
        public List<AccesorNode> Accesors;

    }

    public class NumberNode : ExpressionNode
    {
        public int Value;
    }

    public class RealNode : ExpressionNode
    {
        public float Value;
    }

    public class StringLiteralNode : ExpressionNode
    {
        public string Value;
    }

    public class HexNode : ExpressionNode
    {
        public int Value;

    }

    public class BinNode : ExpressionNode
    {
        public int Value;
    }

    public class OctalNode : ExpressionNode
    {
        public int Value;
    }


    public class NotNode : ExpressionNode
    {
        public ExpressionNode ExpressionNode;
    }
}
