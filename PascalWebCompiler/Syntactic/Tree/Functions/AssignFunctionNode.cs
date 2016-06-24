using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Functions
{
    public class AssignFunctionNode : ExpressionNode
    {
        public List<ExpressionNode> Parameters;
        public string FunctionName;
        public override BaseType ValidateSemantic()
        {
            var type = SymbolTable.Instance.GetVariable(FunctionName);
            if(!(type is FunctionType)) throw new SemanticException($"{FunctionName} is not a function.");

            var typeFunction = (FunctionType) type;
            if (typeFunction.FunctionParams.Count != Parameters.Count) throw new SemanticException($"Argument count dont match on function {FunctionName}.");

            int index = 0;
            foreach (var parameter in Parameters)
            {
                var paramType = parameter.ValidateSemantic();
                var funcParamType = typeFunction.FunctionParams[index];
                var isIdNode = parameter is IdNode;
                if(funcParamType.ByReference && !isIdNode) throw new SemanticException($"{parameter} must be by reference.");
                if (paramType.IsAssignable(funcParamType.Type))
                {
                    index++;
                }
            }
            return typeFunction.ReturnType;
        }

        public override string GenerateCode()
        {
            throw new System.NotImplementedException();
        }
    }
}