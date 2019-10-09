using System.Threading.Tasks;
using Feree.ResultType.Converters;
using Feree.ResultType.Errors;
using Feree.ResultType.Results;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class AsFailureConvertersTests
    {
        [Fact]
        public void AsFailureT_onMessage_returnsFailureWithErrorMessage()
        {
            var failure = "ojoj".AsFailure<string>();
            
            failure.ShouldBeFailure();
            failure.ShouldBeAssignableTo<Failure<string>>();
            failure.Error().Message.ShouldBe("ojoj");
            failure.Error().To<Error>().MemberName.ShouldBe(nameof(AsFailureT_onMessage_returnsFailureWithErrorMessage));
            failure.Error().To<Error>().SourceFilePath.ShouldEndWith(@"Feree.Result\test\Feree.ResultType.UnitTests\AsFailureConvertersTests.cs");
            failure.Error().To<Error>().SourceLineNumber.ShouldBe(15);
        }
        
        [Fact]
        public void AsFailure_onMessage_returnsFailureWithErrorMessage()
        {
            var failure = "ojoj".AsFailure();
            
            failure.ShouldBeFailure();
            failure.Error().Message.ShouldBe("ojoj");
            failure.Error().To<Error>().MemberName.ShouldBe(nameof(AsFailure_onMessage_returnsFailureWithErrorMessage));
            failure.Error().To<Error>().SourceFilePath.ShouldEndWith(@"Feree.Result\test\Feree.ResultType.UnitTests\AsFailureConvertersTests.cs");
            failure.Error().To<Error>().SourceLineNumber.ShouldBe(28);
        }
        
        [Fact]
        public async Task AsFailureAsync_onMessage_returnsFailureWithErrorMessage()
        {
            var failure = await "ojoj".AsFailureAsync();
            
            failure.ShouldBeFailure();
            failure.Error().Message.ShouldBe("ojoj");
            failure.Error().To<Error>().MemberName.ShouldBe(nameof(AsFailureAsync_onMessage_returnsFailureWithErrorMessage));
            failure.Error().To<Error>().SourceFilePath.ShouldEndWith(@"Feree.Result\test\Feree.ResultType.UnitTests\AsFailureConvertersTests.cs");
            failure.Error().To<Error>().SourceLineNumber.ShouldBe(40);
        }
        
        [Fact]
        public async Task AsFailureAsyncT_onMessage_returnsFailureWithErrorMessage()
        {
            var failure = await "ojoj".AsFailureAsync<int>();
            
            failure.ShouldBeFailure();
            failure.ShouldBeAssignableTo<Failure<int>>();
            failure.Error().Message.ShouldBe("ojoj");
            failure.Error().To<Error>().MemberName.ShouldBe(nameof(AsFailureAsyncT_onMessage_returnsFailureWithErrorMessage));
            failure.Error().To<Error>().SourceFilePath.ShouldEndWith(@"Feree.Result\test\Feree.ResultType.UnitTests\AsFailureConvertersTests.cs");
            failure.Error().To<Error>().SourceLineNumber.ShouldBe(52);
        }
    }
}