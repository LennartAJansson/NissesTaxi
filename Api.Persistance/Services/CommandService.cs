namespace Api.Persistance.Services;
using System;
using System.Threading.Tasks;

using Api.Domain.Abstract;

using Model;

public class CommandService : ICommandService
{
  public Task<Person> AddPerson(Person person) => throw new NotImplementedException();

  public Task<Person> UpdatePerson(Person person) => throw new NotImplementedException();

  public Task<Person> DeletePerson(Guid id) => throw new NotImplementedException();
}
