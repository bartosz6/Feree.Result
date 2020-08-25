using System.Threading.Tasks;
using Feree.ResultType.Converters;
using Feree.ResultType.Factories;
using Feree.ResultType.Operations;
using Feree.ResultType.Results;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class BindValueTaskTests
    {
        private static ValueTask<IResult<int>> Add5(int a) => new ValueTask<IResult<int>>((a + 5).AsResult());
        private static IResult<int> Add5Sync(int a) => (a + 5).AsResult();
        private static Task<IResult<int>> Add5Async(int a) => ResultFactory.CreateSuccessAsync(a + 5);
        
        private static ValueTask<IResult<int>> Fail(int _) => new ValueTask<IResult<int>>(ResultFactory.CreateFailure<int>("fail"));
        private static IResult<int> FailSync(int _) => ResultFactory.CreateFailure<int>("fail");
        private static Task<IResult<int>> FailAsync(int _) => ResultFactory.CreateFailureAsync<int>("fail");


        public class SuccessToSuccess
        {
            [Fact]
            public async Task BindAsync_onSync_givenSuccessValueTask_ReturnsSuccessValueTask()
            {
                var success = ResultFactory.CreateSuccess(5);

                var result = await success.BindAsync(Add5);

                result.ShouldBeSuccess();
                result.Payload().ShouldBe(10);
            }

            [Fact]
            public async Task BindAsync_onValueTask_givenSuccessValueTask_ReturnsSuccessValueTask()
            {
                var success = new ValueTask<IResult<int>>(ResultFactory.CreateSuccess(5));

                var result = await success.BindAsync(Add5);

                result.ShouldBeSuccess();
                result.Payload().ShouldBe(10);
            }

            [Fact]
            public async Task BindAsync_onAsyncValueTask_givenSuccessValueTask_ReturnsSuccessValueTask()
            {
                var success = new ValueTask<IResult<int>>(new TaskFactory().StartNew(() => ResultFactory.CreateSuccess(5)));

                var result = await success.BindAsync(Add5);

                result.ShouldBeSuccess();
                result.Payload().ShouldBe(10);
            }

            [Fact]
            public async Task BindAsync_onValueTask_givenSuccessSync_ReturnsSuccessValueTask()
            {
                var success = new ValueTask<IResult<int>>(ResultFactory.CreateSuccess(5));

                var result = await success.BindAsync(Add5Sync);

                result.ShouldBeSuccess();
                result.Payload().ShouldBe(10);
            }

            [Fact]
            public async Task BindAsync_onValueTask_givenSuccessTask_ReturnsSuccessValueTask()
            {
                var success = new ValueTask<IResult<int>>(ResultFactory.CreateSuccess(5));

                var result = await success.BindAsync(Add5Async);

                result.ShouldBeSuccess();
                result.Payload().ShouldBe(10);
            }

            [Fact]
            public async Task BindAsync_onTask_givenSuccessValueTask_ReturnsSuccessValueTask()
            {
                var success = ResultFactory.CreateSuccessAsync(5);

                var result = await success.BindAsync(Add5);

                result.ShouldBeSuccess();
                result.Payload().ShouldBe(10);
            }
        }
        
        public class SuccessToFailure
        {
            [Fact]
            public async Task BindAsync_onSync_givenFailureValueTask_ReturnsSuccessValueTask()
            {
                var success = ResultFactory.CreateSuccess(5);

                var result = await success.BindAsync(Fail);

                result.ShouldBeFailure();
                result.Error().Message.ShouldBe("fail");
            }
            
            [Fact]
            public async Task BindAsync_onAsync_givenFailureValueTask_ReturnsSuccessValueTask()
            {
                var success = ResultFactory.CreateSuccessAsync(5);

                var result = await success.BindAsync(Fail);

                result.ShouldBeFailure();
                result.Error().Message.ShouldBe("fail");
            }
            
            [Fact]
            public async Task BindAsync_onValueTask_givenFailureValueTask_ReturnsSuccessValueTask()
            {
                var success = new ValueTask<IResult<int>>(5.AsResult());

                var result = await success.BindAsync(Fail);

                result.ShouldBeFailure();
                result.Error().Message.ShouldBe("fail");
            }
            
            [Fact]
            public async Task BindAsync_onValueTask_givenFailureTask_ReturnsSuccessValueTask()
            {
                var success = new ValueTask<IResult<int>>(5.AsResult());

                var result = await success.BindAsync(FailAsync);

                result.ShouldBeFailure();
                result.Error().Message.ShouldBe("fail");
            }
            
            [Fact]
            public async Task BindAsync_onValueTask_givenFailureSync_ReturnsSuccessValueTask()
            {
                var success = new ValueTask<IResult<int>>(5.AsResult());

                var result = await success.BindAsync(FailSync);

                result.ShouldBeFailure();
                result.Error().Message.ShouldBe("fail");
            }
        }

        public class FailureToSuccess
        {
            [Fact]
            public async Task BindAsync_onValueTaskFailure_givenSyncResult_returnsFailure()
            {
                var failure = Fail(5);

                var result = await failure.BindAsync(Add5Sync);
                
                result.ShouldBeFailure();
                result.Error().Message.ShouldBe("fail");
            }
            
            [Fact]
            public async Task BindAsync_onValueTaskFailure_givenAsyncResult_returnsFailure()
            {
                var failure = Fail(5);

                var result = await failure.BindAsync(Add5Async);
                
                result.ShouldBeFailure();
                result.Error().Message.ShouldBe("fail");
            }
            
            [Fact]
            public async Task BindAsync_onValueTaskFailure_givenValueTaskResult_returnsFailure()
            {
                var failure = Fail(5);

                var result = await failure.BindAsync(Add5);
                
                result.ShouldBeFailure();
                result.Error().Message.ShouldBe("fail");
            }
        }
    }
}