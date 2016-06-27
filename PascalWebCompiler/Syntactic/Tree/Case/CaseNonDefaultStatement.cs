namespace PascalWebCompiler.Syntactic.Tree.Case
{
    public class CaseNonDefaultStatement : CaseStatement
    {
        public CaseLiteral Literals;

        public override string GenerateCode()
        {

            var eachStatement = Literals.GenerateCode();
            foreach (var sentenceNode in Statements)
            {
                eachStatement += sentenceNode.GenerateCode() + "\n";
            }
            return eachStatement + "break;";
        }
    }
}