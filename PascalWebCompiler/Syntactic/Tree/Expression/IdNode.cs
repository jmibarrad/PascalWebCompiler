using System.Collections.Generic;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.ID;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public class IdNode : ExpressionNode
    {
        public string Value;
        public List<AccessorNode> Accesors = new List<AccessorNode>();

        public override BaseType ValidateSemantic()
        {
            var type = SymbolTable.Instance.GetVariable(Value);
            Accesors.Reverse();
            foreach (var accesorNode in Accesors)
            {
                type = accesorNode.Validate(type);
            }

            return type;
        }

        public override string GenerateCode()
        {
            var javaAccesorCode = string.Empty;
            foreach (var accessorNode in Accesors)
            {
                javaAccesorCode += accessorNode.GenerateCode();
            }
            return Value + javaAccesorCode;
        }
    }
}