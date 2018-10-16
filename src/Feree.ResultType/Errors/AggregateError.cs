using System.Collections.Generic;
using Feree.ResultType.Results;

namespace Feree.ResultType.Errors
{
    public struct AggregateError : IError
    {
        public AggregateError(IError[] innerErrors) => InnerErrors = innerErrors;

        public IReadOnlyCollection<IError> InnerErrors { get; }
        public string Message => "aggregate error, see InnerErrors for details";
    }
}