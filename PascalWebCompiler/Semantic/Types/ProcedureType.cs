using System;
using System.Collections.Generic;

namespace PascalWebCompiler.Semantic.Types
{
    public class ProcedureType : BaseType
    {
        public List<FunctionParamType> FunctionParams = new List<FunctionParamType>();

        public override bool IsAssignable(BaseType otherType)
        {
            return false;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string ToJavaString()
        {
            throw new NotImplementedException();
        }
    }
}
