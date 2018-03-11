using System.Runtime.CompilerServices;

namespace Feree.ResultType.Errors
{
    public struct Error : IError
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
    }
}