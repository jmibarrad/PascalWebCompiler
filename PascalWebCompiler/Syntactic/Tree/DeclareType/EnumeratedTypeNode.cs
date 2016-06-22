using System.Collections.Generic;
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
            throw new System.NotImplementedException();
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
