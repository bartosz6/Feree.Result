using System.Threading.Tasks;
using Feree.ResultType.Converters;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class AsResultConvertersTests
    {
        [Fact]
        public async Task AsResultAsync_usedOnPayload_returnsSuccess()
        {
            var result = await "test".AsResultAsync();
            
            result.ShouldBeSuccess();
            result.Payload().ShouldBe("test");
        }
    }
}