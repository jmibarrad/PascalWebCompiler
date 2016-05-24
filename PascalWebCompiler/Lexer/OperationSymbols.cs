using System.Collections.Generic;

namespace PascalWebCompiler.Lexer
{
    public static class OperationSymbols
    {
        public static Dictionary<string, TokenType> OperationMap = new Dictionary<string, TokenType> {
            { "+", TokenType.SUM },
            { "-", TokenType.SUB },
            { "*" ,TokenType.MULT},
            { "=", TokenType.EQUAL },
            { "[", TokenType.TK_LEFTBRACKET },
            { "]", TokenType.TK_RIGHTBRACKET },
            { ")", TokenType.TK_RIGHTPARENTHESIS },
            { ";", TokenType.EOS },
            { ",", TokenType.TK_COMMA },
            //{ ".", TokenType.TK_PERIOD }

        };
    }
}
