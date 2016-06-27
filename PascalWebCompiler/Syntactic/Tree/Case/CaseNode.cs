using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Case
{
    public class CaseNode : SentenceNode
    {
        public IdNode IdNode { get; set; }
        public List<CaseStatement> CaseStatements;
        public SymbolTable CaseSymbolTable = new SymbolTable();

        public override void ValidateNodeSemantic()
        {
            var idNodeType = IdNode.ValidateSemantic();
            if(!(idNodeType is IntegerType)) throw new SemanticException($"{idNodeType} is not supported on case.");
            foreach (var caseStatement in CaseStatements)
            {
                foreach (var statement in caseStatement.Statements)
                {
                    statement.ValidateNodeSemantic();   
                }
            }
        }

        public override string GenerateCode()
        {
            var caseCode = $"switch ({IdNode.GenerateCode()} ){{\n";
            foreach (var caseStatement in CaseStatements)
            {
                caseCode += caseStatement.GenerateCode();
            }
            return caseCode + "}\n";
        }
        
    }
}