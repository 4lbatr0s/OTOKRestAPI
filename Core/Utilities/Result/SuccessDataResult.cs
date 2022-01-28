namespace Core.Utilities.Result
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message):base(data, true, message)
        {

        }

        public SuccessDataResult(T data):base(data, true)
        {

        }

        public SuccessDataResult(string text) : base(default, false, text)
        { }

        public SuccessDataResult() : base(default, false)
        { }
    }
}
