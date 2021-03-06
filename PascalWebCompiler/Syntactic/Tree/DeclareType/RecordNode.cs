﻿using System.Collections.Generic;
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
            var recordCode = $"class _{TypeName}{{\n";
            foreach (var typeDeclarationNode in RecordProperties)
            {
                recordCode += typeDeclarationNode.GenerateCode();
                if (typeDeclarationNode.GetBaseType() is RecordType)
                {
                    var recordType = (RecordType) typeDeclarationNode.GetBaseType();
                    recordCode += $"_{recordType.RecordName} _{recordType.RecordName} = new _{recordType.RecordName}();\n";
                }
            }
            var constructors = $"public _{TypeName}(){{ \n}}\n";
            var copyConstructor = $"public _{TypeName}(_{TypeName} originalCopy){{\n";
            foreach (var typeDeclarationNode in RecordProperties)
            {
                copyConstructor += $"this._{typeDeclarationNode.TypeName} = originalCopy._{typeDeclarationNode.TypeName};\n";
            }
            GenerateServlet.OuterCode += $"{recordCode}{constructors}{copyConstructor} }}\n}}\n";
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