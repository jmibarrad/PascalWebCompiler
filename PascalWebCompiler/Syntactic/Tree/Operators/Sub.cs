using System;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators
{
    public class Sub : BinaryOperator
    {

        public Sub()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, IntegerType), IntegerType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, RealType), RealType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, IntegerType), RealType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, RealType), RealType);
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

            throw new SemanticException($"Substraction is not supported for {leftType} and {rightType}");
        }
    }
}