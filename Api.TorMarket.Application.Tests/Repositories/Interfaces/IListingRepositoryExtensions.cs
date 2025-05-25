using Api.TorMarket.Application.Repositories.Interfaces;
using Api.TorMarket.Application.Tests.ModelGenerators;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Api.TorMarket.Application.Tests.Repositories.Interfaces;

internal static class IListingRepositoryExtensions
{
    internal static void GetByIdAsync_Mock_AlwaysFound(
        this IListingRepository listingRepository,
        int listingId = 1
    ) => listingRepository.GetByIdAsync(
        Arg.Any<int>(),
        Arg.Any<CancellationToken>()
    ).Returns(
        args => ListingGenerator.GenerateListingWithUserAndCategory(
            listingId: args.ArgAt<int>(0)
        )
    );

    internal static void GetByIdAsync_Mock_NeverFound(
        this IListingRepository listingRepository
    ) => listingRepository.GetByIdAsync(
        Arg.Any<int>(),
        Arg.Any<CancellationToken>()
    ).ReturnsNull();
}

