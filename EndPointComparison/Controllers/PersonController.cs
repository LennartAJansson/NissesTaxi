// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EndPointComparison.Controllers;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using Model;

[Route("api/controller/[controller]")]
[Tags("Controller")]
[ApiController]
public class PersonController : ControllerBase
{
  [HttpGet]
  public async Task<Results<Ok<IEnumerable<Person>>, NotFound>> GetPeopleEndpoint()
  {
    Person[] result = new[] { new Person() { Id = Guid.Parse("2F094106-7177-4776-8050-0533E64F826E"), Name = "Nisse Hult" } };
    await Task.Delay(10);
    return result is not null
      ? TypedResults.Ok(result.AsEnumerable())
      : TypedResults.NotFound();
  }

  [HttpGet("{id}")]
  public async Task<Results<Ok<Person>, NotFound>> GetPersonEndpoint(Guid id)
  {
    Person result = new() { Id = id, Name = "Nisse Hult" };
    await Task.Delay(10);
    return result is not null
      ? TypedResults.Ok(result)
      : TypedResults.NotFound();
  }

  [HttpPost]
  public async Task<Results<Created<Person>, BadRequest>> AddPersonEndpoint([FromBody] Person request)
  {
    await Task.Delay(10);
    return request is not null
      ? TypedResults.Created($"/api/controller/person/{request.Id}", request)
      : TypedResults.BadRequest();
  }
}
