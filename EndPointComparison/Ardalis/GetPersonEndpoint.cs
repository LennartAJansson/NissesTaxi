namespace EndPointComparison.Ardalis;

using System.Threading;
using System.Threading.Tasks;

using global::Ardalis.ApiEndpoints;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Model;

[Tags("Ardalis")]
public class GetPersonEndpoint
: EndpointBaseAsync
    .WithRequest<Guid>
    .WithResult<Results<Ok<Person>, NotFound>>
{
  [HttpGet("api/ardalis/person/{id}")]
  public override async Task<Results<Ok<Person>, NotFound>> HandleAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
  {
    Person result = new() { Id = id, Name = "Nisse Hult" };
    await Task.Delay(10);
    return result is not null
      ? TypedResults.Ok(result)
      : TypedResults.NotFound();
  }
}
