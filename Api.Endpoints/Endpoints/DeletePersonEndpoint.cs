//namespace Api.Endpoints;

//using System.Threading;
//using System.Threading.Tasks;

//using Ardalis.ApiEndpoints;

//using MediatR;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//using static Domain.Mediators.DeletePersonMediator;

//public class DeletePersonEndpoint(ILogger<DeletePersonEndpoint> logger, ISender sender)
//: EndpointBaseAsync
//    .WithRequest<DeletePersonRequest>
//    .WithActionResult<DeletePersonResponse>
//{
//  public override Task<ActionResult<DeletePersonResponse>> HandleAsync(DeletePersonRequest request, CancellationToken cancellationToken = default)
//    => throw new NotImplementedException();
//}
