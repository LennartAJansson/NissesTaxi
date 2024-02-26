using Api.Domain.Extensions;
using Api.Persistance.Extensions;

using Common.Messaging.Extensions;

using MediatR;

using Projector.Domain.Extensions;
using Projector.Endpoints.Extensions;
using Projector.Persistance.Extensions;

using static Api.Domain.Mediators.AddPersonMessageMediator;
using static Api.Domain.Mediators.GetPeopleMediator;
using static Api.Domain.Mediators.GetPersonMediator;

IHost host = Host.CreateDefaultBuilder(args)
  .ConfigureAppConfiguration((hostContext, config) =>
  {
    _ = config.AddUserSecrets<Program>();
  })
  .ConfigureServices((hostContext, services) =>
  {
    _ = services.AddApiDomain();
    _ = services.AddApiPersistance(() => hostContext.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentException("Connectionstring for heavens sake!!!"));

    _ = services.AddProjectorEndpoints();
    _ = services.AddProjectorDomain();
    _ = services.AddProjectorPersistance(() => hostContext.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentException("Connectionstring for heavens sake!!!"));

    _ = services.AddMessaging();
  })
  .Build();

await host.StartAsync();

host.UpdateDatabase();

using IServiceScope scope = host.Services.CreateScope();

ISender sender = scope.ServiceProvider.GetRequiredService<ISender>();
ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

{
  logger.LogInformation("Adding first person");
  AddPersonRequest request = AddPersonRequest.Create("Berra Bertilsson");
  AddPersonResponse response = await sender.Send(request);
  logger.LogInformation("Response: {response}", response);
}

{
  logger.LogInformation("Adding second person");
  AddPersonRequest request = AddPersonRequest.Create("Adam Adamsson");
  AddPersonResponse response = await sender.Send(request);
  logger.LogInformation("Response: {response}", response);
}

await WriteAll();

await host.StopAsync();


async Task WriteAll()
{
  using IServiceScope scope = host.Services.CreateScope();
  ISender sender = scope.ServiceProvider.GetRequiredService<ISender>();
  ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

  IEnumerable<GetPersonResponse> people = await sender.Send(GetPeopleRequest.Create());
  foreach (GetPersonResponse person in people)
  {
    logger.LogInformation("Person: {person}", person);
  }
}
