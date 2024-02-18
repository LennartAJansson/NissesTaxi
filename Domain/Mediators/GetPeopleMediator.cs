namespace Domain.Mediators;

using System.Threading;
using System.Threading.Tasks;

using Domain.Abstract;

using MediatR;

using Microsoft.Extensions.Logging;

using Model;

using static Domain.Mediators.GetPeopleMediator;
using static Domain.Mediators.GetPersonMediator;

public class GetPeopleMediator(ILogger<GetPeopleMediator> logger, IPersistanceService service)
  : IRequestHandler<GetPeopleRequest, IEnumerable<GetPersonResponse>>
{
  public async Task<IEnumerable<GetPersonResponse>> Handle(GetPeopleRequest request, CancellationToken cancellationToken)
  {
    logger.LogTrace("Inside Mediator");
    IEnumerable<Person> people = await service.GetPeople();
    return people.Select(person => GetPersonResponse.Create(person.Id, person.Name));
  }
  public record GetPeopleRequest() : IRequest<IEnumerable<GetPersonResponse>>;
  //public record GetPersonResponse();
}

