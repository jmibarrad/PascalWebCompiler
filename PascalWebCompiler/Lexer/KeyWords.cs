using System.Collections.Generic;

namespace PascalWebCompiler.Lexer
{
    public static class KeyWords
    {

        public static Dictionary<string, TokenType> KwMap = new Dictionary<string, TokenType> {
            { "program", TokenType.KW_PROGRAM },
            { "function", TokenType.KW_FUNCTION },
            { "procedure", TokenType.KW_PROCEDURE },
            { "begin", TokenType.KW_BEGIN },
            { "end", TokenType.KW_END },
            { "if", TokenType.KW_IF },
            { "else", TokenType.KW_ELSE },
            { "then", TokenType.KW_THEN },
            { "integer", TokenType.ID },
            { "string", TokenType.ID },
            { "real", TokenType.ID },
            { "boolean", TokenType.ID },
            { "char", TokenType.ID },
            { "case", TokenType.KW_CASE },
            { "div", TokenType.DIV },
            { "mod", TokenType.MOD },
            { "not", TokenType.KW_NOT },
            { "and", TokenType.KW_AND },
            { "or", TokenType.KW_OR },
            { "until", TokenType.KW_UNTIL },
            { "nil", TokenType.KW_NIL },
            { "const", TokenType.KW_CONST },
            { "while", TokenType.KW_WHILE },
            { "for", TokenType.KW_FOR },
            { "do", TokenType.KW_DO },
            { "in", TokenType.KW_IN },
            { "array", TokenType.KW_ARRAY },
            { "of", TokenType.KW_OF },
            { "record", TokenType.KW_RECORD },
            { "var", TokenType.KW_VAR },
            { "type", TokenType.KW_TYPE },
            { "to", TokenType.KW_TO },
            { "repeat", TokenType.KW_REPEAT },
            { "true", TokenType.KW_TRUE },
            { "false", TokenType.KW_FALSE }

        };

    }
}
