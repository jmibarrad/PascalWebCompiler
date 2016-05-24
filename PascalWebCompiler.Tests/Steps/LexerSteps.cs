using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PascalWebCompiler.Lexer;
using TechTalk.SpecFlow;

namespace PascalWebCompiler.Tests.Steps
{
    [Binding]
    public class LexerSteps
    {
        Lexer.Lexer _lexer;
        private readonly List<Token> _tokenList = new List<Token>();
        [Given(@"I have an input of '(.*)'")]
        public void GivenIHaveAnInputOf(string p0)
        {

            _lexer = new Lexer.Lexer(new SourceCodeContent(p0));
        }

        [When(@"We Tokenize")]
        public void WhenWeTokenize()
        {
            Token currentToken = _lexer.GetNextToken();

            while (currentToken.Type != TokenType.EOF)
            {

                _tokenList.Add(currentToken);
                currentToken = _lexer.GetNextToken();

            }
            _tokenList.Add(currentToken);
        }

        [Then(@"the result should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                Assert.AreEqual(table.Rows[i]["Type"], _tokenList[i].Type.ToString(), "The TokenTypes do not match.");
                Assert.AreEqual(table.Rows[i]["Lexeme"], _tokenList[i].Lexeme, "The TokenTypes do not match.");
                Assert.AreEqual(table.Rows[i]["Row"], _tokenList[i].Row.ToString(), "The TokenTypes do not match.");
                Assert.AreEqual(table.Rows[i]["Column"], _tokenList[i].Column.ToString(), "The TokenTypes do not match.");
            }
        }
    }
}
