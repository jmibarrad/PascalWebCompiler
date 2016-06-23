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
        public override void ValidateNodeSemantic()
        {
            var parameters = new List<FunctionParamType>();
            foreach (var parameter in Parameters)
            {
                var paramType = TypesTable.Instance.GetType(parameter.ParamType);
                parameters.Insert(0, new FunctionParamType { ByReference = parameter is ReferenceParam, Type = paramType });
            }
            SymbolTable.Instance.DeclareVariable(ProcedureName, new ProcedureType {FunctionParams = parameters });

            foreach (var statement in Statements)
            {
                statement.ValidateNodeSemantic();
            }
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}