namespace Persistance.Extensions;

using Domain.Abstract;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Persistance.Context;
using Persistance.Services;

public static class PersistanceExtensions
{
  public static IServiceCollection AddPersistance(this IServiceCollection services, Func<string>? connectionStringFunc = null)
  {
    if (connectionStringFunc is null)
    {
      throw new ArgumentNullException("You must provide a connectionstring");
    }

    string connectionString = connectionStringFunc?.Invoke()
      ?? throw new ArgumentNullException(nameof(connectionStringFunc));

    _ = services.AddDbContext<IPeopleDbContext, PeopleDbContext>(optionsAction =>
    {
      ServerVersion version = ServerVersion.AutoDetect(connectionString);
      _ = optionsAction.UseMySql(connectionString, version);
    });

    _ = services.AddTransient<IPersistanceService, PersistanceService>();
    return services;
  }
}
