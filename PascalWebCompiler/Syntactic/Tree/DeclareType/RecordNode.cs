using System.Collections.Generic;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public class RecordNode : TypeDeclarationNode
    {
        public List<TypeDeclarationNode> RecordProperties;
    }
}