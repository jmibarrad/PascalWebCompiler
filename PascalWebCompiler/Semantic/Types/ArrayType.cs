namespace PascalWebCompiler.Semantic.Types
{
    public class ArrayType : BaseType
    {
        public int InferiorLimit { get; set; }
        public int SuperiorLimit { get; set; }

        public BaseType Type { get; set; }

        public override bool IsAssignable(BaseType otherType)
        {
            if (otherType is ArrayType)
            {
                var paramArray = (ArrayType)otherType;
                if (InferiorLimit == paramArray.InferiorLimit && SuperiorLimit == paramArray.SuperiorLimit && Type.IsAssignable(paramArray.Type))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return "Array";
        }

        public override string ToJavaString()
        {
           
            return $"";
        }
    }
}