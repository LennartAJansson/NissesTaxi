namespace Api.Endpoints.Endpoints;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using static Domain.Mediators.GetPeopleMediator;
using static Domain.Mediators.GetPersonMediator;

public class GetPeopleEndpoint(ILogger<GetPeopleEndpoint> logger, ISender sender)
: EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<IEnumerable<GetPersonResponse>>
{
  [HttpGet("api/People/GetPeople")]
  public override async Task<ActionResult<IEnumerable<GetPersonResponse>>> HandleAsync(CancellationToken cancellationToken = default)
  {
    IEnumerable<GetPersonResponse> result = await sender.Send(GetPeopleRequest.Create(), cancellationToken);
    return Ok(result);
  }
}