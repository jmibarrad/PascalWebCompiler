using System.Collections.Generic;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.ID;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public class IdNode : ExpressionNode
    {
        public string Value;
        public List<AccesorNode> Accesors = new List<AccesorNode>();

        public override BaseType ValidateSemantic()
        {
            var type = SymbolTable.Instance.GetVariable(Value);
            foreach (var accesorNode in Accesors)
            {
                type = accesorNode.Validate(type);
            }

            return type;
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}