using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Functions
{
    public class CallProcedureNode : SentenceNode
    {
        public List<ExpressionNode> Parameters;
        public string ProcedureName;
        public override void ValidateNodeSemantic()
        {
            var type = SymbolTable.Instance.GetVariable(ProcedureName);
            if (!(type is ProcedureType)) throw new SemanticException($"{ProcedureName} is not a function.");

            var typeFunction = (ProcedureType)type;
            if (typeFunction.FunctionParams.Count != Parameters.Count) throw new SemanticException($"Argument count dont match on function {ProcedureName}.");

            int index = 0;
            foreach (var parameter in Parameters)
            {
                var paramType = parameter.ValidateSemantic();
                var funcParamType = typeFunction.FunctionParams[index];
                var isIdNode = parameter is IdNode;
                if (isIdNode != funcParamType.ByReference) throw new SemanticException($"Must be by reference.");
                if (paramType.IsAssignable(funcParamType.Type))
                {
                    index++;
                }
            }
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}