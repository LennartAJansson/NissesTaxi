namespace Api.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Common.Contracts;

using Domain.Abstract;

using MediatR;

using Microsoft.Extensions.Logging;

using static Api.Domain.Mediators.UpdatePersonMessageMediator;

public class UpdatePersonMessageMediator(ILogger<UpdatePersonMessageMediator> logger, ICommandService service)
  : IRequestHandler<UpdatePersonRequest, UpdatePersonResponse>
{
  public async Task<UpdatePersonResponse> Handle(UpdatePersonRequest request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");

    UpdatePersonCommand command = UpdatePersonCommand.Create(request.Id, request.Name);
    await service.UpdatePerson(command);

    return UpdatePersonResponse.Create(command.Id, command.Name);
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

