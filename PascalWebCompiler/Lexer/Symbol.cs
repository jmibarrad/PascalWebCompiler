namespace PascalWebCompiler.Lexer
{
    public class Symbol
    {

        public int Row { set; get; }
        public int Column { set; get; }
        public char CurrentSymbol { set; get; }
    }
}
