namespace SimpleResponseWrapper
{
    public class Result
    {
        public Result(int? code, object data)
        {
            Code = code;
            Data = data;
        }
        public int? Code { get; init; }
        public object Data { get; init; }
    }
}
