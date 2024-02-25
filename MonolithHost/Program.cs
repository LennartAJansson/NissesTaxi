using Api.Domain.Extensions;
using Api.Endpoints.Extensions;
using Api.Persistance.Extensions;

using Projector.Domain.Extensions;
using Projector.Endpoints.Extensions;
using Projector.Persistance.Extensions;

using Common.Messaging.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddApiEndpoints();
builder.Services.AddApiDomain();
builder.Services.AddApiPersistance(() => builder.Configuration.GetConnectionString("DefaultConnection")
?? throw new ArgumentException("Connectionstring for heavens sake!!!"));

builder.Services.AddProjectorEndpoints();
builder.Services.AddProjectorDomain();
builder.Services.AddProjectorPersistance(() => builder.Configuration.GetConnectionString("DefaultConnection")
?? throw new ArgumentException("Connectionstring for heavens sake!!!"));

builder.Services.AddMessaging();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Map Api Module Controllers
app.UseApiControllers();

//Map Hosts Controllers
app.MapControllers();

app.Run();
