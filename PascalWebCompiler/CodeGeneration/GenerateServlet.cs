namespace PascalWebCompiler.CodeGeneration
{
    public static class GenerateServlet
    {
        public static string OuterCode = string.Empty;
        public static string InitServletCode(string code)
        {
            var sourceCode =
@"import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

public class Pascal extends HttpServlet {
 
    "+ OuterCode + @"

    public void init() throws ServletException
    {
      
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType(""""text/html"""");
        PrintWriter out = response.getWriter();
        "+ code + @"
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType(""text/html"");
        PrintWriter out = response.getWriter();
        " + code + @"
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
