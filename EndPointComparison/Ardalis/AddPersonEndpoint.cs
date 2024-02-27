namespace EndPointComparison.Ardalis;

using System.Threading;
using System.Threading.Tasks;

using global::Ardalis.ApiEndpoints;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Model;

[Tags("Ardalis")]
public class AddPersonEndpoint
: EndpointBaseAsync
    .WithRequest<Person>
    .WithResult<Results<Created<Person>, BadRequest>>
{
  [HttpPost("api/ardalis/person")]
  public override async Task<Results<Created<Person>, BadRequest>> HandleAsync(Person request, CancellationToken cancellationToken = default)
  {
    await Task.Delay(10);
    return request is not null
      ? TypedResults.Created($"/api/ardalis/person/{request.Id}", request)
      : TypedResults.BadRequest();
  }
}
