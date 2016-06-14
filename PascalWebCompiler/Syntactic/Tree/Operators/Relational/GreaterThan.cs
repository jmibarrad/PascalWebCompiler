using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Relational
{
    public class GreaterThan : BinaryOperator
    {
        public GreaterThan()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, IntegerType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, RealType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, IntegerType), BooleanType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, RealType), BooleanType);
        }
        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }

        public override string SemanticError(BaseType leftType, BaseType rightType)
        {
            return $"Greater Than is not supported between {leftType} and {rightType} types.";
        }
    }
}