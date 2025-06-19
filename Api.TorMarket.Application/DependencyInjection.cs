using Api.TorMarket.Application.Abstractions.Mediator;
using Api.TorMarket.Application.CQRS;
using Microsoft.Extensions.DependencyInjection;

namespace Api.TorMarket.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(
        this IServiceCollection services 
    ) => services
            .AddMediators()
            .AddValidators();

    private static IServiceCollection AddMediators(
        this IServiceCollection services
    ) => services.Scan(
        scan => scan.FromAssembliesOf(typeof(DependencyInjection))
            .AddClasses(
                classes => classes.AssignableTo(typeof(IQueryHandler<,>))
            )
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(
                classes => classes.AssignableTo(typeof(ICommandHandler<,>))
            )
            .AsImplementedInterfaces()
            .WithScopedLifetime()
    );

    private static IServiceCollection AddValidators(
        this IServiceCollection services
    ) => services.Scan(
        scan => scan.FromAssembliesOf(typeof(DependencyInjection))
            .AddClasses(
                classes => classes.AssignableTo(typeof(IValidator<,>))
            )
            .AsImplementedInterfaces()
            .WithScopedLifetime()
    );
}
