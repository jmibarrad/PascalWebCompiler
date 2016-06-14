using System;

namespace PascalWebCompiler.Exceptions
{
    public class SemanticException : Exception
    {
        public SemanticException(string message): base(message){ }
    }
}
