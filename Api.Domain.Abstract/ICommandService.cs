namespace Api.Domain.Abstract;

using Model;

public interface ICommandService
{
  Task<Person> AddPerson(Person person);
  Task<Person> UpdatePerson(Person person);
  Task<Person> DeletePerson(Guid id);
}
