namespace Core.Utilities.Result
{
    public class DataResult<T> : Result, IDataResult<T> //we called the Result for only we did not want to repeat our code that we wrote in the Result class before.
    {
        public T Data { get; }

        public DataResult(T data, bool success, string message):base(success, message)
        {
            Data = data;
        }

        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }


    }
}
