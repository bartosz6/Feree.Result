using System.Collections;
using System.Collections.Generic;
using Feree.ResultType.Results;

namespace Feree.ResultType.Errors
{
    public record AggregateError(IEnumerable<IError> InnerErrors) : IError
    {
        public string Message => "aggregate error, see InnerErrors for details";
    }
}