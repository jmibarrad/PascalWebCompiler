using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Arithmethic
{
    public class Mult : BinaryOperator
    {
        public Mult()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, IntegerType), IntegerType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, RealType), RealType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, IntegerType), RealType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, RealType), RealType);
        }
        public override string GenerateCode()
        {
            return $"{LeftOperand.GenerateCode()} * {RightOperand.GenerateCode()}";

        }

        public override string SemanticError(BaseType leftType, BaseType rightType)
        {
            return $"Multiplication is not supported between {leftType} and {rightType} types.";
        }
    }
}