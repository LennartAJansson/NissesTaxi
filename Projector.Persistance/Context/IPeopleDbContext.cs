namespace Projector.Persistance.Context;

using Microsoft.EntityFrameworkCore;

using Model;

public interface IPeopleDbContext : IDbContext
{
  DbSet<Person> People { get; }
}