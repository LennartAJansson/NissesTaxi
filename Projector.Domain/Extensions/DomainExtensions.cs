namespace Projector.Domain.Extensions;

using Domain.Mediators;

using Microsoft.Extensions.DependencyInjection;

public static class DomainExtensions
{
  public static IServiceCollection AddProjectorDomain(this IServiceCollection services)
  {
    _ = services.AddMediatR(configuration =>
    {
      _ = configuration.RegisterServicesFromAssemblyContaining<AddPersonMediator>();
    });
    return services;
  }
}