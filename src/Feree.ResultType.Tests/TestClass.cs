using System.Threading.Tasks;

namespace Feree.ResultType.Tests
{
    public class TestClass
    {
        public virtual Task<IResult<Empty>> TestMethodAsync() => null;
     
        public virtual IResult<Empty> TestMethod() => null;
        
        public virtual IResult<T> TestMethod<T>(T arg) => arg.AsResult();
    }
}