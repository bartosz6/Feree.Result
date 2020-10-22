using System.Runtime.CompilerServices;
using Feree.ResultType.Results;
using Newtonsoft.Json;

namespace Feree.ResultType.Errors
{
    public readonly struct Error : IError
    {
        public Error(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            MemberName = memberName;
            SourceFilePath = sourceFilePath;
            SourceLineNumber = sourceLineNumber;
            Message = message;
        }

        public string MemberName { get; }

        public string SourceFilePath { get; }

        public int SourceLineNumber { get; }

        public string Message { get; }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}