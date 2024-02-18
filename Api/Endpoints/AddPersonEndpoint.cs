namespace Api.Endpoints;

using System.Threading;
using System.Threading.Tasks;

using Ardalis.ApiEndpoints;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using static Domain.Mediators.AddPersonMediator;

public class AddPersonEndpoint(ILogger<AddPersonEndpoint> logger, ISender sender)
: EndpointBaseAsync
    .WithRequest<AddPersonRequest>
    .WithActionResult<AddPersonResponse>
{
  public override Task<ActionResult<AddPersonResponse>> HandleAsync(AddPersonRequest request, CancellationToken cancellationToken = default)
    => throw new NotImplementedException();
}
