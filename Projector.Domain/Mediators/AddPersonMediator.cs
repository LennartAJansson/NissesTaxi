﻿namespace Projector.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Domain.Abstract;

using MediatR;

using Microsoft.Extensions.Logging;

using Model;

using static Projector.Domain.Mediators.AddPersonMediator;

public class AddPersonMediator(ILogger<AddPersonMediator> logger, IPersistanceService service)
  : IRequestHandler<AddPersonRequest, AddPersonResponse>
{
  public async Task<AddPersonResponse> Handle(AddPersonRequest request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");
    Person person = new() { Id = Guid.NewGuid(), Namn = request.Name };
    person = await service.AddPerson(person);
    return AddPersonResponse.Create(person.Id, person.Namn);
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
