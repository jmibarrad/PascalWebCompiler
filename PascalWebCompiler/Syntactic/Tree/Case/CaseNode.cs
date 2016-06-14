using System.Collections.Generic;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Case
{
    public class CaseNode : SentenceNode
    {
        public IdNode IdNode { get; set; }
        public List<CaseStatement> CaseStatements;
        public override void ValidateNodeSemantic()
        {
            throw new System.NotImplementedException();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}