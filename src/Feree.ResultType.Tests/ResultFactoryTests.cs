using System.Threading.Tasks;
using Feree.ResultType.Errors;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Feree.ResultType.Unit;
using NUnit.Framework;

namespace Feree.ResultType.Tests
{
    public class ResultFactoryTests
    {
        private const string CurrentFileName = "ResultFactoryTests.cs";

        [Test]
        public void CreateFailure_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled()
        {
            var message = "an error occured";
            var failure = (Failure<Empty>) ResultFactory.CreateFailure(message);
            
            Assert.That(((Error)failure.Error).Message, Is.EqualTo(message));
            Assert.That(((Error)failure.Error).SourceLineNumber, Is.EqualTo(18));
            Assert.That(((Error)failure.Error).SourceFilePath, Contains.Substring(CurrentFileName));
            Assert.That(((Error)failure.Error).MemberName, Is.EqualTo(nameof(CreateFailure_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled)));
        }
        
        [Test]
        public void CreateFailureOfT_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled()
        {
            var message = "an error occured";
            var failure = (Failure<int>) ResultFactory.CreateFailure<int>(message);
            
            Assert.That(((Error)failure.Error).Message, Is.EqualTo(message));
            Assert.That(((Error)failure.Error).SourceLineNumber, Is.EqualTo(30));
            Assert.That(((Error)failure.Error).SourceFilePath, Contains.Substring(CurrentFileName));
            Assert.That(((Error)failure.Error).MemberName, Is.EqualTo(nameof(CreateFailureOfT_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled)));
        }
        
        [Test]
        public async Task CreateFailureAsync_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled()
        {
            var message = "an error occured";
            var failure = (Failure<Empty>) await ResultFactory.CreateFailure(Task.Factory.StartNew(() => message));
            
            Assert.That(((Error)failure.Error).Message, Is.EqualTo(message));
            Assert.That(((Error)failure.Error).SourceLineNumber, Is.EqualTo(42));
            Assert.That(((Error)failure.Error).SourceFilePath, Contains.Substring(CurrentFileName));
            Assert.That(((Error)failure.Error).MemberName, Is.EqualTo(nameof(CreateFailureAsync_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled)));
        }
        
        [Test]
        public async Task CreateFailureOfTAsync_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled()
        {
            var message = "an error occured";
            var failure = (Failure<int>) await ResultFactory.CreateFailure<int>(Task.Factory.StartNew(() => message));
            
            Assert.That(((Error)failure.Error).Message, Is.EqualTo(message));
            Assert.That(((Error)failure.Error).SourceLineNumber, Is.EqualTo(54));
            Assert.That(((Error)failure.Error).SourceFilePath, Contains.Substring(CurrentFileName));
            Assert.That(((Error)failure.Error).MemberName, Is.EqualTo(nameof(CreateFailureOfTAsync_GivenMessage_ReturnsFailureThatContainsErrorWithFieldsFilled)));
        }
    }
}