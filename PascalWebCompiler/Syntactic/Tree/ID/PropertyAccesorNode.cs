using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.ID
{
    public class PropertyAccesorNode : AccesorNode
    {
        public IdNode IdNode { get; set; }

        public override BaseType Validate(BaseType type)
        {
            if (!(type is RecordType)) throw new SemanticException("It not a record type");
            
            var recordType = (RecordType) type;
         
            if(!recordType.Properties.ContainsKey(IdNode.Value)) throw new SemanticException($"property {IdNode.Value} does not exit in record");

            return recordType.Properties[IdNode.Value];
        }
    }
}