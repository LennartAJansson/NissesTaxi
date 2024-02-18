﻿namespace Persistance.Context;

using Microsoft.EntityFrameworkCore;

using Model;

public class PeopleDbContext : DbContext, IPeopleDbContext
{
  public DbSet<Person> People => Set<Person>();

  public PeopleDbContext(DbContextOptions<PeopleDbContext> options)
  : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(PeopleDbContext).Assembly);
    base.OnModelCreating(modelBuilder);
  }
}