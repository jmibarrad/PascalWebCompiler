using System;

namespace PascalWebCompiler.Exceptions
{

    internal class SyntaxException : Exception
    {
        public SyntaxException(string message): base(message){}

    }    

}
