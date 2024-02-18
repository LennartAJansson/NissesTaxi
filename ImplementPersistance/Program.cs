using Domain.Extensions;

using MediatR;

using Persistance.Extensions;

using static Domain.Mediators.AddPersonMediator;

IHost host = Host.CreateDefaultBuilder(args)
  .ConfigureAppConfiguration((hostContext, config) =>
  {
    _ = config.AddUserSecrets<Program>();
  })
  .ConfigureServices((hostContext, services) =>
  {
    _ = services.AddDomain();
    _ = services.AddPersistance(() => hostContext.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentException("Connectionstring for heavens sake!!!"));
  })
  .Build();

using IServiceScope scope = host.Services.CreateScope();
AddPersonRequest request = AddPersonRequest.Create("Nisse Hult");
IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
AddPersonResponse response = await mediator.Send(request);
Console.WriteLine(response);
