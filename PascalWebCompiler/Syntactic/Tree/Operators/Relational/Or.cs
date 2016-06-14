using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Relational
{
    public class Or : BinaryOperator
    {
        public Or()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(BooleanType, BooleanType), BooleanType);
        }

        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }

        public override string SemanticError(BaseType leftType, BaseType rightType)
        {
            return $"Or is not supported between {leftType} and {rightType} expressions.";
        }
    }
}