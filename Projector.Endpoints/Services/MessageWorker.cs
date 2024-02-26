namespace Projector.Endpoints.Services;
using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

using Common.Contracts;

using MediatR;

using Microsoft.Extensions.Hosting;


public class MessageWorker(ICommandQueue commandQueue, ISender sender) : BackgroundService
{
  private readonly ChannelReader<ICommand> reader = commandQueue.CommandChannel.Reader;

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await foreach (ICommand command in reader.ReadAllAsync(stoppingToken))
    {
      switch (command)
      {
        case AddPersonCommand:
          break;
        case UpdatePersonCommand:
          break;
        case DeletePersonCommand:
          break;
        default:
          throw new InvalidOperationException("Invalid command type");
      }
      await sender.Send(command, stoppingToken);
    }
  }
}