namespace EndPointComparison.Ardalis;

using System.Threading;
using System.Threading.Tasks;

using global::Ardalis.ApiEndpoints;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Model;

[Tags("Ardalis")]
public class GetPeopleEndpoint
: EndpointBaseAsync
    .WithoutRequest
    .WithResult<Results<Ok<IEnumerable<Person>>, NotFound>>
{
  [HttpGet("api/ardalis/person")]
  public override async Task<Results<Ok<IEnumerable<Person>>, NotFound>> HandleAsync(CancellationToken cancellationToken = default)
  {
    Person[] result = new[] { new Person() { Id = Guid.Parse("2F094106-7177-4776-8050-0533E64F826E"), Name = "Nisse Hult" } };
    await Task.Delay(10);
    return result is not null
      ? TypedResults.Ok(result.AsEnumerable())
      : TypedResults.NotFound();
  }
}