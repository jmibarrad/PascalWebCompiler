using System.Collections.Generic;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class GetFormDataNode : ExpressionNode
    {
        public string Parameter;

        public override BaseType ValidateSemantic()
        {
            return TypesTable.Instance.GetType("string");
        }

        public override string GenerateCode()
        {
            var thisParam = Parameter.Remove(0, 1);
            thisParam = thisParam.Remove(thisParam.Length - 1, 1);
            return $"request.getParameter(\"{thisParam}\")";
        }
    }
}