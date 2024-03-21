namespace Common.Messaging;

using System.Threading.Channels;
using System.Threading.Tasks;

using Common.Contracts;

public class InternalCommandQueue : ICommandQueue
{
  public Channel<ICommand> CommandChannel { get; set; }

  public InternalCommandQueue()
  {
    //_ = new BoundedChannelOptions(100);
    //_ = new UnboundedChannelOptions();
    //Options for the channel is used to define the behavior of the channel
    //CommandChannel = Channel.CreateBounded<ICommand>();
    CommandChannel = Channel.CreateUnbounded<ICommand>();
  }

  public async Task SendAsync(ICommand command)
    => await CommandChannel.Writer.WriteAsync(command);
}
