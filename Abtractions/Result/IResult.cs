using AccountShop.Abtractions.Error;

namespace AccountShop.Abtractions.Result
{
    public interface IResult
    {
        public string Message { get; }

        public string StatusCode { get; }

        public IError Error { get; }
    }
}