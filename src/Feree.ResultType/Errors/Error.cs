using System.Runtime.CompilerServices;
using Feree.ResultType.Results;

namespace Feree.ResultType.Errors
{
    public record Error(string Message,
        [CallerMemberName] string MemberName = "",
        [CallerFilePath] string SourceFilePath = "",
        [CallerLineNumber] int SourceLineNumber = 0) : IError;
}