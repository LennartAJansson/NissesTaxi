//namespace Api.Endpoints;

//using System.Threading;
//using System.Threading.Tasks;

//using Ardalis.ApiEndpoints;

//using MediatR;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;

//using static Domain.Mediators.UpdatePersonMediator;

//public class UpdatePersonEndpoint(ILogger<UpdatePersonEndpoint> logger, ISender sender)
//: EndpointBaseAsync
//    .WithRequest<UpdatePersonRequest>
//    .WithActionResult<UpdatePersonResponse>
//{
//  public override Task<ActionResult<UpdatePersonResponse>> HandleAsync(UpdatePersonRequest request, CancellationToken cancellationToken = default)
//    => throw new NotImplementedException();
//}
