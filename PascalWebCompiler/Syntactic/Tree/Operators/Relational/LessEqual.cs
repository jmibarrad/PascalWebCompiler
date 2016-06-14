using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Relational
{
    public class LessEqual : BinaryOperator
    {
        public LessEqual()
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
            return $"Less Equal is not supported between {leftType} and {rightType} types.";
        }
    }
}