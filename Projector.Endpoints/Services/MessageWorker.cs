namespace Projector.Endpoints.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

using Common.Contracts;

using MediatR;

using Microsoft.Extensions.Hosting;


public class MessageWorker(ICommandQueue commandQueue, ISender sender) : BackgroundService
{
  private ChannelReader<ICommand> reader = commandQueue.Command.Reader;

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    await foreach (ICommand command in reader.ReadAllAsync(stoppingToken))
    {
      await sender.Send(command, stoppingToken);
    }
  }
}