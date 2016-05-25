using System;
using System.IO;
using System.Text;
using PascalWebCompiler.Lexer;
using PascalWebCompiler.Syntactic;

namespace PascalWebCompiler
{
    public class Program
    {

        static void Main(string[] args)
        {
            
            string text;
            var fileStream = new FileStream(@"C:\Users\IBARRA\Documents\Pascal\Example2.pas", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }
            Lexer.Lexer lexer = new Lexer.Lexer(new SourceCodeContent(text));
            var parser = new SyntacticParser(lexer);
            try
            {
                parser.Parse();
                Console.WriteLine("No errors found.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
