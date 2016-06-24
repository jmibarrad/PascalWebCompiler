using System;
using System.Collections.Generic;

namespace PascalWebCompiler.Semantic.Types
{
    public class FunctionType : BaseType
    {
        public BaseType ReturnType;
        public List<FunctionParamType> FunctionParams = new List<FunctionParamType>();
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType == ReturnType;
        }

        public override string ToString()
        {
            return "Function";
        }

        public override string ToJavaString()
        {
            throw new NotImplementedException();
        }
    }
}
