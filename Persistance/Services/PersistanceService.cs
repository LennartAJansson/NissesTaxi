namespace Persistance.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

using Domain.Abstract;

using Model;

using Persistance.Context;

public class PersistanceService(IPeopleDbContext context) : IPersistanceService
{
  public async Task<Person> AddPerson(Person person)
  {
    _ = context.Add(person);
    _ = await context.SaveChangesAsync();
    return person;
  }

  public Task<Person> DeletePerson(Guid id) => throw new NotImplementedException();
  public Task<IEnumerable<Person>> GetPeople() => throw new NotImplementedException();
  public Task<Person> GetPerson(Guid id) => throw new NotImplementedException();
  public Task<Person> UpdatePerson(Person person) => throw new NotImplementedException();
}