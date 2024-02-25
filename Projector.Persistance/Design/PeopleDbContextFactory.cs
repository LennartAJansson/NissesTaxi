namespace Projector.Persistance.Design;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using Projector.Persistance.Context;

/*
UserSecret (glöm inte att ha samma i applikationen sen):
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;User=root;Password=password;Database=NissesTaxi"
}

Add-Migration -Name your-migration-name -Context PeopleDbContext -Project Projector.Persistance -StartupProject Projector.Persistance
Update-Database -Context PeopleDbContext -Project Projector.Persistance -StartupProject Projector.Persistance
*/
public class PeopleDbContextFactory : IDesignTimeDbContextFactory<PeopleDbContext>
{
  public PeopleDbContext CreateDbContext(string[] args)
  {
    IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<PeopleDbContext>()
            .Build();
    string? connectionString = configuration.GetConnectionString("DefaultConnection");

    DbContextOptionsBuilder<PeopleDbContext> optionsBuilder = new();
    ServerVersion version = ServerVersion.AutoDetect(connectionString);
    _ = optionsBuilder.UseMySql(connectionString, version);

    return new PeopleDbContext(optionsBuilder.Options);
  }
}

