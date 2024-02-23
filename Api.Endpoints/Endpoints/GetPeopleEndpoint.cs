//namespace Api.Endpoints;

//using System.Threading;
//using System.Threading.Tasks;

//using Ardalis.ApiEndpoints;

//using MediatR;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//using static Domain.Mediators.GetPeopleMediator;
//using static Domain.Mediators.GetPersonMediator;

//public class GetPeopleEndpoint(ILogger<GetPeopleEndpoint> logger, ISender sender)
//: EndpointBaseAsync
//    .WithRequest<GetPeopleRequest>
//    .WithActionResult<IEnumerable<GetPersonResponse>>
//{
//  public override Task<ActionResult<IEnumerable<GetPersonResponse>>> HandleAsync(GetPeopleRequest request, CancellationToken cancellationToken = default)
//    => throw new NotImplementedException();
//}