using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PascalWebCompiler.Lexer;

namespace PascalWebCompiler.Syntactic.Tree
{
    public class SentenceNode
    {
        public SentenceNode NextSentence;
    }

    public class DeclarationNode : SentenceNode
    {
        public IdNode ValueIdNode;
        public TokenType Type;
    }

    public class AssignmentNode : SentenceNode
    {
        public IdNode ValueIdNode;
        public TokenType Type;
        public ExpressionNode Value;
    }

    public class IfNode : SentenceNode
    {
        
    }

    public class ForNode : SentenceNode
    {
        
    }

    public class ForInNode : SentenceNode
    {
        
    }

    public class WhileNode : SentenceNode
    {
        
    }

    public class RepeatNode : SentenceNode
    {
        
    }

    public class CaseNode : SentenceNode
    {
        
    }

    public class RecordNode : SentenceNode
    {
        
    }

    public class ConstNode : SentenceNode
    {
        
    }

    public class FunctionDeclarationNode : SentenceNode
    {
        
    }

    public class ProcedureDeclarationNode : SentenceNode
    {

    }
}
