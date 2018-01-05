using System;
using Feree.ResultType;
using Feree.ResultType.Tests.Helpers;
using NUnit.Framework;

namespace Feree.ResultType.Tests
{
    [TestFixture]
    public class SuccessTests
    {
        [Test]
        public void Success_GivenObject_ShouldKeepItAsPayload()
        {
            var success = ResultFactory.CreateSuccess("string").AsSuccess();

            Assert.That(success.Payload, Is.EqualTo("string"));
        }
        
        [Test]
        public void Success_GivenNull_ShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => ResultFactory.CreateSuccess<object>(null));
        }
        
        [Test]
        public void Success_ShouldContainEmpty()
        {
            var success = ResultFactory.CreateSuccess().AsSuccess();
            
            Assert.That(success.Payload, Is.EqualTo(new Empty()));
        }
    }
}