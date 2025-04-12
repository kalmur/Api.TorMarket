
namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListing
{
    [Serializable]
    internal class INvalidOperationException : Exception
    {
        public INvalidOperationException()
        {
        }

        public INvalidOperationException(string? message) : base(message)
        {
        }

        public INvalidOperationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}