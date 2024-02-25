namespace Api.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Api.Domain.Abstract;

using Common.Contracts;

using MediatR;

using Microsoft.Extensions.Logging;

using static Api.Domain.Mediators.DeletePersonMessageMediator;

public class DeletePersonMessageMediator(ILogger<DeletePersonMessageMediator> logger, ICommandService service)
  : IRequestHandler<DeletePersonRequest, DeletePersonResponse>
{
  public async Task<DeletePersonResponse> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");

    DeletePersonCommand command = DeletePersonCommand.Create(request.Id);
    await service.DeletePerson(command);

    return DeletePersonResponse.Create(command.Id);
  }

  public record DeletePersonRequest(Guid Id) : IRequest<DeletePersonResponse>
  {
    public static DeletePersonRequest Create(Guid id) => new(id);
  };
  public record DeletePersonResponse(Guid Id)
  {
    public static DeletePersonResponse Create(Guid id) => new(id);
  }
}

