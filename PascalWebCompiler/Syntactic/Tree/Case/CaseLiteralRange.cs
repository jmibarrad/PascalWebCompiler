using System.Collections.Generic;
using PascalWebCompiler.Syntactic.Tree.DeclareType;

namespace PascalWebCompiler.Syntactic.Tree.Case
{
    public class CaseLiteralRange : CaseLiteral
    {
        public List<Range> LiteralRanges;
        public override string GenerateCode()
        {

            var optionCode = "";
            foreach (var literalRange in LiteralRanges)
            {
                for (int i = literalRange.InferiorLimit.Value; i < literalRange.SuperiorLimit.Value + 1; i++)
                {
                    optionCode += $"case {i}:\n";
                }
            }
            return optionCode;
        }
    }
}