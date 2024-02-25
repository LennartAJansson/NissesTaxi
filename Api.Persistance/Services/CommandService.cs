namespace Api.Persistance.Services;
using System.Threading.Tasks;

using Api.Domain.Abstract;

using Common.Contracts;

public class CommandService(ICommandQueue commandQueue) : ICommandService
{
  public async Task AddPerson(AddPersonCommand person)
    => await commandQueue.SendAsync(person);
  public async Task DeletePerson(DeletePersonCommand person)
    => await commandQueue.SendAsync(person);
  public async Task UpdatePerson(UpdatePersonCommand person)
    => await commandQueue.SendAsync(person);
}
