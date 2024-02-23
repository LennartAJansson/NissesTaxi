namespace Api.Domain.Extensions;

using Domain.Mediators;

using Microsoft.Extensions.DependencyInjection;

public static class ApiDomainExtensions
{
  public static IServiceCollection AddApiDomain(this IServiceCollection services)
  {
    _ = services.AddMediatR(configuration =>
    {
      _ = configuration.RegisterServicesFromAssemblyContaining<AddPersonMessageMediator>();
    });
    return services;
  }
}