using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Relational
{
    public class LessThan : BinaryOperator
    {
        public LessThan()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, IntegerType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, RealType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, IntegerType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, RealType), BooleanType);
        }
        public override string GenerateCode()
        {
            return $"{LeftOperand.GenerateCode()} < {RightOperand.GenerateCode()}";
        }

        public override string SemanticError(BaseType leftType, BaseType rightType)
        {
            return $"Less Than is not supported between {leftType} and {rightType} types.";
        }
    }
}