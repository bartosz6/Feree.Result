using System;
using Feree.ResultType.Core;
using Feree.ResultType.Tests.Helpers;
using NUnit.Framework;

namespace Feree.ResultType.Tests
{
    [TestFixture]
    public class FailureTests
    {
        [Test]
        public void Failure_GivenError_ShouldKeepItAsError()
        {
            var error = new Error();
            var failure = ResultFactory.CreateFailure(error).AsFailure();
            
            Assert.That(failure.Error, Is.EqualTo(error));
        }
        
        [Test]
        public void Failure_GivenNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => ResultFactory.CreateFailure(null as IError));
        }
    }
}