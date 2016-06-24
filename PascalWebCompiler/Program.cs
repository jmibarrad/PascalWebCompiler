﻿using System;
using System.IO;
using System.Text;
using PascalWebCompiler.Lexer;
using PascalWebCompiler.Syntactic;

namespace PascalWebCompiler
{
    public class Program
    {

        static void Main()
        {
         
            string text;
            var fileStream = new FileStream(@"C:\Users\IBARRA\Documents\Pascal\pascalTest.pas", FileMode.Open, FileAccess.Read);
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
            //text = "<%case place of 1..2: ShowMessage('sds');3..4: ShowMessage(sdds);5..6: ShowMessage(sd.test); else ShowMessage(sdsd);end; %>";
            //text = "<%case place of 1: begin ShowMessage('sds'); ShowMessage('sds'); ShowMessage('sds'); end; 2: ShowMessage(sdds); 3 + expureichion(arr[expureichion(arr[4].algo[4][4].dd)]): ShowMessage(sd.test); else ShowMessage(sdsd); end; %>";
            //text = "<%shit(shit(5));%>";
            //text = "<%var id : Integer;%>";
            //text = "<%id := 5+4%>";
            //text = "<%case c of 1..4 : s:= 'lowercase letter (a-z)'; 100..400 : s:= 'lowercase letter (a-z)'; 4..5 : s:= 'lowercase letter (a-z)'; 400: s:= '400 case'; end; %> '";
            //text = "<%case c of r : s:= 'lowercase letter (a-z)'; a,b,c : s:= 'lowercase letter (a-z)'; a : s:= 'lowercase letter (a-z)'; 400: s:= '400 case'; end; %> '";
            //text = "<%type simpleintegerarray = array [4..33, 34..99] of integer;%>";
            /*text = @"<% 
                    for x in x[23].ry[5].z do    
                        if x < 19 then
                        begin 
                            var x,r,y : integer;
                            var x : integer = 12; 
                        end;
                        else
                            const p : integer = 14 +15;
                    const m = 14 * 15;%>";*/
            /*text = @"<% 
                    procedure max(var num1, num2: integer; str, str2 : StriNg);
                    begin
                        var result: integer = 3;
                       (* local variable declaration *)
                       if (num1 > num2) then
                          result := num1;
                       else
                          result := num2;

                       for i:= 1 to 10 do writeln(i);

                       for Color in TColor do
                        DoSomething(Color);

                       max := result;
                    end;%>";*/
            //text = "<%type dias = (lunes, martes, miercoles, jueves, viermes, sabado, domingo);%>";
            //text = "<%type myArray = array [1..2, 3..4] of integer;%>";
            /*text = @"<%type TMember = record
		        firstname: string;
		        address: array [1 .. 3] of string;
		        phone: string;
		        birthdate: TDateTime;
		        paidCurrentSubscription: boolean;
	        end;%>";*/

            //text = @"<%
            //            type perrito = Integer;
            //            var x,y,z : perrito; 
            //            var m : Integer = 12; 
            //            z := 23;
            //            type days = (lunes, martes, miercoles, jueves, viermes, sabado, domingo);
            //            while true do begin end;
            //            if true then  repeat until true; else  for x:= 1 to 10 do var t: integer;
            //            type persona = record 
            //                firstname : string;
            //                month : (jan, feb, mar, apr, oct);
            //            end;
            //        %>";
            Lexer.Lexer lexer = new Lexer.Lexer(new SourceCodeContent(text));
            var parser = new SyntacticParser(lexer);
            try
            {
                var tree = parser.Parse();
                var servletCode = "";
                foreach (var sentenceNode in tree)
                {
                    sentenceNode.ValidateNodeSemantic();
                    //servletCode += sentenceNode.GenerateCode();
                }

                using (StreamWriter writer = new StreamWriter("C:\\Users\\IBARRA\\Documents\\Pascal\\servlet.java", true))
                {
                    //writer.WriteLine(servletCode);
                }
                Console.WriteLine("No errors found.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Console.ReadKey();
        }
    }
}
