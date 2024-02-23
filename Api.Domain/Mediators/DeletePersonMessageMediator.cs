namespace Api.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Api.Domain.Abstract;

using MediatR;

using Microsoft.Extensions.Logging;

using Model;

using static Api.Domain.Mediators.DeletePersonMessageMediator;

public class DeletePersonMessageMediator(ILogger<DeletePersonMessageMediator> logger, ICommandService service)
  : IRequestHandler<DeletePersonRequest, DeletePersonResponse>
{
  public async Task<DeletePersonResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");
    Person person = await service.DeletePerson(request.Id);
    return DeletePersonResponse.Create(person.Id, person.Namn);
  }

  public record DeletePersonRequest(Guid Id) : IRequest<DeletePersonResponse>
  {
    public static DeletePersonRequest Create(Guid id) => new(id);
  };
  public record DeletePersonResponse(Guid Id, string Name)
  {
    public static DeletePersonResponse Create(Guid id, string name) => new(id, name);
  }
}

