namespace AccountShop.Abtractions.Result
{
    public interface IResultT<T> : IResult where T : class
    {
        public T Data { get; set; }
    }
}