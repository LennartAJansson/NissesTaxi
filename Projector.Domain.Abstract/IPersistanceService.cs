namespace Projector.Domain.Abstract;

using Model;

public interface IPersistanceService
{
  Task<Person> AddPerson(Person person);
  Task<Person> UpdatePerson(Person person);
  Task<Person> DeletePerson(Guid id);
  //Task<Person> GetPerson(Guid id);
  //Task<IEnumerable<Person>> GetPeople();
}