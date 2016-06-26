using System;
using System.IO;
using System.Text;
using PascalWebCompiler.CodeGeneration;
using PascalWebCompiler.Lexer;
using PascalWebCompiler.Syntactic;

namespace PascalWebCompiler
{
    public class Program
    {

        static void Main()
        {
         
            string text;
            //var fileStream = new FileStream(@"C:\Users\IBARRA\Documents\Pascal\pascalTest.pas", FileMode.Open, FileAccess.Read);
            var fileStream = new FileStream(@"C:\Users\IBARRA\Documents\Pascal\Example2.pas", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd();
            }

            Console.WriteLine("Compile Pascal to Java...");
            Lexer.Lexer lexer = new Lexer.Lexer(new SourceCodeContent(text));
            Console.WriteLine("Lexer: Succeed.");
            var parser = new SyntacticParser(lexer);
            Console.WriteLine("Syntatic: Succeed.");
            try
            {
                var tree = parser.Parse();
                var servletCode = "";
                foreach (var sentenceNode in tree)
                {
                    sentenceNode.ValidateNodeSemantic();
                    servletCode += sentenceNode.GenerateCode() + '\n';
                }
                Console.WriteLine("Semantic: Succeed.");

                using (StreamWriter writer = new StreamWriter("C:\\Users\\IBARRA\\Documents\\Pascal\\servlet.java", false))
                {
                    writer.WriteLine(GenerateServlet.InitServletCode(servletCode));
                }
                Console.WriteLine("Code Generation: Succeed.");

            }
            catch (Exception e)
            {
                Console.WriteLine("\n\n Encountered Error.");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Console.ReadKey();
        }
    }
}
