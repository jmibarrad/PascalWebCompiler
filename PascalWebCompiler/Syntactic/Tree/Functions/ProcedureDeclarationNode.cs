using System.Collections.Generic;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Params;

namespace PascalWebCompiler.Syntactic.Tree.Functions
{
    public class ProcedureDeclarationNode : SentenceNode
    {
        public string ProcedureName;
        public List<SentenceNode> Statements;
        public List<Param> Parameters;
        public SymbolTable ProcedureLocalTable = new SymbolTable();
        public override void ValidateNodeSemantic()
        {
            var parameters = new List<FunctionParamType>();
            SymbolTable.Instance.DeclareVariable(ProcedureName, new ProcedureType { FunctionParams = parameters });
            SymbolTable.AddSymbolTable(ProcedureLocalTable);
            foreach (var parameter in Parameters)
            {
                SymbolTable.Instance.DeclareVariable(parameter.Name, parameter.ParamType);
                var paramType = TypesTable.Instance.GetType(parameter.ParamType);
                parameters.Insert(0, new FunctionParamType { ByReference = parameter is ReferenceParam, Type = paramType });
            }

            foreach (var statement in Statements)
            {
                statement.ValidateNodeSemantic();
            }
            SymbolTable.RemoveSymbolTable();
        }

        public override string GenerateCode()
        {
            var declareFunctionCode = $"public void _{ProcedureName} (";
            foreach (var parameter in Parameters)
            {
                var paramType = TypesTable.Instance.GetType(parameter.ParamType).ToJavaString();
                declareFunctionCode += $"{paramType} _{parameter.Name},";
            }
            declareFunctionCode = declareFunctionCode.Remove(declareFunctionCode.Length - 1, 1) + "){\n";
            foreach (var sentenceNode in Statements)
            {
                declareFunctionCode += sentenceNode.GenerateCode() + "\n";
            }
            CodeGeneration.GenerateServlet.FunctionCode += declareFunctionCode + "}\n";
            return string.Empty;
        }
    }
}