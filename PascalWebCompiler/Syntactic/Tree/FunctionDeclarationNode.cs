using System.Collections.Generic;
using PascalWebCompiler.Syntactic.Tree.Params;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class FunctionDeclarationNode : SentenceNode
    {
        public string FunctionName;
        public List<SentenceNode> Statements;
        public List<Param> Parameters;
        public string Type;

    }
}