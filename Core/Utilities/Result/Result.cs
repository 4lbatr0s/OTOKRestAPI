namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public bool Success { get; }

        public string Message { get; }

        public Result(bool Success, string Message):this(Success) //this is the constructor below(with only bool Success) paramter. By this way we make two constructors to work at a time.
        {
            this.Message = Message;
        }

        public Result(bool Success)
        {
            this.Success = Success;
        }

        public Result(string Message)
        {
            this.Message = Message;
        }
    }
}
