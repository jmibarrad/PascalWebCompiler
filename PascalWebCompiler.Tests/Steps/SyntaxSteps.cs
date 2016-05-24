using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PascalWebCompiler.Lexer;
using PascalWebCompiler.Syntactic;
using TechTalk.SpecFlow;

namespace PascalWebCompiler.Tests.Steps
{
    [Binding]
    public class SyntaxSteps
    {
        private Lexer.Lexer _lexer;
        private SyntacticParser _parser;

        [Given(@"the following source code '(.*)'")]
        public void GivenTheFollowingSourceCode(string p0)
        {
            _lexer = new Lexer.Lexer(new SourceCodeContent(p0));
            _parser = new SyntacticParser(_lexer);
        }
        
        [When(@"We Parse")]
        public void WhenWeParse()
        {
            try
            {
                _parser.Parse();
                ScenarioContext.Current["Passed"] = true;
            }
            catch (Exception err)
            {
                ScenarioContext.Current["Syntactic Exception"] = err;
            }
        }
        
        [Then(@"the result should pass")]
        public void ThenTheResultShouldPass()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey("Passed"));
        }
        
        [Then(@"the result should fail")]
        public void ThenTheResultShouldFail()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey("Syntactic Exception"));
        }
    }
}
