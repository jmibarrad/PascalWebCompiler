using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Semantic
{
    public static class MyClonable
    {
        public static Tuple<string, string> Clone(string objectName)
        {
            var cloneObject = string.Empty;
            var objectType = SymbolTable.Instance.GetVariable(objectName);
            if (objectType is ArrayType)
            {
                cloneObject = $"({objectName}).clone();";
            }
            else if (objectType is RecordType)
            {
                var type = TypesTable.Instance.GetType(((RecordType) objectType).RecordName);

                cloneObject = $"new {type.ToJavaString()}({objectName});";
            }


            return new Tuple<string, string>(cloneObject, $"clone{objectName}");
        }
    }
}
