using System.Collections.Generic;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public class RecordNode : TypeDeclarationNode
    {
        public List<TypeDeclarationNode> RecordProperties;
        public override void ValidateNodeSemantic()
        {
            var record = new RecordType();
            foreach (var typeDeclarationNode in RecordProperties)
            {
                record.Properties.Add(typeDeclarationNode.TypeName, typeDeclarationNode.GetBaseType());
            }
            TypesTable.Instance.RegisterType(TypeName, record);
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }

        public override BaseType GetBaseType()
        {
            var record = new RecordType();
            foreach (var typeDeclarationNode in RecordProperties)
            {
                record.Properties.Add(typeDeclarationNode.TypeName, typeDeclarationNode.GetBaseType());
            }

            return record;
        }
    }
}