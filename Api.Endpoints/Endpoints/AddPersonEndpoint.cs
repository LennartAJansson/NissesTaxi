namespace Api.Endpoints.Endpoints;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using static Api.Domain.Mediators.AddPersonMessageMediator;

public class AddPersonEndpoint(ILogger<AddPersonEndpoint> logger, ISender sender)
: EndpointBaseAsync
    .WithRequest<AddPersonRequest>
    .WithActionResult<AddPersonResponse>
{
  [HttpPost("api/People/AddPerson")]
  public override async Task<ActionResult<AddPersonResponse>> HandleAsync(AddPersonRequest request, CancellationToken cancellationToken = default)
  {
    AddPersonResponse? result = await sender.Send(request);
    return result is null ? BadRequest(result) : Ok(result);
  }
}
