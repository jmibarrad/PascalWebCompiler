using System;
using System.Text.RegularExpressions;
using PascalWebCompiler.Exceptions;

namespace PascalWebCompiler.Lexer
{

   
    public class Lexer
    {
        public SourceCodeContent Content;
        private Symbol _currentSymbol;
        private bool _pascalCode = false;



        public Lexer(SourceCodeContent content)
        {
            Content = content;
            _currentSymbol = content.NextSymbol();
        }

        public Token GetNextToken()
        {
            var state = _pascalCode ? 0 : 23 ;
            var lexeme = "";
            var tokenRow = 0;
            var tokenColumn = 0;

            while (true)
            {
                switch (state)
                {
                    case 0:
                        if (_currentSymbol.CurrentSymbol == '\0')
                        {
                            state = 6;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme = "$";
                        }
                        else if (char.IsWhiteSpace(_currentSymbol.CurrentSymbol))
                        {
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (char.IsLetter(_currentSymbol.CurrentSymbol))
                        {
                            state = 1;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (char.IsDigit(_currentSymbol.CurrentSymbol))
                        {
                            state = 2;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (OperationSymbols.OperationMap.ContainsKey(_currentSymbol.CurrentSymbol.ToString()))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            _currentSymbol = Content.NextSymbol();
                            state = 5;
                        }
                        else if (_currentSymbol.CurrentSymbol == '\'')
                        {
                            state = 3;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '$')
                        {
                            state = 7;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '%')
                        {
                            state = 8;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '&')
                        {
                            state = 16;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == ':')
                        {
                            state = 9;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '<')
                        {
                            state = 10;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '>')
                        {
                            state = 11;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '.')
                        {
                            state = 12;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '{')
                        {
                            state = 13;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '(')
                        {
                            state = 17;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '/')
                        {
                            state = 20;
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else
                        {
                            throw new LexicalException($"Symbol {_currentSymbol.CurrentSymbol} not recognized at Row:{_currentSymbol.Row} Col: {_currentSymbol.Column}");
                        }
                        break;
                    case 1:
                        if (char.IsLetterOrDigit(_currentSymbol.CurrentSymbol))
                        {
                            state = 1;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else
                        {
                            if (KeyWords.KwMap.ContainsKey(lexeme))
                                return new Token { Type = KeyWords.KwMap[lexeme.ToLower()], Lexeme = lexeme.ToLower(), Column = tokenColumn, Row = tokenRow };
                            
                            return new Token { Type = TokenType.ID, Lexeme = lexeme.ToLower(), Column = tokenColumn, Row = tokenRow };
                        }
                        break;
                    case 2:
                        if (char.IsDigit(_currentSymbol.CurrentSymbol))
                        {
                            state = 2;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else
                        {
                            return new Token { Type = TokenType.NUMBER_LITERAL, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        break;
                    case 3:
                        if (_currentSymbol.CurrentSymbol != '\'')
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else if (_currentSymbol.CurrentSymbol == '\'')
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            return new Token { Type = TokenType.STRING_LITERAL, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }

                        break;
                    case 5:
                        if (OperationSymbols.OperationMap.ContainsKey(lexeme))
                            return new Token { Type = OperationSymbols.OperationMap[lexeme], Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        break;
                    case 6:
                        return new Token { Type = TokenType.EOF, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                    case 7:
                        if (IsHex(_currentSymbol.CurrentSymbol.ToString()))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else
                        {
                            return new Token { Type = TokenType.HEX, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                       
                        break;
                    case 8:
                        if (IsBinary(_currentSymbol.CurrentSymbol))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 22;
                        }
                        else if(_currentSymbol.CurrentSymbol.Equals('>'))
                        {
                            lexeme = string.Empty;
                            _currentSymbol = Content.NextSymbol();
                            tokenColumn = _currentSymbol.Column;
                            tokenRow = _currentSymbol.Row;
                            state = 23;
                            _pascalCode = false;
                        }
                        break;
                    case 9:
                        if (_currentSymbol.CurrentSymbol.Equals('='))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            return new Token { Type = TokenType.TK_ASSIGN, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        else {
                            return new Token { Type = TokenType.TK_COLON, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                    case 10:
                        if (_currentSymbol.CurrentSymbol.Equals('='))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            return new Token { Type = TokenType.LESS_EQUAL, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        else if (_currentSymbol.CurrentSymbol.Equals('>'))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            return new Token { Type = TokenType.NOT_EQUAL, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        
                        return new Token { Type = TokenType.LESS_THAN, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                    case 11:
                        if (_currentSymbol.CurrentSymbol.Equals('='))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            return new Token { Type = TokenType.GREATER_EQUAL, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        return new Token { Type = TokenType.GREATER_THAN, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                    case 12:
                        if (_currentSymbol.CurrentSymbol.Equals('.'))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            return new Token { Type = TokenType.TK_RANGE, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        else if (char.IsDigit(_currentSymbol.CurrentSymbol))
                        {
                            state = 24;
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else
                        {
                            return new Token { Type = TokenType.TK_ACCESS, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        break;
                    case 13:
                        if (_currentSymbol.CurrentSymbol.Equals('*'))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 14;
                        }

                        break;
                    case 14:
                        if (_currentSymbol.CurrentSymbol.Equals('*'))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 15;
                        }
                        else if (_currentSymbol.CurrentSymbol == '\0')
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 6;
                        }
                        else
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        break;
                    case 15:
                        if (_currentSymbol.CurrentSymbol.Equals('}'))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 0;
                        }
                        else if (_currentSymbol.CurrentSymbol == '\0')
                        {
                            throw new LexicalException("Expected '}' to close comment.");
                        }
                        else
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 14;
                        }
                        break;
                    case 16:
                        if (IsOctal(_currentSymbol.CurrentSymbol.ToString()))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else
                        {
                            return new Token { Type = TokenType.OCTAL, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        break;
                    case 17:
                        if (_currentSymbol.CurrentSymbol.Equals('*'))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 18;
                        }
                        else
                        {
                            return new Token { Type = TokenType.TK_LEFTPARENTHESIS, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        break;
                    case 18:
                        if (_currentSymbol.CurrentSymbol.Equals('*'))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 19;
                        }
                        else if (_currentSymbol.CurrentSymbol == '\0')
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 6;
                        }
                        else
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        break;
                    case 19:
                        if (_currentSymbol.CurrentSymbol.Equals(')'))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 0;
                        }
                        else if (_currentSymbol.CurrentSymbol == '\0')
                        {
                            throw new LexicalException("Expected ')' to close comment.");
                        }
                        else
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 18;
                        }
                        break;
                    case 20:
                        if (_currentSymbol.CurrentSymbol.Equals('/'))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 21;
                        }
                        else
                        {
                            return new Token { Type = TokenType.TK_REALDIVISION, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        break;
                    case 21:
                        if (_currentSymbol.CurrentSymbol.Equals('\n') || _currentSymbol.CurrentSymbol.Equals('\0'))
                        {
                            state = 0;
                        }
                        else 
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        break;
                    case 22:
                        if (IsBinary(_currentSymbol.CurrentSymbol))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                            state = 22;
                        }
                        else 
                        {
                            return new Token { Type = TokenType.BIN, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        break;
                    case 23:
                        var isHtmlEmpty = false;
                        if(_currentSymbol.CurrentSymbol.Equals('\0'))
                        {
                            if (lexeme.Length > 0)
                            {
                                return new Token { Type = TokenType.HTML, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                            }
                            else
                            {
                                lexeme = "$";
                                return new Token { Type = TokenType.EOF, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                            }
                        }
                        else if (_currentSymbol.CurrentSymbol.Equals('<'))
                        {
                            _currentSymbol = Content.NextSymbol();
                            if (_currentSymbol.CurrentSymbol.Equals('%'))
                            {
                                state = 0;
                                _pascalCode = true;
                                _currentSymbol = Content.NextSymbol();
                                if(lexeme.Length > 0)
                                    return new Token { Type = TokenType.HTML, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                                else
                                    isHtmlEmpty = true;
                            }
                            else
                            {
                                lexeme += '<';
                            }
                        }
                        if (!isHtmlEmpty)
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        break;
                    case 24:
                        if (char.IsDigit(_currentSymbol.CurrentSymbol))
                        {
                            lexeme += _currentSymbol.CurrentSymbol;
                            _currentSymbol = Content.NextSymbol();
                        }
                        else
                        {
                            return new Token { Type = TokenType.DOUBLE, Lexeme = lexeme, Column = tokenColumn, Row = tokenRow };
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private bool IsHex(string currentSymbol)
        {
            return Regex.IsMatch(currentSymbol, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        private bool IsBinary(char currentSymbol)
        {
            return currentSymbol == '0' || currentSymbol == '1';
        }

        private bool IsOctal(string text)
        {
            return Regex.IsMatch(text, "^[0-7]+$");
        }

    }
}
