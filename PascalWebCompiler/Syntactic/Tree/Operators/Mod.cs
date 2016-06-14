using System;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators
{
    public class Mod : BinaryOperator
    {
        public Mod()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, IntegerType), IntegerType);
        }
        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }

        public override BaseType ValidateSemantic()
        {
            var leftType = LeftOperand.ValidateSemantic();
            var rightType = RightOperand.ValidateSemantic();
            var key = new Tuple<BaseType, BaseType>(leftType, rightType);
            if (OperatorRules.ContainsKey(key))
            {
                return OperatorRules[key];
            }

            throw new SemanticException($"Modulus is not supported for {leftType} and {rightType}");
        }
    }
}