namespace Common.Messaging.Nats.Extensions;

using Common.Contracts;
using Common.Messaging.Nats;
using Common.Messaging.Nats.Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using NATS.Client.Hosting;

public static class NatsExtensions
{
  public static IServiceCollection AddNats(this IServiceCollection services, IConfiguration configuration)
  {

    NatsServiceConfig? config = configuration.GetSection("Nats").Get<NatsServiceConfig>()
      ?? throw new ArgumentException("NATS config not found");
    _ = services.Remove(services.First(x => x.ServiceType == typeof(ICommandQueue)));
    _ = services.AddSingleton<ICommandQueue, NatsCommandQueue>();
    _ = services.AddSingleton(config);
    _ = services.AddNats();

    return services;
  }
}
