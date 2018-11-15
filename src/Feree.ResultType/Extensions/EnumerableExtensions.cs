using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feree.ResultType.Errors;
using Feree.ResultType.Factories;
using Feree.ResultType.Results;

namespace Feree.ResultType.Extensions
{
    public static class EnumerableExtensions
    {
        public static IResult<IEnumerable<T>> Flatten<T>(this IEnumerable<IResult<T>> results)
        {
            var resultList = results.ToList();
            var errors = resultList.OfType<Failure<T>>().Select(failure => failure.Error).ToArray();
            var payloads = resultList.OfType<Success<T>>().Select(success => success.Payload);
            return errors.Any()
                ? ResultFactory.CreateFailure<IEnumerable<T>>(new AggregateError(errors))
                : ResultFactory.CreateSuccess(payloads);
        }
        
        public static async Task<IResult<IEnumerable<T>>> Flatten<T>(this IEnumerable<Task<IResult<T>>> results)
        {
            var resultList = results.ToList();
            
            await Task.WhenAll(resultList); 

            var errors = resultList.Select(t => t.Result).OfType<Failure<T>>().Select(failure => failure.Error).ToArray();
            var payloads = resultList.Select(t => t.Result).OfType<Success<T>>().Select(success => success.Payload);
            return errors.Any()
                ? ResultFactory.CreateFailure<IEnumerable<T>>(new AggregateError(errors))
                : ResultFactory.CreateSuccess(payloads);
        }
    }
}