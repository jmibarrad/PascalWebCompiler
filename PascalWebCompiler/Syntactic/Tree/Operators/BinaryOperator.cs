﻿using System;
using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Operators
{
    public abstract class BinaryOperator : ExpressionNode
    {
        public Dictionary<Tuple<BaseType, BaseType>, BaseType> OperatorRules = new Dictionary<Tuple<BaseType, BaseType>, BaseType>();
        public ExpressionNode RightOperand;
        public ExpressionNode LeftOperand;

        public BaseType IntegerType = TypesTable.Instance.GetType("integer");
        public BaseType StringType = TypesTable.Instance.GetType("string");
        public BaseType RealType = TypesTable.Instance.GetType("real");
        public BaseType BooleanType = TypesTable.Instance.GetType("boolean");

        public override BaseType ValidateSemantic()
        {
            var leftType = LeftOperand.ValidateSemantic();
            var rightType = RightOperand.ValidateSemantic();
            var key = new Tuple<BaseType, BaseType>(leftType, rightType);
            if (OperatorRules.ContainsKey(key))
            {
                return OperatorRules[key];
            }

            throw new SemanticException(SemanticError(leftType, rightType));
        }

        public abstract string SemanticError(BaseType leftType, BaseType rightType);
    }
}
