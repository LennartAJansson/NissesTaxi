namespace Projector.Endpoints.Extensions;

using Microsoft.Extensions.DependencyInjection;

using Projector.Endpoints.Services;

public static class EndpointExtensions
{
  public static IServiceCollection AddProjectorEndpoints(this IServiceCollection services)
  {
    _ = services.AddHostedService<MessageWorker>();

    return services;
  }
}