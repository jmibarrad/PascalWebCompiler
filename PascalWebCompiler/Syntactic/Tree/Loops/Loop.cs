using System.Collections.Generic;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public abstract class Loop : SentenceNode
    {
         public List<SentenceNode> Statements;
        public abstract override void ValidateNodeSemantic();

        public abstract override string GenerateCode();
    }
}
