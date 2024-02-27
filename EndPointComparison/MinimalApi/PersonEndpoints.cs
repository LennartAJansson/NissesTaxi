namespace EndPointComparison.MinimalApi;

using Microsoft.AspNetCore.Http.HttpResults;

using Model;

public static class PersonEndpoints
{
  public static void MapPersonEndpoints(this IEndpointRouteBuilder routes)
  {
    RouteGroupBuilder group = routes.MapGroup("/api/minimal/person").WithTags("Minimal");

    _ = group.MapGet("/", async Task<Results<Ok<IEnumerable<Person>>, NotFound>> () =>
    {
      Person[] result = new[] { new Person() { Id = Guid.Parse("2F094106-7177-4776-8050-0533E64F826E"), Name = "Nisse Hult" } };
      await Task.Delay(10);
      return result is not null
        ? TypedResults.Ok(result.AsEnumerable())
        : TypedResults.NotFound();
    })
    .WithName("GetPeopleEndpoint")
    .WithOpenApi();

    _ = group.MapGet("/{id}", async Task<Results<Ok<Person>, NotFound>> (Guid id) =>
    {
      Person result = new() { Id = id, Name = "Nisse Hult" };
      await Task.Delay(10);
      return result is not null
        ? TypedResults.Ok(result)
        : TypedResults.NotFound();
    })
    .WithName("GetPersonEndpoint")
    .WithOpenApi();

    _ = group.MapPost("/", async Task<Results<Created<Person>, BadRequest>> (Person request) =>
    {
      await Task.Delay(10);
      return request is not null
        ? TypedResults.Created($"/api/minimal/person/{request.Id}", request)
        : TypedResults.BadRequest();
    })
    .WithName("AddPersonEndpoint")
    .WithOpenApi();
  }
}
