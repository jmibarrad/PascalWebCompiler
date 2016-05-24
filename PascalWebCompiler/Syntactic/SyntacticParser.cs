using System.Linq.Expressions;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Lexer;

namespace PascalWebCompiler.Syntactic
{
    public class SyntacticParser
    {
        private readonly Lexer.Lexer _lexer;
        private Token _currentToken;
 
        public SyntacticParser(Lexer.Lexer lexer)
        {
            _lexer = lexer;
        }
 
        public void Parse()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.EOF)
            {
                throw new SyntaxException("EOF Expected");
            }
            SentenceList();    
        }

        public void SentenceList()
        {
            Sentence();
        }

        public void Sentence()
        {
            if (_currentToken.Type == TokenType.KW_TYPE)
            {
                DeclareType();
                if (_currentToken.Type != TokenType.EOS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_IF)
            {
                If();
                if (_currentToken.Type != TokenType.EOS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_FOR)
            {
                PreFor();
                if (_currentToken.Type != TokenType.EOS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_VAR)
            {
                Declaration();
                if (_currentToken.Type != TokenType.EOS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_REPEAT)
            {
                Repeat();
                if (_currentToken.Type != TokenType.EOS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_CASE)
            {
                Case();
            }
            else if (_currentToken.Type == TokenType.KW_FUNCTION)
            {
                FunctionDeclaration();
                if (_currentToken.Type != TokenType.EOS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_PROCEDURE)
            {
                ProcedureDeclaration();
                if (_currentToken.Type != TokenType.EOS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_WHILE)
            {
                While();
                if (_currentToken.Type != TokenType.EOS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                PreId();
                if (_currentToken.Type != TokenType.EOS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.HTML)
            {
                
            }

            

        }

        public void Declaration()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.ID)
            {
                CommonFactorId();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void CommonFactorId()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                ListaId();
            }
            else if (_currentToken.Type == TokenType.TK_COLON)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.ID)
                {
                    AssignValue();
                }
                else
                {
                    
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ',' or ':' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void AssignValue()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.EQUAL)
            {
                PascalExpression();
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.TK_RIGHTPARENTHESIS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ')' Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                
            }


        }

        public void If()
        {
            PascalExpression();
            if (_currentToken.Type == TokenType.KW_THEN)
            {
                Block();
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.KW_ELSE)
                {
                    Else();
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: 'then' Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }

        }

        private void Else()
        {
            Block();
        }

        private void Block()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.KW_BEGIN)
            {
                SentenceList();
                //_currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.KW_END)
                {
                    throw new SyntaxException(
                        $"Unexpected Token: {_currentToken.Lexeme} Expected: 'End' Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                Sentence();
            }
        }

        public void PreFor()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.KW_FOR)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.ID)
                {
                    ForBody();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
        }

        private void ForBody()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.TK_ASSIGN)
            {
                For();
            }else if (_currentToken.Type == TokenType.KW_IN)
            {
                ForIn();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ':=' or 'in'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }

        }

        private void ForIn()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.KW_DO)
                {
                    LoopBlock();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: 'do'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: 'ID'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");

            }
        }

        private void LoopBlock()
        {
            throw new System.NotImplementedException();
        }

        private void For()
        {
            _currentToken = _lexer.GetNextToken();
            throw new System.NotImplementedException();
        }

        public void While()
        {

        }

        public void Repeat()
        {

        }

        public void Case()
        {

        }

        public void DeclareType()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.EQUAL)
                {
                    Type();
                }
                else
                {
                    throw new SyntaxException("<=> ASSIGN TOKEN Expected");
                }
            }
            else
            {
                throw new SyntaxException("ID Expected");
            }
        }

        public void FunctionDeclaration()
        {

        }

        public void ProcedureDeclaration()
        {

        }

        public void PreId()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                CallFunction();
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.TK_RIGHTPARENTHESIS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ')' Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.EQUAL)
            {
                AssignValue();
            }
        }

        private void CallFunction()
        {
            PascalExpression();
        }

        public void Type()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                EnumeratedTypes();
            }
            else if (_currentToken.Type == TokenType.ID)
            {

            }
            else if (_currentToken.Type == TokenType.KW_RECORD)
            {
                Record();
            }
            else if (_currentToken.Type == TokenType.KW_ARRAY)
            {
                Array();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void EnumeratedTypes()
        {
            _currentToken = _lexer.GetNextToken();

        }

        public void TypeDef()
        {
            _currentToken = _lexer.GetNextToken();

        }

        public void Record()
        {
            _currentToken = _lexer.GetNextToken();

        }

        public void Array()
        {
            _currentToken = _lexer.GetNextToken();

        }

        public void ListaId()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.ID)
            {
                OptionalId();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void OptionalId()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                ListaId();
            }
        }

        private void PascalExpression()
        {
            RelationalExpression();
        }

        private void RelationalExpression()
        {

            AdditionExpresion();
            RelationalExpressionPrime();
        }

        private void AdditionExpresion()
        {
            MultiplicationExpression();
            AdditionExpresionPrime();
        }

        private void MultiplicationExpression()
        {
            Unary_Expression();
            MultiplicationExpressionPrime();
        }

        private void Unary_Expression()
        {
            Factor();
        }

        private void Factor()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.KW_NOT)
            {
                Factor();
            }
            else if (_currentToken.Type == TokenType.NUMBER_LITERAL)
            {
                
            }
            else if (_currentToken.Type == TokenType.STRING_LITERAL)
            {

            }
            else if (_currentToken.Type == TokenType.CHAR_LITERAL)
            {

            }
            else if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
                {
                    CallFunction();
                }
            }
            else if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                PascalExpression();
                if (_currentToken.Type != TokenType.TK_RIGHTPARENTHESIS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ')' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
        }

        private void MultiplicationExpressionPrime()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.MULT)
            {
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.DIV)
            {
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.TK_REALDIVISION)
            {
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.MOD)
            {
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.KW_AND)
            {
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            else
            {
                throw new SyntaxException($"Unexpected Multiplication Token: {_currentToken.Lexeme} at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void AdditionExpresionPrime()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.SUM)
            {
                MultiplicationExpression();
                AdditionExpresionPrime();
            }
            else if (_currentToken.Type == TokenType.SUB)
            {
                MultiplicationExpression();
                AdditionExpresionPrime();
            }
            else if (_currentToken.Type == TokenType.KW_OR)
            {
                MultiplicationExpression();
                AdditionExpresionPrime();
            }
            else
            {
                throw new SyntaxException($"Unexpected Addition Token: {_currentToken.Lexeme} at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void RelationalExpressionPrime()
        {
            _currentToken = _lexer.GetNextToken();
            if (_currentToken.Type == TokenType.LESS_THAN)
            {
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.GREATER_EQUAL)
            {
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.LESS_EQUAL)
            {
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.GREATER_THAN)
            {
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.NOT_EQUAL)
            {
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.EQUAL)
            {
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else
            {
                throw new SyntaxException($"Unexpected Relational Token: {_currentToken.Lexeme} at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }
    }
}
