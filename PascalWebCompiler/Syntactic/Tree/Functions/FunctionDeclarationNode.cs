using System.Collections.Generic;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Params;

namespace PascalWebCompiler.Syntactic.Tree.Functions
{
    public class FunctionDeclarationNode : SentenceNode
    {
        public string FunctionName;
        public List<SentenceNode> Statements;
        public List<Param> Parameters;
        public string Type;
        public SymbolTable FunctionLocalTable = new SymbolTable();

        public override void ValidateNodeSemantic()
        {
            var funcType = TypesTable.Instance.GetType(Type);
            List<FunctionParamType> parameters = new List<FunctionParamType>();
            SymbolTable.Instance.DeclareVariable(FunctionName, new FunctionType { ReturnType = funcType, FunctionParams = parameters });
            SymbolTable.AddSymbolTable(FunctionLocalTable);
            foreach (var parameter in Parameters)
            {
                SymbolTable.Instance.DeclareVariable(parameter.Name, parameter.ParamType);
                var paramType = TypesTable.Instance.GetType(parameter.ParamType);
                parameters.Insert(0, new FunctionParamType {ByReference = parameter is ReferenceParam, Type = paramType});
            }

            foreach (var statement in Statements)
            {
                statement.ValidateNodeSemantic();
            }
            SymbolTable.RemoveSymbolTable();
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}