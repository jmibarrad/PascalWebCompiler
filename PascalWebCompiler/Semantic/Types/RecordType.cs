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

        public override string ToString()
        {
            return "Record";
        }

        public override string ToJavaString()
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, BaseType> Properties { get; set; }
    }
}