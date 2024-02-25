using Api.Domain.Extensions;
using Api.Persistance.Extensions;

using Common.Messaging.Extensions;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Projector.Domain.Extensions;
using Projector.Persistance.Extensions;

using static Api.Domain.Mediators.AddPersonMessageMediator;
using static Api.Domain.Mediators.GetPeopleMediator;
using static Api.Domain.Mediators.GetPersonMediator;
using static Projector.Domain.Mediators.AddPersonCommandMediator;

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

    _ = services.AddProjectorDomain();
    _ = services.AddProjectorPersistance(() => hostContext.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentException("Connectionstring for heavens sake!!!"));
    _ = services.AddMessaging();
  })
  .Build();

await host.StartAsync();

using IServiceScope scope = host.Services.CreateScope();

ISender sender = scope.ServiceProvider.GetRequiredService<ISender>();
ILogger<Program> logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

{
  logger.LogInformation("Adding first person");
  AddPersonRequest request = AddPersonRequest.Create("Olle Olsson");
  AddPersonResponse response = await sender.Send(request);
  logger.LogInformation("Response: {response}",response);
}

{
  logger.LogInformation("Adding second person");
  AddPersonRequest request = AddPersonRequest.Create("Pelle Persson");
  AddPersonResponse response = await sender.Send(request);
  logger.LogInformation("Response: {response}", response);
}

{
  logger.LogInformation("Reading people");
  GetPeopleRequest request = GetPeopleRequest.Create();
  IEnumerable<GetPersonResponse> response = await sender.Send(request);
  foreach(var person in response)
    logger.LogInformation("Found person: {person}", person);
}

await host.StopAsync();
