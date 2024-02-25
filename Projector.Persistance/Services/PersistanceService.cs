namespace Projector.Persistance.Services;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Model;

using Projector.Domain.Abstract;
using Projector.Persistance.Context;

public class PersistanceService(IPeopleDbContext context) : IPersistanceService
{
  public async Task<Person> AddPerson(Person person)
  {
    bool exists = context.People.Any(p => p.Id == person.Id);
    if (exists)
    {
      throw new InvalidOperationException("Person already exists");
    }

    _ = context.Add(person);
    _ = await context.SaveChangesAsync();

    return person;
  }

  public async Task<Person> UpdatePerson(Person person)
  {
    bool exists = context.People.Any(p => p.Id == person.Id);
    if (!exists)
    {
      throw new InvalidOperationException("Person not found");
    }

    _ = context.Update(person);
    _ = await context.SaveChangesAsync();

    return person;
  }

  public async Task<Person> DeletePerson(Guid id)
  {
    Person? person = await context.People.FindAsync(id);
    if (person is null)
    {
      throw new InvalidOperationException("Person not found");
    }
    _ = context.Remove(person);
    _ = await context.SaveChangesAsync();

    return person;
  }

  //  public Task<IEnumerable<Person>> GetPeople() => throw new NotImplementedException();
  //  public Task<Person> GetPerson(Guid id) => throw new NotImplementedException();
}