namespace Api.Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Api.Domain.Abstract;

using MediatR;

using Microsoft.Extensions.Logging;

using Model;

using static Api.Domain.Mediators.GetPersonMediator;

public class GetPersonMediator(ILogger<GetPersonMediator> logger, IQueryService service)
  : IRequestHandler<GetPersonRequest, GetPersonResponse>
{
  public async Task<GetPersonResponse> Handle(GetPersonRequest request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");
    Person person = await service.GetPerson(request.Id);
    return GetPersonResponse.Create(person.Id, person.Name);
  }

  public record GetPersonRequest(Guid Id) : IRequest<GetPersonResponse>
  {
    public static GetPersonRequest Create(Guid id) => new(id);
  };
  public record GetPersonResponse(Guid Id, string Name)
  {
    public static GetPersonResponse Create(Guid id, string name) => new(id, name);
  };
}

