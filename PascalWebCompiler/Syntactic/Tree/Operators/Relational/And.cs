using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Relational
{
    public class And : BinaryOperator
    {
        public And()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(BooleanType, BooleanType), BooleanType);
        }

        public override string GenerateCode()
        {
            return $"{LeftOperand.GenerateCode()} && {RightOperand.GenerateCode()}";
        }

        public override string SemanticError(BaseType leftType, BaseType rightType)
        {
            return $"And is not supported between {leftType} and {rightType} expressions.";
        }
    }
}