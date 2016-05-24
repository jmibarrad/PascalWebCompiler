using System;
using System.Runtime.Serialization;
using PascalWebCompiler.Lexer;

namespace PascalWebCompiler.Exceptions
{
    [Serializable]
    internal class LexicalException : Exception
    {
        private Symbol currentSymbol;

        public LexicalException(string message) : base(message)
        {
        }

        public LexicalException(Symbol currentSymbol)
        {
            this.currentSymbol = currentSymbol;
        }

        public LexicalException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LexicalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
