using System.Threading.Tasks;
using Feree.ResultType.Converters;
using Feree.ResultType.Results;

namespace Feree.ResultType.Tests
{
    public class TestClass
    {
        public virtual Task<IResult<Unit>> TestMethodAsync() => null;
     
        public virtual IResult<Unit> TestMethod() => null;
        
        public virtual IResult<T> TestMethod<T>(T arg) => arg.AsResult();
    }
}