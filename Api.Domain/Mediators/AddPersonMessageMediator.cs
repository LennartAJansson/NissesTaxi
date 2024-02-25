namespace Api.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Common.Contracts;

using Domain.Abstract;

using MediatR;

using Microsoft.Extensions.Logging;

using static Api.Domain.Mediators.AddPersonMessageMediator;

public class AddPersonMessageMediator(ILogger<AddPersonMessageMediator> logger, ICommandService service)
  : IRequestHandler<AddPersonRequest, AddPersonResponse>
{
  public async Task<AddPersonResponse> Handle(AddPersonRequest request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");

    AddPersonCommand command = AddPersonCommand.Create(Guid.NewGuid(), request.Name);
    await service.AddPerson(command);

    return AddPersonResponse.Create(command.Id, command.Name);
  }

  public record AddPersonRequest(string Name) : IRequest<AddPersonResponse>
  {
    public static AddPersonRequest Create(string name) => new(name);
  };
  public record AddPersonResponse(Guid Id, string Name)
  {
    public static AddPersonResponse Create(Guid id, string name) => new(id, name);
  };
}

