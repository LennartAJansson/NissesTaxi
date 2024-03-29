﻿namespace Projector.Persistance.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Persistance.Context;
using Persistance.Services;

using Projector.Domain.Abstract;

public static class PersistanceExtensions
{
  public static IServiceCollection AddProjectorPersistance(this IServiceCollection services, Func<string>? connectionStringFunc = null)
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
    }, ServiceLifetime.Transient, ServiceLifetime.Transient);

    _ = services.AddTransient<IPersistanceService, PersistanceService>();
    return services;
  }

  public static IHost UpdateDatabase(this IHost host)
  {
    using IServiceScope scope = host.Services.CreateScope();
    IPeopleDbContext context = scope.ServiceProvider.GetRequiredService<IPeopleDbContext>();
    context.Migrate();
    return host;
  }
}
