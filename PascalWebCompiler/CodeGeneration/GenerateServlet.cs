namespace PascalWebCompiler.CodeGeneration
{
    public static class GenerateServlet
    {
        public static string OuterCode = string.Empty;
        public static string FunctionCode = string.Empty;

        public static string InitServletCode(string code)
        {
            var sourceCode =
@"import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;


public class servlet extends HttpServlet {
 
" + OuterCode + @"
    
    " + FunctionCode + @"

    public void init() throws ServletException
    {
      
    }

    public void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        String method = ""post"";
        response.setContentType(""text/html"");
        PrintWriter out = response.getWriter();
        " + code + @"
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        String method = ""get"";
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
