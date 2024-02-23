using MediatR;

using Projector.Domain.Extensions;
using Projector.Persistance.Extensions;

using static Projector.Domain.Mediators.AddPersonMediator;

IHost host = Host.CreateDefaultBuilder(args)
  .ConfigureAppConfiguration((hostContext, config) =>
  {
    _ = config.AddUserSecrets<Program>();
  })
  .ConfigureServices((hostContext, services) =>
  {
    _ = services.AddProjectorDomain();
    _ = services.AddProjectorPersistance(() => hostContext.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentException("Connectionstring for heavens sake!!!"));
  })
  .Build();

using IServiceScope scope = host.Services.CreateScope();
AddPersonRequest request = AddPersonRequest.Create("Semira");
IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
AddPersonResponse response = await mediator.Send(request);
Console.WriteLine(response);
