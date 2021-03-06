using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Relational
{
    public class Equal : BinaryOperator
    {
        public Equal()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, IntegerType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(StringType, StringType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, RealType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, IntegerType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, RealType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(CharType, CharType), BooleanType);
        }
        public override string GenerateCode()
        {
            var leftType = LeftOperand.ValidateSemantic();
            var rightType = RightOperand.ValidateSemantic();
            if(leftType is StringType && rightType is StringType)
                return $"{LeftOperand.GenerateCode()}.equals({RightOperand.GenerateCode()})";

            return $"{LeftOperand.GenerateCode()} == {RightOperand.GenerateCode()}";
        }

        public override string SemanticError(BaseType leftType, BaseType rightType)
        {
            return $"Comparison is not supported between {leftType} and {rightType} types.";
        }
    }
}