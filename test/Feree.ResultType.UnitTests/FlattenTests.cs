using System.Collections.Generic;
using System.Linq;
using Feree.ResultType.Errors;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;
using Shouldly;
using Xunit;

namespace Feree.ResultType.UnitTests
{
    public class FlattenTests
    {
        [Fact]
        public void Flatten_givenCollectionOfResults_whenItHasFailure_returnsFailure()
        {
            var resultCollection = Produce10ResultsWithErrorsOnIndex5And9();

            var flattenedResult = resultCollection.Flatten();

            flattenedResult.ShouldBeFailure();
            flattenedResult.Error().ShouldBeOfType(typeof(AggregateError));
            flattenedResult.Error().To<AggregateError>().InnerErrors.ToArray()[0].Message.ShouldBe("error");
            flattenedResult.Error().To<AggregateError>().InnerErrors.ToArray()[1].Message.ShouldBe("another error");
        }

        [Fact]
        public void Flatten_givenCollectionOfResults_whenAllAreSuccess_returnsSuccess()
        {
            var resultCollection = Produce10Successes();

            var flattenedResult = resultCollection.Flatten();

            flattenedResult.ShouldBeSuccess();
        }

        IEnumerable<IResult<int>> ProduceSuccess(int howMany)
        {
            while (howMany-- > 0)
                yield return ResultFactory.CreateSuccess(howMany);
        }

        IEnumerable<IResult<int>> Produce10Successes() => ProduceSuccess(10);

        IEnumerable<IResult<int>> Produce10ResultsWithErrorsOnIndex5And9()
        {
            var resultCollection = ProduceSuccess(10).ToArray();
            resultCollection[5] = ResultFactory.CreateFailure<int>("error");
            resultCollection[9] = ResultFactory.CreateFailure<int>("another error");

            return resultCollection;
        }
    }
}