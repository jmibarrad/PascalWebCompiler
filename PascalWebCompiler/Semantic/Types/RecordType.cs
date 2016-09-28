using System.Collections.Generic;

namespace PascalWebCompiler.Semantic.Types
{
    public class RecordType : BaseType
    {
        public string RecordName;
        public RecordType()
        {
            Properties = new Dictionary<string, BaseType>();
        }

        public override bool IsAssignable(BaseType otherType)
        {
            if (!(otherType is RecordType))
                return false;

            return RecordName == ((RecordType)otherType).RecordName;
        }

        public override string ToString()
        {
            return "Record";
        }

        public override string ToJavaString()
        {
            return $"_{RecordName}";
        }

        public Dictionary<string, BaseType> Properties { get; set; }
    }
}