namespace Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Domain.Abstract;

using MediatR;

using Microsoft.Extensions.Logging;

using Model;

using static Domain.Mediators.UpdatePersonMediator;

public class UpdatePersonMediator(ILogger<UpdatePersonMediator> logger, IPersistanceService service)
  : IRequestHandler<UpdatePersonRequest, UpdatePersonResponse>
{
  public async Task<UpdatePersonResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");
    Person person = new() { Id = request.Id, Name = request.Name };
    person = await service.UpdatePerson(person);
    return UpdatePersonResponse.Create(person.Id, person.Name);
  }

  public record UpdatePersonRequest(Guid Id, string Name) : IRequest<UpdatePersonResponse>
  {
    public static UpdatePersonRequest Create(Guid id, string name) => new(id, name);
  };
  public record UpdatePersonResponse(Guid Id, string Name)
  {
    public static UpdatePersonResponse Create(Guid id, string name) => new(id, name);
  };
}

