namespace Projector.Endpoints.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

using Common.Contracts;
using Common.Messaging.Nats.Configuration;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;

public class MessageWorker : BackgroundService
{
  private readonly ChannelReader<ICommand> reader;
  private readonly ICommandQueue commandQueue;

  public MessageWorker(ICommandQueue commandQueue)
  {
    this.commandQueue = commandQueue;
    reader = this.commandQueue.CommandChannel.Reader;
  }

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
  }
}