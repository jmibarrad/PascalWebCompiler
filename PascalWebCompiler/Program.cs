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
            //text = "<%a1:= a2[i][j];%>";
            //text = "<%for count := 1 to 100 do sum := sum + count;%>";
            //text = "<%repeat\r\n\t\t DoSomethingHere(x);\r\n\t\t x := x + 1;\r\n\t\t while a + 6 do\r\n\t\t  writeln (a);\r\n\t   until x = 10;%>";
            //text = "<%+%>";
            //text = "<%while a < 6 do begin writeln(a); a := a + 1; end;%>";
            //text = "<%a.test := 2*3;%>";
            //text = "<%case place of 1: ShowMessage('sds');2: ShowMessage(sdds);3: ShowMessage(sd.test); else ShowMessage(sdsd);end; %>";
            text = "<%case place of 1: begin ShowMessage('sds'); ShowMessage('sds'); ShowMessage('sds'); end; 2: ShowMessage(sdds); 3 + expureichion(arr[expureichion(arr[4].algo[4][4].dd)]): ShowMessage(sd.test); else ShowMessage(sdsd); end; %>";
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
