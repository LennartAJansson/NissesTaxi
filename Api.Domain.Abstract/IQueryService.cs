namespace Api.Domain.Abstract;

using Model;

public interface IQueryService
{
  Task<Person?> GetPerson(Guid id);
  Task<IEnumerable<Person>> GetPeople();
}
