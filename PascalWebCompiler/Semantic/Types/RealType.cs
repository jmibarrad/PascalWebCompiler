﻿namespace PascalWebCompiler.Semantic.Types
{
    public class RealType : BaseType
    {
        public override bool IsAssignable(BaseType otherType)
        {
            return otherType is RealType;

        }

        public override string ToString()
        {
            return "Real";
        }
    }
}