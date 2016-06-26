using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.DeclareType
{
    public class TypeDefNode : TypeDeclarationNode
    {
        public string TypeId;

        public override void ValidateNodeSemantic()
        {
            var type = TypesTable.Instance.GetType(TypeId);
            TypesTable.Instance.RegisterType(TypeName, type);

        }

        public override string GenerateCode()
        {
            return $"";
        }

        public override BaseType GetBaseType()
        {
            return TypesTable.Instance.GetType(TypeId);
        }
    }
}
