namespace Api.Persistance.Extensions;

using Api.Domain.Abstract;
using Api.Persistance.Services;

using Microsoft.Extensions.DependencyInjection;

public static class PersistanceExtensions
{
  public static IServiceCollection AddApiPersistance(this IServiceCollection services, Func<string>? connectionStringFunc = null)
  {
    _ = services.AddTransient<IQueryService, QueryService>();
    _ = services.AddTransient<ICommandService, CommandService>();

    return services;
  }
}
