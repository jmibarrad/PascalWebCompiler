using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Semantic;
using PascalWebCompiler.Semantic.Types;
using PascalWebCompiler.Syntactic.Tree.Expression;

namespace PascalWebCompiler.Syntactic.Tree.Loops
{
    public class ForInNode : Loop
    {
        public IdNode IdNode;
        public IdNode IdNodeCollection;
        public SymbolTable ForInSymbolTable = new SymbolTable();
        public override void ValidateNodeSemantic()
        {
            var validateSemantic = IdNode.ValidateSemantic();
            if (!(validateSemantic is IntegerType)) throw new SemanticException("Not an Integer type.");

            if (IdNodeCollection.ValidateSemantic() is ArrayType)
            {
                SymbolTable.AddSymbolTable(ForInSymbolTable);
                foreach (var sentenceNode in Statements)
                {
                    sentenceNode.ValidateNodeSemantic();
                }
                SymbolTable.RemoveSymbolTable();
            }
            else
            {
                throw new SemanticException("Not an iterable variable.");
            }
        }

        public override string GenerateCode()
        {
            var collection = (ArrayType)TypesTable.Instance.GetType(IdNodeCollection.Value);
            var collectionBaseType = collection.ToJavaString();
            var forInCode = $"for({collectionBaseType} {IdNode.GenerateCode()} in {IdNodeCollection.GenerateCode()}){{\n";
            foreach (var sentenceNode in Statements)
            {
                forInCode += sentenceNode.GenerateCode()+"\n";
            }
            return forInCode + "}";
        }
    }
}