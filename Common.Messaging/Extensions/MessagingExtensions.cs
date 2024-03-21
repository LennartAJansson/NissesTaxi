namespace Common.Messaging.Extensions;

using Common.Contracts;

using Microsoft.Extensions.DependencyInjection;

public static class MessagingExtensions
{
  public static IServiceCollection AddMessaging(this IServiceCollection services)
  {
    services.AddSingleton<ICommandQueue, InternalCommandQueue>();
    return services;
  }
}
