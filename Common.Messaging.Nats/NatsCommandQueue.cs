namespace Common.Messaging.Nats;

using System;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;

using Common.Contracts;
using Common.Messaging.Nats.Configuration;
using Common.Messaging.Nats.Serializer;

using Microsoft.Extensions.Logging;

using NATS.Client.Core;
using NATS.Client.JetStream;
using NATS.Client.JetStream.Models;

using static System.Collections.Specialized.BitVector32;

public class NatsCommandQueue : ICommandQueue
{
  public Channel<ICommand> CommandChannel { get; set; }

  private readonly ILogger<NatsCommandQueue> logger;
  private readonly NatsServiceConfig config;
  private readonly ILoggerFactory loggerFactory;

  public bool IsConnected { get; private set; }
  private readonly NatsConnection? connection;
  private readonly NatsJSContext? jetStream;

  public NatsCommandQueue(ILogger<NatsCommandQueue> logger, NatsServiceConfig config, ILoggerFactory loggerFactory)
  {
    CommandChannel = Channel.CreateUnbounded<ICommand>();
    this.logger = logger;
    this.config = config;
    this.loggerFactory = loggerFactory;

    NatsOpts opts = NatsOpts.Default with
    {
      Url = $"nats://{config.Host}:{config.Port}",
      LoggerFactory = loggerFactory
    };
    connection = new NatsConnection(opts);
    jetStream = new NatsJSContext(connection);
    connection.ConnectionOpened += Connection_ConnectionOpened;
    connection.ConnectionDisconnected += Connection_ConnectionDisconnected;

    _ = Task.Run(async () => await jetStream.CreateStreamAsync(new StreamConfig(name: config.Stream, subjects: config.Subjects)));
    _ = Task.Run(Listen);
  }

  private async ValueTask Connection_ConnectionDisconnected(object? sender, NatsEventArgs args) => throw new NotImplementedException();
  private async ValueTask Connection_ConnectionOpened(object? sender, NatsEventArgs args) => throw new NotImplementedException();
  public async Task SendAsync(ICommand command)
  {
    if (jetStream is null)
    {
      //return 0;
      return;
    }

    PubAckResponse ack = await jetStream.PublishAsync<ICommand>(subject: config.Subject, serializer: new CommandEventSerializer(), data: command);
    ack.EnsureSuccess();
    return;
    //return ack.Seq;
  }

  private async Task Listen()
  {
    CancellationTokenSource cts = new();

    Console.CancelKeyPress += (_, e) =>
    {
      e.Cancel = true;
      cts.Cancel();
    };

    if (jetStream is not null)
    {
      INatsJSConsumer consumer = await jetStream.CreateOrUpdateConsumerAsync(config.Stream, new ConsumerConfig(config.Consumer));
      while (!cts.Token.IsCancellationRequested)
      {
        await foreach (NatsJSMsg<ICommand> jsMsg in consumer!.ConsumeAsync<ICommand>(serializer: new CommandEventSerializer(), cancellationToken: cts.Token))
        {
          if (jsMsg.Data is not null)
          {
            await CommandChannel.Writer.WriteAsync(jsMsg.Data);
            await jsMsg.AckAsync();
          }
        }
      }
    }
  }
}
