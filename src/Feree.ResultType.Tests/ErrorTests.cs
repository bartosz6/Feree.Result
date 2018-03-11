using Feree.ResultType.Errors;
using NUnit.Framework;

namespace Feree.ResultType.Tests
{
    [TestFixture]
    public class ErrorTests
    {
        [Test]
        public void GivenErrorMessage_ContainsMessage()
        {
            var message = "an error occured";
            var error = new Error(message);
            
            Assert.That(error.Message, Is.EqualTo(message));
        }
        
        [Test]
        public void GivenErrorMessage_ContainsLineNumber()
        {
            var error = new Error("an error occured");
            
            Assert.That(error.SourceLineNumber, Is.EqualTo(21));
        }
        
        [Test]
        public void GivenErrorMessage_ContainsSourceFileName()
        {
            var error = new Error("an error occured");
            
            Assert.That(error.SourceFilePath, Contains.Substring("ErrorTests.cs"));
        }
        
        [Test]
        public void GivenErrorMessage_ContainsCallerMethodName()
        {
            var error = new Error("an error occured");
            
            Assert.That(error.MemberName, Is.EqualTo(nameof(GivenErrorMessage_ContainsCallerMethodName)));
        }
    }
}