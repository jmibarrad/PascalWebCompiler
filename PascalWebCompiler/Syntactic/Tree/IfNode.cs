using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class IfNode : SentenceNode
    {
        public ExpressionNode Condition;
        public List<SentenceNode> FalseStaments = new List<SentenceNode>();
        public List<SentenceNode> TrueStatements;
        public SymbolTable IfSymbolTable = new SymbolTable();
        public SymbolTable ElseSymbolTable = new SymbolTable();

        public override void ValidateNodeSemantic()
        {
            if (Condition.ValidateSemantic() is BooleanType)
            {
                SymbolTable.AddSymbolTable(IfSymbolTable);
                foreach (var sentenceNode in TrueStatements)
                {
                    sentenceNode.ValidateNodeSemantic();
                }
                SymbolTable.RemoveSymbolTable();

                SymbolTable.AddSymbolTable(ElseSymbolTable);
                foreach (var sentenceNode in FalseStaments)
                {
                    sentenceNode.ValidateNodeSemantic();
                }
                SymbolTable.RemoveSymbolTable();
            }
            else
            {
                throw new SemanticException("Not a Boolean type");
            }
        }

        public override string GenerateCode()
        {
            var javaCode = $"if ( {Condition.GenerateCode()} ) {{ \n";
            SymbolTable.AddSymbolTable(IfSymbolTable);

            foreach (var trueStatement in TrueStatements)
            {
                javaCode += trueStatement.GenerateCode();
            }

            javaCode += "} else {\n";
            foreach (var falseStament in FalseStaments)
            {
                javaCode += falseStament.GenerateCode();
            }
            SymbolTable.RemoveSymbolTable();

            return javaCode + '}';
        }
    }
}