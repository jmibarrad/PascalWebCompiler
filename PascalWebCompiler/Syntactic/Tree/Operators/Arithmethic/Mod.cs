using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Arithmethic
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

        public override string SemanticError(BaseType leftType, BaseType rightType)
        {
            return $"Modulus is not supported between {leftType} and {rightType} types.";
        }
    }
}