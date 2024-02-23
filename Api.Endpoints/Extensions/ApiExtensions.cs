namespace Api.Endpoints.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public static class ApiExtensions
{
  public static IServiceCollection AddApiEndpoints(this IServiceCollection services)
  {
    _ = services.AddControllers();
    return services;
  }

  public static WebApplication UseApiControllers(this WebApplication app)
  {
    _ = app.MapControllers();
    return app;
  }
}
