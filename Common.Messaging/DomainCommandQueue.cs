namespace Common.Messaging;

using System.Threading.Channels;
using System.Threading.Tasks;

using Common.Contracts;

public class DomainCommandQueue : ICommandQueue
{
  public Channel<ICommand> Command { get; set; }

  public DomainCommandQueue()
  {
    _ = new UnboundedChannelOptions();
    //Options for the channel is used to define the behavior of the channel
    Command = Channel.CreateUnbounded<ICommand>();
  }

  public async Task SendAsync(ICommand command) 
    => await Command.Writer.WriteAsync(command);
}
