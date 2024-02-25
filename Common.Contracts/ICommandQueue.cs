﻿namespace Common.Contracts;

using System.Threading.Channels;

public interface ICommandQueue
{
  Channel<ICommand> Command { get; }
  Task SendAsync(ICommand command);
}
