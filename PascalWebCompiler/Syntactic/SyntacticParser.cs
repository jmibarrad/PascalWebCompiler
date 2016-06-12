using System.Collections.Generic;
using PascalWebCompiler.Exceptions;
using PascalWebCompiler.Lexer;
using PascalWebCompiler.Syntactic.Tree;
using PascalWebCompiler.Syntactic.Tree.Declaration;
using PascalWebCompiler.Syntactic.Tree.DeclareConstants;
using PascalWebCompiler.Syntactic.Tree.DeclareType;
using PascalWebCompiler.Syntactic.Tree.Expression;
using PascalWebCompiler.Syntactic.Tree.ID;
using PascalWebCompiler.Syntactic.Tree.Loops;
using PascalWebCompiler.Syntactic.Tree.Operators;
using PascalWebCompiler.Syntactic.Tree.Params;

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
 
        public List<SentenceNode> Parse()
        {
            _currentToken = _lexer.GetNextToken();
            var tree = SentenceList();
            return tree;
        }

        public List<SentenceNode> SentenceList()
        {
            if (_currentToken.Type == TokenType.EOF || _currentToken.Type == TokenType.KW_END)
            {
                return new List<SentenceNode>();
            }

            var sentence = Sentence();
            var sentenceList = SentenceList();
            if (sentence != null)
                sentenceList.Insert(0, sentence);

            return sentenceList;
        }

        public SentenceNode Sentence()
        {
            if (_currentToken.Type == TokenType.KW_TYPE)
            {
                _currentToken = _lexer.GetNextToken();
                DeclareType();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return new TypeDeclarationNode();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_IF)
            {
                _currentToken = _lexer.GetNextToken();
               
                return  If();
            }
            else if (_currentToken.Type == TokenType.KW_FOR)
            {
                _currentToken = _lexer.GetNextToken();
                return PreFor();
            }
            else if (_currentToken.Type == TokenType.KW_VAR)
            {
                _currentToken = _lexer.GetNextToken();
                var declarationNode = Declaration();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return declarationNode;
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_REPEAT)
            {
                _currentToken = _lexer.GetNextToken();
                var repeatNode = Repeat();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return repeatNode;
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
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return new CaseNode();
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_FUNCTION)
            {
                _currentToken = _lexer.GetNextToken();
                var functionStatement = FunctionDeclaration();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return functionStatement;

                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_PROCEDURE)
            {
                _currentToken = _lexer.GetNextToken();
                var procedureStatement = ProcedureDeclaration();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return procedureStatement;

                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.KW_WHILE)
            {
                _currentToken = _lexer.GetNextToken();
                return While();
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                var idLexeme = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();

                var preId = PreId(idLexeme);
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return preId;

                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.HTML)
            {
                var htmlContent = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new HtmlNode {Content = htmlContent};
            }
            else if (_currentToken.Type == TokenType.KW_CONST)
            {
                _currentToken = _lexer.GetNextToken();
                var constSentence = Const();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return constSentence;
                }
                else
                {
                    throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected MOTHER EXCEPTION: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private ConstNode Const()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                var idNode = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return ConstantDeclaration(idNode);
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private ConstNode ConstantDeclaration(string idNodeValue)
        {
            if (_currentToken.Type == TokenType.EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                var expression = PascalExpression();
                return new ConstOnlyDeclareNode {Expression = expression, IdNode = new IdNode {Value = idNodeValue } };
            }
            else if (_currentToken.Type == TokenType.TK_COLON)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.ID)
                {
                    var type = _currentToken.Lexeme;
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.EQUAL)
                    {
                        _currentToken = _lexer.GetNextToken();
                        var expression = PascalExpression();
                        return new ConstWithTypeNode {Expression = expression, Type = type, IdNode = new IdNode {Value = idNodeValue} };
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

        public DeclarationNode Declaration()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                var node = new IdNode { Value = _currentToken.Lexeme };
                _currentToken = _lexer.GetNextToken();
                return CommonFactorId(node);
            }
            else
            {
                throw new SyntaxException($"Unexpected Declaration Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private DeclarationNode CommonFactorId(IdNode idNode)
        {
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                var aditionalIds = new List<IdNode> {idNode};
                _currentToken = _lexer.GetNextToken();
                aditionalIds = IdList(aditionalIds);
                if (_currentToken.Type == TokenType.TK_COLON)
                {
                    var declarationType = _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.ID)
                    {
                        _currentToken = _lexer.GetNextToken();
                        //AssignValue();
                        return new OnlyDeclarationNode {IdNodesList = aditionalIds ,Type = declarationType.Lexeme};
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
                    var type = _currentToken.Lexeme;
                    _currentToken = _lexer.GetNextToken();
                    var expression = AssignValue();
                    return new DeclarationAssignNode {IdNode = new IdNode {Value = idNode.Value}, Value = expression, Type = type};
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

            return null;
        }

        private ExpressionNode AssignValue()
        {
            if (_currentToken.Type == TokenType.EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                return PascalExpression();
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                var value = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new IdNode {Value = value, Accesors = new List<AccesorNode>()};
            }

            return null;
        }

        public IfNode If()
        {
            var expression = PascalExpression();
            var ifNode = new IfNode {Condition = expression};
            if (_currentToken.Type == TokenType.KW_THEN)
            {
                _currentToken = _lexer.GetNextToken();
                ifNode.TruStatements = Block();
                if (_currentToken.Type == TokenType.KW_ELSE)
                {
                    ifNode.FalseStaments = Else();
                }
                return ifNode;
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: 'then' Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }

        }

        private List<SentenceNode> Else()
        {
            _currentToken = _lexer.GetNextToken();
            return Block();
        }

        private List<SentenceNode> Block()
        {
            if (_currentToken.Type == TokenType.KW_BEGIN)
            {
                _currentToken = _lexer.GetNextToken();
                var sentenceList = SentenceList();
                if (_currentToken.Type == TokenType.KW_END)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.EOS)
                    {
                        _currentToken = _lexer.GetNextToken();
                        return sentenceList;
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
                else 
                {
                    throw new SyntaxException(
                        $"Unexpected Token: {_currentToken.Lexeme} Expected: 'End' Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                var sentenceList = new List<SentenceNode>();
                var sentence = Sentence();
                sentenceList.Add(sentence);
                return sentenceList;
            }
        }

        public SentenceNode PreFor()
        {

            if (_currentToken.Type == TokenType.ID)
            {
                //var accesorList = IndexingAndAccess();
                var idNode = new IdNode {Value = _currentToken.Lexeme, Accesors = new List<AccesorNode>()};
                _currentToken = _lexer.GetNextToken();
                return ForBody(idNode);
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
            
        }

        private SentenceNode ForBody(IdNode idNode)
        {
            if (_currentToken.Type == TokenType.TK_ASSIGN)
            {
                _currentToken = _lexer.GetNextToken();
                return For(idNode);
            }else if (_currentToken.Type == TokenType.KW_IN)
            {
                _currentToken = _lexer.GetNextToken();
                return ForIn(idNode);
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ':=' or 'in'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }

        }

        private SentenceNode ForIn(IdNode idNode)
        {
            if (_currentToken.Type == TokenType.ID)
            {
                var collection = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                var collectionAccesors = new List<AccesorNode>();
                collectionAccesors = IndexingAndAccess(collectionAccesors);
                if (_currentToken.Type == TokenType.KW_DO)
                {
                    _currentToken = _lexer.GetNextToken();
                    var sentenceList = LoopBlock();
                    return new ForInNode {IdNode = idNode, Statements = sentenceList, IdNodeCollection = new IdNode {Accesors = collectionAccesors, Value = collection} };
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

        private List<SentenceNode> LoopBlock()
        {
            if (_currentToken.Type == TokenType.KW_BEGIN)
            {
                _currentToken = _lexer.GetNextToken();
                var sentenceList = LoopListSentence();
                if (_currentToken.Type == TokenType.KW_END)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.EOS)
                    {
                        _currentToken = _lexer.GetNextToken();
                        return sentenceList;
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Sentence Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
            }
            else
            {
                var sentence = LoopSentence();
                var list = new List<SentenceNode> {sentence};
                return list;
            }

            return null;
        }

        private SentenceNode LoopSentence()
        {
            if (_currentToken.Type == TokenType.KW_CONTINUE)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return new ContinueNode();
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
                    return new BreakNode();

                }
                else
                {
                    throw new SyntaxException($"Unexpected BREAK Token: {_currentToken.Lexeme} Expected: ';'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                return Sentence();
            }
        }

        private List<SentenceNode> LoopListSentence()
        {
            if (_currentToken.Type == TokenType.KW_END || _currentToken.Type == TokenType.KW_UNTIL || _currentToken.Type == TokenType.EOF)
            {
                return new List<SentenceNode>();
            }

            var sentence = LoopSentence();
            var sentenceList = LoopListSentence();
            if (sentence != null)
                sentenceList.Insert(0, sentence);
            return sentenceList;
        }

        private SentenceNode For(IdNode idNode)
        {
            var expression = PascalExpression();
            if (_currentToken.Type == TokenType.KW_TO)
            {
                _currentToken = _lexer.GetNextToken();
                var condition = PascalExpression();
                if (_currentToken.Type == TokenType.KW_DO)
                {
                    _currentToken = _lexer.GetNextToken();
                    var loopSentenceList = LoopBlock();
                    return new ForNode {Condition = condition, IdNode = idNode, Statements = loopSentenceList};
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

        public SentenceNode While()
        {
            var expr = PascalExpression();
            if (_currentToken.Type == TokenType.KW_DO)
            {
                _currentToken = _lexer.GetNextToken();
                var sentenceList = LoopBlock();
                return new WhileNode {Condition = expr, Statements = sentenceList};
            }
            else
            {
                throw new SyntaxException($"Unexpected For Token: {_currentToken.Lexeme} Expected: 'do'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }

        }

        public SentenceNode Repeat()
        {
            var sentenceList = LoopListSentence();
            if (_currentToken.Type == TokenType.KW_UNTIL)
            {
                _currentToken = _lexer.GetNextToken();
                var condition = PascalExpression();
                return new RepeatNode {Condition = condition, Statements = sentenceList};
            }
            else
            {
                throw new SyntaxException($"Unexpected For Token: {_currentToken.Lexeme} Expected: 'until'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }

        }

        public void Case()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                _currentToken = _lexer.GetNextToken();
                var accessorList = new List<AccesorNode>();
                accessorList = IndexingAndAccess(accessorList);
                if (_currentToken.Type == TokenType.KW_OF)
                {
                    _currentToken = _lexer.GetNextToken();
                    CaseList();
                    if (_currentToken.Type == TokenType.KW_END)
                    {
                        _currentToken = _lexer.GetNextToken();

                    }
                }
                else
                {
                    throw new SyntaxException($"Unexpected Case Token: {_currentToken.Lexeme} Expected: 'of'  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Case Token: {_currentToken.Lexeme} Expected: ID  at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void CaseList()
        {
            if (_currentToken.Type == TokenType.KW_ELSE)
            {
                _currentToken = _lexer.GetNextToken();
                Block();
            }
            else if(_currentToken.Type == TokenType.NUMBER_LITERAL)
            {
                CaseLiteral();
                if (_currentToken.Type == TokenType.TK_COLON)
                {
                    _currentToken = _lexer.GetNextToken();
                    Block();
                    CaseList();
                }
            }
        }

        private void CaseLiteral()
        {
            PascalExpression();
            if (_currentToken.Type == TokenType.TK_RANGE)
            {
                //_currentToken = _lexer.GetNextToken();
                RangeList();
            }
            else if (_currentToken.Type == TokenType.TK_COMMA)
            {
                //_currentToken = _lexer.GetNextToken();
                var expressionList = new List<ExpressionNode>();
                OptionalExpressionList(expressionList);
            }
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

        public SentenceNode FunctionDeclaration()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                var functionName = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                var parameters = FunctionParams();
                
                if (_currentToken.Type == TokenType.TK_COLON)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.ID)
                    {
                        var functionType = _currentToken.Lexeme;
                        _currentToken = _lexer.GetNextToken();
                        if (_currentToken.Type == TokenType.EOS)
                        {
                            _currentToken = _lexer.GetNextToken();
                            var statements = FunctionBlock();
                            return new FunctionDeclarationNode {FunctionName = functionName, Type = functionType, Parameters = parameters, Statements = statements};
                        }
                        else
                        {
                            throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                        }
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
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

        public SentenceNode ProcedureDeclaration()
        {
            if (_currentToken.Type == TokenType.ID)
            {
                var procedureName = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                var parameters = FunctionParams();
                if (_currentToken.Type == TokenType.EOS)
                {
                    _currentToken = _lexer.GetNextToken();
                    var statements = FunctionBlock();
                    return new ProcedureDeclarationNode {Parameters = parameters, ProcedureName = procedureName, Statements = statements};
                }
                else
                {
                    throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ';' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private List<SentenceNode> FunctionBlock()
        {
            if (_currentToken.Type == TokenType.KW_BEGIN)
            {
                _currentToken = _lexer.GetNextToken();
                var sentenceList = SentenceList();
                if (_currentToken.Type == TokenType.KW_END)
                {
                    _currentToken = _lexer.GetNextToken();
                    return sentenceList;
                }
                else
                {
                    throw new SyntaxException(
                        $"Unexpected Token: {_currentToken.Lexeme} Expected: 'End' Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Procedure Declaration Token: {_currentToken.Lexeme} Expected 'Begin' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private List<Param> FunctionParams()
        {
            if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
                var paramList =new List<Param>();
                paramList = FunctionListDeclaration(paramList);
                if (_currentToken.Type == TokenType.TK_RIGHTPARENTHESIS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return paramList;
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

        private List<Param> FunctionListDeclaration(List<Param> paramList)
        {
            var param = DeclareFunctionParams();
            paramList.Insert(0, param);
            return ExtraDeclaration(paramList);
        }

        private List<Param> ExtraDeclaration(List<Param> paramList)
        {
            if (_currentToken.Type == TokenType.EOS)
            {
                _currentToken = _lexer.GetNextToken();
                FunctionListDeclaration(paramList);
            }

            return paramList;
        }

        private Param DeclareFunctionParams()
        {
            if (_currentToken.Type == TokenType.KW_VAR)
            {
                _currentToken = _lexer.GetNextToken();
                var idList = new List<string>();
                idList = ParamList(idList);
                if (_currentToken.Type == TokenType.TK_COLON)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.ID)
                    {
                        var type = _currentToken.Lexeme;
                        _currentToken = _lexer.GetNextToken();
                        return new ReferenceParam {ParamList = idList, ParamType = type};
                    }
                    else
                    {
                        throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
            }
            else if (_currentToken.Type == TokenType.ID) 
            {
                var idList = new List<string>();
                idList = ParamList(idList);
                if (_currentToken.Type == TokenType.TK_COLON)
                {
                    _currentToken = _lexer.GetNextToken();
                    if (_currentToken.Type == TokenType.ID)
                    {
                        var type = _currentToken.Lexeme;
                        _currentToken = _lexer.GetNextToken();
                        return new ValueParam { ParamList = idList, ParamType = type };
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
            
            throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID or var at Column: {_currentToken.Column} Row: {_currentToken.Row}");
        }

        public SentenceNode PreId(string idLexeme)
        {
            var accessorList = new List<AccesorNode>();
            accessorList = IndexingAndAccess(accessorList);
            if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
                var parameters = new List<ExpressionNode>();
                parameters = CallFunction(parameters);
                if (_currentToken.Type == TokenType.TK_RIGHTPARENTHESIS)
                {
                    _currentToken = _lexer.GetNextToken();
                    return new CallFunctionNode {IdNode = new IdNode {Value = idLexeme}, Parameters = parameters};
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ')' Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.TK_ASSIGN)
            {
                _currentToken = _lexer.GetNextToken();
                var expression = PascalExpression();
                return new AssignmentNode {Value = expression, ValueIdNode = new IdNode {Accesors = accessorList, Value = idLexeme} };
            }

            return null;
        }

        private List<ExpressionNode> CallFunction(List<ExpressionNode> listNodes)
        {
            if (_currentToken.Type == TokenType.TK_RIGHTPARENTHESIS)
            {
                return listNodes;
            }
            var param = PascalExpression();
            listNodes.Insert(0, param);
            OptionalExpressionList(listNodes);

            return listNodes;
        }

        private void OptionalRangeList()
        {
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                _currentToken = _lexer.GetNextToken();
                if(_currentToken.Type != TokenType.NUMBER_LITERAL)
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: 'NUMBER_LITERAL' Column: {_currentToken.Column} Row: {_currentToken.Row}");

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
            IdList(new List<IdNode>());
            if (_currentToken.Type == TokenType.TK_RIGHTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
            }
            else
            {
                throw new SyntaxException($"Unexpected EnumeratedTypes Token: Expected: ')' at {_currentToken.Lexeme} Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public void Record()
        {

            RecordPropertyList();
         
        }

        private void RecordPropertyList()
        {
            IdList(new List<IdNode>());
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
                if (_currentToken.Type == TokenType.NUMBER_LITERAL)
                {
                    _currentToken = _lexer.GetNextToken();
                    RangeList();
                }
                else if(_currentToken.Type == TokenType.ID)
                {
                    _currentToken = _lexer.GetNextToken();
                }
                
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
                        throw new SyntaxException(
                            $"Unexpected Token: {_currentToken.Lexeme} Expected: 'of' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
                else
                {
                    throw new SyntaxException(
                        $"Unexpected Token: {_currentToken.Lexeme} Expected: ']' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: '[' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
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
            else if(_currentToken.Type == TokenType.NUMBER_LITERAL)
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
            
            if (_currentToken.Type == TokenType.TK_RANGE)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.NUMBER_LITERAL)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: 'NUMBER_LITERAL' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }

                _currentToken = _lexer.GetNextToken();

            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: '..' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        private void OptionalExpressionList(List<ExpressionNode> expressionList)
        {
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                _currentToken = _lexer.GetNextToken();
                CallFunction(expressionList);
            }
        }

        public List<IdNode> IdList(List<IdNode> idList)
        {
            if (_currentToken.Type == TokenType.ID)
            {
                idList.Add(new IdNode {Value = _currentToken.Lexeme});
                _currentToken = _lexer.GetNextToken();
                return OptionalId(idList);
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public List<IdNode> OptionalId(List<IdNode> idList)
        {
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                _currentToken = _lexer.GetNextToken();
                return IdList(idList);
            }
            else
            {
                return idList;
            }
        }

        public List<string> ParamList(List<string> idList)
        {
            if (_currentToken.Type == TokenType.ID)
            {
                idList.Add( _currentToken.Lexeme);
                _currentToken = _lexer.GetNextToken();
                return OptionalParam(idList);
            }
            else
            {
                throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ID at Column: {_currentToken.Column} Row: {_currentToken.Row}");
            }
        }

        public List<string> OptionalParam(List<string> idList)
        {
            if (_currentToken.Type == TokenType.TK_COMMA)
            {
                _currentToken = _lexer.GetNextToken();
                return ParamList(idList);
            }
            else
            {
                return idList;
            }
        }

        private ExpressionNode PascalExpression()
        {
            return RelationalExpression();
        }

        private ExpressionNode RelationalExpression()
        {

            var node = AdditionExpresion();
            return RelationalExpressionPrime(node);
        }

        private ExpressionNode AdditionExpresion()
        {
            var multNode = MultiplicationExpression();
            return AdditionExpresionPrime(multNode);
        }

        private ExpressionNode MultiplicationExpression()
        {
            var uNode  = Unary_Expression();
            return MultiplicationExpressionPrime(uNode);
        }

        private ExpressionNode Unary_Expression()
        {
            return Factor();
        }

        private ExpressionNode Factor()
        {
            if (_currentToken.Type == TokenType.KW_NOT)
            {
                _currentToken = _lexer.GetNextToken();
                var notNode = new NotNode {ExpressionNode = Factor()};
                return notNode;
            }
            else if (_currentToken.Type == TokenType.NUMBER_LITERAL)
            {
                var numberValue = _currentToken.Lexeme; 
                _currentToken = _lexer.GetNextToken();
                return new NumberNode {Value = int.Parse(numberValue)};
            }
            else if (_currentToken.Type == TokenType.STRING_LITERAL)
            {
                var stringValue = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new StringLiteralNode { Value = stringValue };

            }
            else if (_currentToken.Type == TokenType.CHAR_LITERAL)
            {
                var value = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new CharLiteralNode { Value = value[0] };
            }
            else if (_currentToken.Type == TokenType.HEX)
            {
                var value = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new NumberNode() { Value = int.Parse(value) };
            }
            else if (_currentToken.Type == TokenType.BIN)
            {
                var value = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new NumberNode { Value = int.Parse(value) };
            }
            else if (_currentToken.Type == TokenType.OCTAL)
            {
                var value = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new NumberNode { Value = int.Parse(value) };
            }
            else if (_currentToken.Type == TokenType.REAL_LITERAL)
            {
                var value = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                return new RealNode { Value = float.Parse(value) };
            }
            else if (_currentToken.Type == TokenType.ID)
            {
                var idValue = _currentToken.Lexeme;
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
                {
                    _currentToken = _lexer.GetNextToken();
                    var expressionList = new List<ExpressionNode>();
                    expressionList = CallFunction(expressionList);
                    if (_currentToken.Type == TokenType.TK_RIGHTPARENTHESIS)
                    {
                        _currentToken = _lexer.GetNextToken();
                        return new AssignFunctionNode {IdNode = new IdNode{Value = idValue}, Parameters = expressionList}; //need to implement this shit
                    }
                    else
                    {
                        throw new SyntaxException(
                            $"Unexpected Token: {_currentToken.Lexeme} Expected ')' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                    }
                }
                else
                {
                    var accessorList = new List<AccesorNode>();
                    accessorList = IndexingAndAccess(accessorList);
                    return new IdNode {Value = idValue, Accesors = accessorList};
                }
                

            }
            else if (_currentToken.Type == TokenType.TK_LEFTPARENTHESIS)
            {
                _currentToken = _lexer.GetNextToken();
                var expr = PascalExpression();
                //_currentToken = _lexer.GetNextToken();
                if (_currentToken.Type != TokenType.TK_RIGHTPARENTHESIS)
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected ')' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
                _currentToken = _lexer.GetNextToken();
                return expr;
            }

            throw new SyntaxException($"F() Unexpected Token: {_currentToken.Lexeme} at Column: {_currentToken.Column} Row: {_currentToken.Row}");
        }

        private ExpressionNode MultiplicationExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.MULT)
            {
                _currentToken = _lexer.GetNextToken();
                var uNode = Unary_Expression();
                var node = new Mult { LeftOperand = param, RightOperand = uNode };
                return MultiplicationExpressionPrime(node);
            }
            else if (_currentToken.Type == TokenType.DIV)
            {
                _currentToken = _lexer.GetNextToken();
                var uNode = Unary_Expression();
                var node = new Div { LeftOperand = param, RightOperand = uNode };
                return MultiplicationExpressionPrime(node);
            }
            else if (_currentToken.Type == TokenType.TK_REALDIVISION)
            {
                _currentToken = _lexer.GetNextToken();
                var uNode = Unary_Expression();
                var node = new RealDiv { LeftOperand = param, RightOperand = uNode };
                return MultiplicationExpressionPrime(node);
            }
            else if (_currentToken.Type == TokenType.MOD)
            {
                _currentToken = _lexer.GetNextToken();
                var uNode = Unary_Expression();
                var node = new Mod { LeftOperand = param, RightOperand = uNode };
                return MultiplicationExpressionPrime(node);
            }
            else if (_currentToken.Type == TokenType.KW_AND)
            {
                _currentToken = _lexer.GetNextToken();
                var uNode = Unary_Expression();
                var node = new And { LeftOperand = param, RightOperand = uNode };
                return MultiplicationExpressionPrime(node);
            }

            return param;
        }

        private ExpressionNode AdditionExpresionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.SUM)
            {
                _currentToken = _lexer.GetNextToken();
                var secondLevelExpression = MultiplicationExpression();
                var node = new Sum { LeftOperand = param, RightOperand = secondLevelExpression };
                return AdditionExpresionPrime(node);
            }
            else if (_currentToken.Type == TokenType.SUB)
            {
                _currentToken = _lexer.GetNextToken();
                var secondLevelExpression = MultiplicationExpression();
                var node = new Sub { LeftOperand = param, RightOperand = secondLevelExpression };
                return AdditionExpresionPrime(node);
            }
            else if (_currentToken.Type == TokenType.KW_OR)
            {
                _currentToken = _lexer.GetNextToken();
                var secondLevelExpression = MultiplicationExpression();
                var node = new Or { LeftOperand = param, RightOperand = secondLevelExpression };
                return AdditionExpresionPrime(node);
            }

            return param;
        }

        private ExpressionNode RelationalExpressionPrime(ExpressionNode param)
        {
            if (_currentToken.Type == TokenType.LESS_THAN)
            {
                _currentToken = _lexer.GetNextToken();
                var secondLevelExpression = AdditionExpresion();
                var node = new LessThan {LeftOperand = param, RightOperand = secondLevelExpression};
                return RelationalExpressionPrime(node);
            }
            else if (_currentToken.Type == TokenType.GREATER_EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                var secondLevelExpression = AdditionExpresion();
                var node = new GreaterThan { LeftOperand = param, RightOperand = secondLevelExpression };
                return RelationalExpressionPrime(node);
            }
            else if (_currentToken.Type == TokenType.LESS_EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                var secondLevelExpression = AdditionExpresion();
                var node = new LessEqual { LeftOperand = param, RightOperand = secondLevelExpression };
                return RelationalExpressionPrime(node);
            }
            else if (_currentToken.Type == TokenType.GREATER_THAN)
            {
                _currentToken = _lexer.GetNextToken();
                var secondLevelExpression = AdditionExpresion();
                var node = new GreaterThan { LeftOperand = param, RightOperand = secondLevelExpression };
                return RelationalExpressionPrime(node);
            }
            else if (_currentToken.Type == TokenType.NOT_EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                var secondLevelExpression = AdditionExpresion();
                var node = new NotEqual { LeftOperand = param, RightOperand = secondLevelExpression };
                return RelationalExpressionPrime(node);
            }
            else if (_currentToken.Type == TokenType.EQUAL)
            {
                _currentToken = _lexer.GetNextToken();
                var secondLevelExpression = AdditionExpresion();
                var node = new Equal { LeftOperand = param, RightOperand = secondLevelExpression };
                return RelationalExpressionPrime(node);
            }
            return param;
        }

        private List<AccesorNode> IndexingAndAccess(List<AccesorNode> accessorList)
        {
            if (_currentToken.Type == TokenType.TK_LEFTBRACKET)
            {
                _currentToken = _lexer.GetNextToken();
                var expr = PascalExpression();
                if (_currentToken.Type == TokenType.TK_RIGHTBRACKET)
                {
                    _currentToken = _lexer.GetNextToken();
                    accessorList.Insert(0, new IndexAccesorNode {IndexExpression = expr});
                    accessorList = IndexingAndAccess(accessorList);
                    return accessorList;
                }
                else
                {
                    throw new SyntaxException($"Unexpected Token: {_currentToken.Lexeme} Expected: ']' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
            else if (_currentToken.Type == TokenType.TK_ACCESS)
            {
                _currentToken = _lexer.GetNextToken();
                if (_currentToken.Type == TokenType.ID)
                {
                    var idNode = new IdNode() {Value = _currentToken.Lexeme};
                    _currentToken = _lexer.GetNextToken();
                    accessorList.Insert(0, new PropertyAccesorNode() { IdNode = idNode });
                    accessorList = IndexingAndAccess(accessorList);
                    return accessorList;
                }
                else
                {
                    throw new SyntaxException(
                        $"Unexpected Token: {_currentToken.Lexeme} Expected: '[' at Column: {_currentToken.Column} Row: {_currentToken.Row}");
                }
            }
           
            return accessorList;
        }

    }
}
