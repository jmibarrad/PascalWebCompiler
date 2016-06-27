namespace PascalWebCompiler.Syntactic.Tree.Case
{
    public class CaseDefaultStatement : CaseStatement
    {
        public override string GenerateCode()
        {
            var defaultCode = $"default: ";
            foreach (var sentenceNode in Statements)
            {
                defaultCode += sentenceNode.GenerateCode() + "\n";
            }
            return defaultCode + "break;";
        }
    }
}