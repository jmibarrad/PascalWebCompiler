using System.Collections.Generic;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Declaration
{
    public class OnlyDeclarationNode : DeclarationNode
    {
        public List<IdNode> IdNodesList;

        public override void ValidateNodeSemantic()
        {
            foreach (var idNode in IdNodesList)
            {
                SymbolTable.Instance.DeclareVariable(idNode.Value, Type);
            }
        }

        public override string GenerateCode()
        {
            var javaDeclareCode = string.Empty;
            var javaType = TypesTable.Instance.GetType(Type);
            foreach (var idNode in IdNodesList)
            {
                javaDeclareCode += $"{idNode.GenerateCode()},";
            }
            javaDeclareCode = javaDeclareCode.Remove(javaDeclareCode.Length - 1, 1);
            return javaType.ToJavaString() + javaDeclareCode + ";";
        }
    }
}