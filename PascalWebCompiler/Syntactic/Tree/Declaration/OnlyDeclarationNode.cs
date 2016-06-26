using System.Collections.Generic;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
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
                if (TypesTable.Instance.GetType(Type) is ArrayType)
                {
                    SymbolTable.Instance.DeclareVariable(idNode.Value, "array");
                    TypesTable.Instance.RegisterType(idNode.Value, TypesTable.Instance.GetType(Type));
                }
                else
                {
                    SymbolTable.Instance.DeclareVariable(idNode.Value, Type);
                }
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
            if(javaType is RecordType)
                return $"{javaType.ToJavaString()} {javaDeclareCode} = new {javaType.ToJavaString()}();";

            return $"{javaType.ToJavaString()} {javaDeclareCode};";
        }
    }
}