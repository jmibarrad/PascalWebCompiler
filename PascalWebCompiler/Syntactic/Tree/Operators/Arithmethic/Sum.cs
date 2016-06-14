using System;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Operators.Arithmethic
{
    public class Sum : BinaryOperator
    {

        public Sum()
        {
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, IntegerType), IntegerType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(StringType, StringType), StringType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(StringType, IntegerType), StringType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, StringType), StringType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, RealType), RealType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(RealType, IntegerType), RealType);
            OperatorRules.Add(new Tuple<BaseType, BaseType>(IntegerType, RealType), RealType);

        }
        public override string GenerateCode()
        {
            throw new NotImplementedException();
        }

        public override string SemanticError(BaseType leftType, BaseType rightType)
        {
            return $"Addition is not supported between {leftType} and {rightType} types.";
        }
    }
}