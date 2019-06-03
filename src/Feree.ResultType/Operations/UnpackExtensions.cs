using System;
using System.Threading.Tasks;
using Feree.ResultType.Results;

namespace Feree.ResultType.Operations
{
    public static class UnpackExtensions
    {
        public static void Unpack<T>(this IResult<T> result, out T payload, out IError error)
        {
            switch (result)
            {
                case Success<T> success:
                    payload = success.Payload;
                    error = null;
                    return;
                case Failure<T> failure:
                    payload = default;
                    error = failure.Error;
                    return;
                default:
                    throw new InvalidOperationException("unknown result type");
            }
        }
    }
}