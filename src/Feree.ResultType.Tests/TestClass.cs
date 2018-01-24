using System.Threading.Tasks;
using Feree.ResultType.Converters;
using Feree.ResultType.Results;
using Feree.ResultType.Unit;

namespace Feree.ResultType.Tests
{
    public class TestClass
    {
        public virtual Task<IResult<Empty>> TestMethodAsync() => null;
     
        public virtual IResult<Empty> TestMethod() => null;
        
        public virtual IResult<T> TestMethod<T>(T arg) => arg.AsResult();
    }
}