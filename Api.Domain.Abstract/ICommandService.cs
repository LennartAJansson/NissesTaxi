namespace Api.Domain.Abstract;

using Common.Contracts;

public interface ICommandService
{
  Task AddPerson(AddPersonCommand person);
  Task DeletePerson(DeletePersonCommand person);
  Task UpdatePerson(UpdatePersonCommand person);
}
