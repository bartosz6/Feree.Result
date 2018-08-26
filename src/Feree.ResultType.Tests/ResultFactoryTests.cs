using System.Threading.Tasks;
using Feree.ResultType.Errors;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Feree.ResultType.Tests.Helpers;
using NUnit.Framework;

namespace Feree.ResultType.Tests
{
    public class ResultFactoryTests
    {
        private const string CurrentFileName = "ResultFactoryTests.cs";
        private const string Message = "an error occured";

        [Test]
        public void CreateFailure_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled()
        {
            var failure = ResultFactory.CreateFailure(Message).AsFailure();
            
            AssertFieldsAreFilled(failure, Message, 18, nameof(CreateFailure_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled));
        }
        
        [Test]
        public void CreateFailureOfT_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled()
        {
            var failure = ResultFactory.CreateFailure<int>(Message).AsFailure();
            
            AssertFieldsAreFilled(failure, Message, 26, nameof(CreateFailureOfT_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled));
        }

        private void AssertFieldsAreFilled(Failure failure, string message, int line, string methodName)
        {
            Assert.That(((Error) failure.Error).Message, Is.EqualTo(message));
            Assert.That(((Error) failure.Error).SourceLineNumber, Is.EqualTo(line));
            Assert.That(((Error) failure.Error).SourceFilePath, Contains.Substring(CurrentFileName));
            Assert.That(((Error) failure.Error).MemberName, Is.EqualTo(methodName));
        }
    }
}