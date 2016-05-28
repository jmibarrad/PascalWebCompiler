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
            SentenceList();    
        }

        public void SentenceList()
        {
            if (_currentToken.Type == TokenType.EOF || _currentToken.Type == TokenType.KW_END)
            {
                return;
            }
            Sentence();
            SentenceList();

        }

        public void Sentence()
        {
            if (_currentToken.Type == TokenType.KW_TYPE)
            {
                _currentToken = _lexer.GetNextToken();
                DeclareType();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_IF)
            {
                _currentToken = _lexer.GetNextToken();
                If();
            }
            else if (_currentToken.Type == TokenType.KW_FOR)
            {
                _currentToken = _lexer.GetNextToken();
                PreFor();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_VAR)
            {
                _currentToken = _lexer.GetNextToken();
                Declaration();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_REPEAT)
            {
                _currentToken = _lexer.GetNextToken();
                Repeat();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_CASE)
            {
                _currentToken = _lexer.GetNextToken();
                Case();
            }
            else if (_currentToken.Type == TokenType.KW_FUNCTION)
            {
                _currentToken = _lexer.GetNextToken();
                FunctionDeclaration();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_PROCEDURE)
            {
                _currentToken = _lexer.GetNextToken();
                ProcedureDeclaration();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_WHILE)
            {
                _currentToken = _lexer.GetNextToken();
                While();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                PreId();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.HTML)
            {
                _currentToken = _lexer.GetNextToken();

            }
            else if (_currentToken.Type == TokenType.KW_CONST)
            {
                _currentToken = _lexer.GetNextToken();
                Const();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
        }

        private void Const()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                ConstantDeclaration();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void ConstantDeclaration()
        {
            if (_currentToken.Type == TokenType.EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                PascalExpression();
            }
            else if (_currentToken.Type == TokenType.TK_COLON)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.ID)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.EQUAL)
                    {
                        _currentToken = _lexer.GetNextToken();
                        PascalExpression();
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: '=' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }

            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: '=' or ':' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void Declaration()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                CommonFactorId();
            }
            else
            {
                throw new SyntaxException($"Unexpected Declaration Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void CommonFactorId()
        {
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                _currentToken = _lexer.GetNextToken();
                IdList();
                if (_currentToken.Type == TokenType.TK_COLON)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.ID)
                    {
                        _currentToken = _lexer.GetNextToken();
                        AssignValue();
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
            }
            else if (_currentToken.Type == TokenType.TK_COLON)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.ID)
                {
                    _currentToken = _lexer.GetNextToken();
                    AssignValue();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ',' or ':' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void AuxCommonFactorId()
        {
            
        }

        private void AssignValue()
        {
            if (_currentToken.Type == TokenType.EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                PascalExpression();
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
            }


        }

        public void If()
        {
            PascalExpression();
            if (_currentToken.Type == TokenType.KW_THEN)
            {
                _currentToken = _lexer.GetNextToken();
                Block();
                //_currentToken = _lexer.GetNextToken();
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
            _currentToken = _lexer.GetNextToken();
            Block();
        }

        private void Block()
        {
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

            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                ForBody();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
            
        }

        private void ForBody()
        {
            if (_currentToken.Type == TokenType.TK_ASSIGN)
            {
                _currentToken = _lexer.GetNextToken();
                For();
            }else if (_currentToken.Type == TokenType.KW_IN)
            {
                _currentToken = _lexer.GetNextToken();
                ForIn();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ':=' or 'in'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }

        }

        private void ForIn()
        {
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
            if (_currentToken.Type == TokenType.KW_BEGIN)
            {
                _currentToken = _lexer.GetNextToken();
                LoopListSentence();
                if (_currentToken.Type == TokenType.KW_END)
                {
                    _currentToken = _lexer.GetNextToken();

                }
            }
            else
            {
                LoopSentence();
            }
        }

        private void LoopSentence()
        {
            if (_currentToken.Type == TokenType.KW_CONTINUE)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected CONTINUE Token: {_currentToken.Lexeme} Expected: ';'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_BREAK)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected BREAK Token: {_currentToken.Lexeme} Expected: ';'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                Sentence();
            }
        }

        private void LoopListSentence()
        {
            if (_currentToken.Type == TokenType.KW_END)
            {
                return;
            }
            LoopSentence();
            LoopListSentence();
        }

        private void For()
        {
            PascalExpression();
            if (_currentToken.Type == TokenType.KW_TO)
            {
                _currentToken = _lexer.GetNextToken();
                PascalExpression();
                if (_currentToken.Type == TokenType.KW_DO)
                {
                    _currentToken = _lexer.GetNextToken();
                    LoopBlock();
                }
                else
                {
                    throw new SyntaxException($"Unexpected For Token: {_currentToken.Lexeme} Expected: 'do'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected For Token: {_currentToken.Lexeme} Expected: 'to'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
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
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.EQUAL)
                {
                    _currentToken = _lexer.GetNextToken();
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
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                FunctionParams();
                
                if (_currentToken.Type == TokenType.TK_COLON)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.ID)
                    {
                        _currentToken = _lexer.GetNextToken();
                        if (_currentToken.Type == TokenType.EOS)
                        {
                            _currentToken = _lexer.GetNextToken();
                            FunctionBlock();
                        }
                        else
                        {
                            throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                        }
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ':' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
                else
                {
                    throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ':' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void ProcedureDeclaration()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                FunctionParams();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    FunctionBlock();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }

                /*if (_currentToken.Type == TokenType.TK_COLON)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.ID)
                    {
                        _currentToken = _lexer.GetNextToken();
                        FunctionBlock();
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ':' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
                else
                {
                    throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ':' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }*/
            }
            else
            {
                throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void FunctionBlock()
        {
            if (_currentToken.Type == TokenType.KW_BEGIN)
            {
                _currentToken = _lexer.GetNextToken();
                SentenceList();
                if (_currentToken.Type == TokenType.KW_END)
                {
                    _currentToken = _lexer.GetNextToken();
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected 'Begin' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void FunctionParams()
        {
            if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
                FunctionListDeclaration();
                if (_currentToken.Type == TokenType.TK_RIGHTPARENTHESIS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ')' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void FunctionListDeclaration()
        {
            DeclareFunctionParams();
            ExtraDeclaration();
        }

        private void ExtraDeclaration()
        {
            if (_currentToken.Type == TokenType.EOS)
            {
                _currentToken = _lexer.GetNextToken();
                FunctionListDeclaration();
            }
        }

        private void DeclareFunctionParams()
        {
            if (_currentToken.Type == TokenType.KW_VAR)
            {
                _currentToken = _lexer.GetNextToken();
                IdList();
                if (_currentToken.Type == TokenType.TK_COLON)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.ID)
                    {
                        _currentToken = _lexer.GetNextToken();
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
            }
            else if (_currentToken.Type == TokenType.ID) 
            {
                IdList();
                if (_currentToken.Type == TokenType.TK_COLON)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.ID)
                    {
                        _currentToken = _lexer.GetNextToken();
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ':' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID or var at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void PreId()
        {
            if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
                CallFunction();
                if (_currentToken.Type == TokenType.TK_RIGHTPARENTHESIS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ')' Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                AssignValue();
            }
        }

        private void CallFunction()
        {
            PascalExpression();
            OptionalExpressionList();
        }

        private void OptionalRangeList()
        {
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                _currentToken = _lexer.GetNextToken();
                RangeList();
            }
        }

        public void Type()
        {
            if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
                EnumeratedTypes();
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type == TokenType.KW_RECORD)
            {
                _currentToken = _lexer.GetNextToken();
                Record();
            }
            else if (_currentToken.Type == TokenType.KW_ARRAY)
            {
                _currentToken = _lexer.GetNextToken();
                Array();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void EnumeratedTypes()
        {
            IdList();
            if (_currentToken.Type == TokenType.TK_RIGHTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else
            {
                throw new SyntaxException($"Unexpected EnumeratedTypes Token: Expected: ')' at {_currentToken.Lexeme} Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void TypeDef()
        {
            _currentToken = _lexer.GetNextToken();

        }

        public void Record()
        {

            RecordPropertyList();
         
        }

        private void RecordPropertyList()
        {
            IdList();
            if (_currentToken.Type == TokenType.TK_COLON)
            {
                _currentToken = _lexer.GetNextToken();
                RecordType();
                if ( _currentToken.Type != TokenType.KW_END)
                {
                    RecordPropertyList();
                }
                else
                {
                    _currentToken = _lexer.GetNextToken();
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected RecordPropertyList Token: {_currentToken.Lexeme} Expected: ':' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void RecordType()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
                EnumeratedTypes();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_ARRAY)
            {
                _currentToken = _lexer.GetNextToken();
                Array();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_RECORD)
            {
                _currentToken = _lexer.GetNextToken();
                Record();
            }
            else
            {
                throw new SyntaxException($"Unexpected Record Type Token: {_currentToken.Lexeme} Expected: RecordType at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void Array()
        {
            if (_currentToken.Type == TokenType.TK_LEFTBRACKET)
            {
                _currentToken = _lexer.GetNextToken();
                RangeList();
                if (_currentToken.Type == TokenType.TK_RIGHTBRACKET)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.KW_OF)
                    {
                        _currentToken = _lexer.GetNextToken();
                        ArrayTypes();
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: 'of' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ']' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void ArrayTypes()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type == TokenType.KW_ARRAY)
            {
                _currentToken = _lexer.GetNextToken();
                Array();
            }
            else 
            {
                _currentToken = _lexer.GetNextToken();
                Range();
            }
        }

        private void RangeList()
        {
            Range();
            OptionalRangeList();
        }

        private void Range()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else
            {
                SubRange();
                if (_currentToken.Type == TokenType.ID)
                {
                    _currentToken = _lexer.GetNextToken();
                }
            }
        }

        private void SubRange()
        {

            PascalExpression();
            if (_currentToken.Type == TokenType.TK_RANGE)
            {
                _currentToken = _lexer.GetNextToken();
                PascalExpression();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: '..' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }

        }

        private void OptionalExpressionList()
        {
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                _currentToken = _lexer.GetNextToken();
                PascalExpression();
            }
        }

        public void IdList()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                OptionalId();
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void OptionalId()
        {
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                _currentToken = _lexer.GetNextToken();
                IdList();
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
            if (_currentToken.Type == TokenType.KW_NOT)
            {
                _currentToken = _lexer.GetNextToken();
                Factor();
            }
            else if (_currentToken.Type == TokenType.NUMBER_LITERAL)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type == TokenType.STRING_LITERAL)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type == TokenType.CHAR_LITERAL)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type == TokenType.KW_NOT)
            {
                _currentToken = _lexer.GetNextToken();
                Factor();
            }
            else if (_currentToken.Type == TokenType.HEX)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type == TokenType.BIN)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type == TokenType.OCTAL)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type == TokenType.REAL_LITERAL)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
                {
                    _currentToken = _lexer.GetNextToken();
                    CallFunction();
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.TK_RIGHTPARENTHESIS)
                    {
                        _currentToken = _lexer.GetNextToken();
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ')' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }

            }
            else if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
                PascalExpression();
                //_currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.TK_RIGHTPARENTHESIS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ')' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
                _currentToken = _lexer.GetNextToken();
            }
        }

        private void MultiplicationExpressionPrime()
        {
            if (_currentToken.Type == TokenType.MULT)
            {
                _currentToken = _lexer.GetNextToken();
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.DIV)
            {
                _currentToken = _lexer.GetNextToken();
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.TK_REALDIVISION)
            {
                _currentToken = _lexer.GetNextToken();
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.MOD)
            {
                _currentToken = _lexer.GetNextToken();
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.KW_AND)
            {
                _currentToken = _lexer.GetNextToken();
                Unary_Expression();
                MultiplicationExpressionPrime();
            }
            
        }

        private void AdditionExpresionPrime()
        {
            if (_currentToken.Type == TokenType.SUM)
            {
                _currentToken = _lexer.GetNextToken();
                MultiplicationExpression();
                AdditionExpresionPrime();
            }
            else if (_currentToken.Type == TokenType.SUB)
            {
                _currentToken = _lexer.GetNextToken();
                MultiplicationExpression();
                AdditionExpresionPrime();
            }
            else if (_currentToken.Type == TokenType.KW_OR)
            {
                _currentToken = _lexer.GetNextToken();
                MultiplicationExpression();
                AdditionExpresionPrime();
            }

        }

        private void RelationalExpressionPrime()
        {
            if (_currentToken.Type == TokenType.LESS_THAN)
            {
                _currentToken = _lexer.GetNextToken();
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.GREATER_EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.LESS_EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.GREATER_THAN)
            {
                _currentToken = _lexer.GetNextToken();
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.NOT_EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            else if (_currentToken.Type == TokenType.EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                AdditionExpresion();
                RelationalExpressionPrime();
            }
            
        }
    }
}
