using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Arithmethic
{
    public class Div : BinaryOperator
    {
        public Div()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, IntegerType), IntegerType);
        }

        public override string SemanticError(BaseType leftType, BaseType rightType)
        {
            return $"Whole Division is not supported between {leftType} and {rightType} types.";
        }

        public override string GenerateCode()
        {
            return $"{LeftOperand.GenerateCode()} / {RightOperand.GenerateCode()}";
        }
    }
}