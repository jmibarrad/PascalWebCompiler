using System.Collections.Generic;
using PascalWebCompiler.CodeGeneration;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public class EnumeratedTypeNode : TypeDeclarationNode
    {
        public List<string> EnumList;
        public override void ValidateNodeSemantic()
        {

            TypesTable.Instance.RegisterType(TypeName, new EnumType());
            foreach (var enumNode in EnumList)
            {
                SymbolTable.Instance.DeclareVariable(enumNode, TypeName);
                SymbolTable.Instance.AddConstant(enumNode);
            }
        }

        public override string GenerateCode()
        {
            EnumList.Reverse();
            var enumCode = $"public enum _{TypeName} {{ \n";
            foreach (var enumNode in EnumList)
            {
                enumCode += "_" + enumNode + ",";
            }
            enumCode = enumCode.Remove(enumCode.Length - 1, 1) +"\n}\n";
            GenerateServlet.OuterCode += enumCode;
            return string.Empty;
        }

        public override BaseType GetBaseType()
        {
            TypesTable.Instance.RegisterType(TypeName, new EnumType());
            foreach (var enumNode in EnumList)
            {
                SymbolTable.Instance.DeclareVariable(enumNode, TypeName);
                SymbolTable.Instance.AddConstant(enumNode);

            }
            return new EnumType();
        }
    }
}
