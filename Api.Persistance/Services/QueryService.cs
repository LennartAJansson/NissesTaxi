namespace Api.Persistance.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Api.Domain.Abstract;

using Model;

public class QueryService : IQueryService
{
  public Task<Person> GetPerson(Guid id) => throw new NotImplementedException();

  public Task<IEnumerable<Person>> GetPeople() => throw new NotImplementedException();
}
