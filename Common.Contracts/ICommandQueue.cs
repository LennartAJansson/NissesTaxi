namespace Common.Contracts;

using System.Threading.Channels;

public interface ICommandQueue
{
  Channel<ICommand> CommandChannel { get; }
  Task SendAsync(ICommand command);
}
