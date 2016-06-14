using System;
using System.Collections.Generic;
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

        public BaseType IntegerType = SymbolTable.Instance.GetVariable("integer");
        public BaseType StringType = SymbolTable.Instance.GetVariable("string");
        public BaseType RealType = SymbolTable.Instance.GetVariable("real");
        public BaseType ArrayType = SymbolTable.Instance.GetVariable("array");


    }
}
