using Api.Endpoints.Extensions;
using Api.Domain.Extensions;
using Api.Persistance.Extensions;

using Common.Messaging.Extensions;
using Common.Messaging.Nats.Extensions;

using Projector.Endpoints.Extensions;
using Projector.Domain.Extensions;
using Projector.Persistance.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddApiEndpoints()
  .AddApiDomain()
  .AddApiPersistance(() => builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentException("Connectionstring for heavens sake!!!"));

builder.Services.AddProjectorEndpoints()
  .AddProjectorDomain()
  .AddProjectorPersistance(() => builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new ArgumentException("Connectionstring for heavens sake!!!"));

builder.Services.AddMessaging()
  .AddNats(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
  _ = app.UseSwagger();
  _ = app.UseSwaggerUI();
};

app.UseHttpsRedirection();

app.UseAuthorization();

//Map Api Module Controllers
app.UseApiControllers();

//Map Hosts Controllers
app.MapControllers();

app.Run();
