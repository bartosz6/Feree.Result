using System;
using System.Threading.Tasks;

namespace Feree.ResultType.Results
{
    public interface IResult
    {
        IResult<TNext> Bind<TNext>(Func<IResult<TNext>> next);
        Task<IResult<TNext>> BindAsync<TNext>(Func<Task<IResult<TNext>>> next);
    }

    public interface IResult<out T> : IResult
    {
        IResult<TNext> Bind<TNext>(Func<T, IResult<TNext>> next);
        Task<IResult<TNext>> BindAsync<TNext>(Func<T, Task<IResult<TNext>>> next);
    }
}