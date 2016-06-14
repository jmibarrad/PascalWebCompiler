using System.Collections.Generic;

namespace PascalWebCompiler.Semantic.Types
{
    public class RecordType : BaseType
    {
        public RecordType()
        {
            Properties = new Dictionary<string, BaseType>();
        }

        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is RecordType;
        }

        public Dictionary<string, BaseType> Properties { get; set; }
    }
}