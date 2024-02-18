namespace Api.Endpoints;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using static Domain.Mediators.GetPersonMediator;

public class GetPersonEndpoint(ILogger<GetPersonEndpoint> logger, ISender sender)
: EndpointBaseAsync
    .WithRequest<GetPersonRequest>
    .WithActionResult<GetPersonResponse>
{
  public override Task<ActionResult<GetPersonResponse>> HandleAsync(GetPersonRequest request, CancellationToken cancellationToken = default)
    => throw new NotImplementedException();
}
