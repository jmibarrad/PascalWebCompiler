using System;
using PascalWebCompiler.Lexer;
using PascalWebCompiler.Syntactic;

namespace PascalWebCompiler
{
    class Program
    {

        static void Main(string[] args)
        {
            Lexer.Lexer _lexer = new Lexer.Lexer(new SourceCodeContent("<%type array = array [1..3] of array [1..5] of integer;%>"));
            var parser = new SyntacticParser(_lexer);
            parser.Parse();
            Console.ReadKey();

        }
    }
}
