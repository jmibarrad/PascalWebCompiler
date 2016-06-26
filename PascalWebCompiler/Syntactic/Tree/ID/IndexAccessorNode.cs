using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.ID
{
    public class IndexAccessorNode : AccessorNode
    {
        private ArrayType _accessorType;
        public ExpressionNode IndexExpression { get; set; }

        public override BaseType Validate(BaseType type)
        {
            if (!(type is ArrayType)) throw new SemanticException($"Illegal indexation: {type} is not an array.");

            var array = (ArrayType)type;
            _accessorType = array;
            return array.Type;
        }

        public override string GenerateCode()
        {
            return $"[{IndexExpression.GenerateCode()} - {_accessorType.InferiorLimit}]";
        }
    }
}