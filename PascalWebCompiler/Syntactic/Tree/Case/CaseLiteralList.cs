using System.Collections.Generic;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Case
{
    public class CaseLiteralList : CaseLiteral
    {
        public List<NumberNode> LiteralList;

        public override string GenerateCode()
        {
            var optionCode = "";
            foreach (var literallist in LiteralList)
            {
                optionCode += $"case {literallist.Value}:\n";
            }
            return optionCode;
        }
    }
}