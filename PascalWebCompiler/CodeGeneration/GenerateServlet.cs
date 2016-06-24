using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalWebCompiler.CodeGeneration
{
    public static class GenerateServlet
    {
        public static string InitServletCode(string code)
        {
            var sourceCode =
@"import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class HelloWorld extends HttpServlet {
 
    private String message;

    public void init() throws ServletException
    {
      
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType(""""text/html"""");
        PrintWriter out = response.getWriter();
        ""+ code +@""
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType(""text/html"");
        PrintWriter out = response.getWriter();
        " + code +@"
    }

    public void destroy()
    {
        // do nothing.
    }
}";

            return sourceCode;
        }
    }
}
