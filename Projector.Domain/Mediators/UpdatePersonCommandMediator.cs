namespace Projector.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Common.Contracts;

using Domain.Abstract;

using MediatR;

using Microsoft.Extensions.Logging;

using Model;

using static Projector.Domain.Mediators.UpdatePersonCommandMediator;

public class UpdatePersonCommandMediator(ILogger<UpdatePersonCommandMediator> logger, IPersistanceService service)
  //: IRequestHandler<UpdatePersonRequest, UpdatePersonResponse>
  : IRequestHandler<UpdatePersonCommand>
{
  //public async Task<UpdatePersonResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
  public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");
    Person person = new() { Id = request.Id, Name = request.Name };
    person = await service.UpdatePerson(person);

    //return UpdatePersonResponse.Create(person.Id, person.Name);
  }

  //public record UpdatePersonRequest(Guid Id, string Name) : IRequest<UpdatePersonResponse>
  //{
  //  public static UpdatePersonRequest Create(Guid id, string name) => new(id, name);
  //};
  //public record UpdatePersonResponse(Guid Id, string Name)
  //{
  //  public static UpdatePersonResponse Create(Guid id, string name) => new(id, name);
  //};
}

