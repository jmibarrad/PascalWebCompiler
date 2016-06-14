﻿using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;

namespace PascalWebCompiler.Syntactic.Tree.Expression
{
    public class RealNode : ExpressionNode
    {
        public float Value;
        public override BaseType ValidateSemantic()
        {
            return TypesTable.Instance.GetType("real");
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}