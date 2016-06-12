using System.Collections.Generic;
using PascalWebCompiler.Syntactic.Tree.Params;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class ProcedureDeclarationNode : SentenceNode
    {
        public string ProcedureName;
        public List<SentenceNode> Statements;
        public List<Param> Parameters;
    }
}