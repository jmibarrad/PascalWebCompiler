using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators
{
    public class NotEqual : BinaryOperator
    {
        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }

        public override BaseType ValidateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}