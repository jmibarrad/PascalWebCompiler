using System.Collections.Generic;
using PascalWebCompiler.CodeGeneration;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public class RecordNode : TypeDeclarationNode
    {
        public List<TypeDeclarationNode> RecordProperties;
        public override void ValidateNodeSemantic()
        {
            var record = new RecordType {RecordName = TypeName};
            foreach (var typeDeclarationNode in RecordProperties)
            {
                record.Properties.Add(typeDeclarationNode.TypeName, typeDeclarationNode.GetBaseType());
            }
            TypesTable.Instance.RegisterType(TypeName, record);
        }

        public override string GenerateCode()
        {
            var recordCode = $"class {TypeName} (){{\n";
            foreach (var typeDeclarationNode in RecordProperties)
            {
                recordCode += typeDeclarationNode.GenerateCode();
            }
            GenerateServlet.OuterCode += $"{recordCode} \n}}\n";
            return string.Empty;
        }

        public override BaseType GetBaseType()
        {
            var record = new RecordType {RecordName = TypeName};
            foreach (var typeDeclarationNode in RecordProperties)
            {
                record.Properties.Add(typeDeclarationNode.TypeName, typeDeclarationNode.GetBaseType());
            }

            return record;
        }
    }
}