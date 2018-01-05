namespace Feree.ResultType
{
    public struct Error : IError
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}