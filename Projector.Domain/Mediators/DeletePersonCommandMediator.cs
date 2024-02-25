namespace Projector.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Common.Contracts;

using MediatR;

using Microsoft.Extensions.Logging;

using Model;

using Projector.Domain.Abstract;

using static Projector.Domain.Mediators.DeletePersonCommandMediator;

public class DeletePersonCommandMediator(ILogger<DeletePersonCommandMediator> logger, IPersistanceService service)
  //: IRequestHandler<DeletePersonRequest, DeletePersonResponse>
  : IRequestHandler<DeletePersonCommand>
{
  //public async Task<DeletePersonResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
  public async Task Handle(DeletePersonCommand request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");
    Person person = await service.DeletePerson(request.Id);

    //return DeletePersonResponse.Create(person.Id, person.Name);
  }

  //public record DeletePersonRequest(Guid Id) : IRequest<DeletePersonResponse>
  //{
  //  public static DeletePersonRequest Create(Guid id) => new(id);
  //};
  //public record DeletePersonResponse(Guid Id, string Name)
  //{
  //  public static DeletePersonResponse Create(Guid id, string name) => new(id, name);
  //}
}

