using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.ID
{
    public class IndexAccessorNode : AccessorNode
    {
        public ExpressionNode IndexExpression { get; set; }

        public override BaseType Validate(BaseType type)
        {
            if (!(type is ArrayType)) throw new SemanticException("Illegal indexation: variable is not an array.");

            var array = (ArrayType)type;
           
            return array.Type;
        }
    }
}