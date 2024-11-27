namespace Api.TorMarket.Application.Errors
{
    public class UnprocessableEntity : Error
    {
        public UnprocessableEntity(string errorMessage, string? field = null) 
            : base(errorMessage)
        {
            Field = field;
        }
        public string? Field { get; }

    }
}
