using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Unions;
using Api.TorMarket.Domain.Models;
using MediatR;

namespace Api.TorMarket.Application.CQRS.Queries.Listings.GetListing
{
    public class GetListingsByNameHandler(
        IValidator<GetListingsByNameQuery, GetListingsByNameFailure> validator,
        IListingRepository listingRepository
    ) : IRequestHandler<GetListingsByNameQuery, ResultOrError<ListingWithCategory, GetListingsByNameFailure>>
    {
        public async Task<ResultOrError<ListingWithCategory, GetListingsByNameFailure>> Handle(
            GetListingsByNameQuery request,
            CancellationToken cancellationToken
        )
        {
            var validationErrors = await validator.ValidateAsync(
                 request,
                 cancellationToken
            );

            if (validationErrors is not null)   
                return validationErrors;

            return await listingRepository.GetByName(
                request.ToRequest(),
                cancellationToken
            );
        }
    }
}