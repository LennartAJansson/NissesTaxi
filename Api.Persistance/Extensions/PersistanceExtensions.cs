namespace Api.Persistance.Extensions;

using Api.Domain.Abstract;
using Api.Persistance.Services;

using Microsoft.Extensions.DependencyInjection;

public static class PersistanceExtensions
{
  public static IServiceCollection AddApiPersistance(this IServiceCollection services, Func<string>? connectionStringFunc = null)
  {
    var connectionString = connectionStringFunc.Invoke();
    _ = services.AddTransient<IQueryService>(sp=>new QueryService(connectionString));
    _ = services.AddTransient<ICommandService, CommandService>();

    return services;
  }
}
