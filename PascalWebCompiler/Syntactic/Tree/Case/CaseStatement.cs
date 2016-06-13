using System.Collections.Generic;

namespace PascalWebCompiler.Syntactic.Tree.Case
{
    public abstract class CaseStatement
    {
       
        public List<SentenceNode> Statements { get; set; }
    }
}