namespace Common.Messaging.Nats.Serializer;

using System.Buffers;
using System.Linq;
using System.Text.Json;

using Common.Contracts;

using NATS.Client.Core;

public class CommandEventSerializer : INatsSerializer<ICommand>
{
  public ICommand? Deserialize(in ReadOnlySequence<byte> buffer)
  {
    byte[] buf = buffer.ToArray();
    ICommand? action = JsonSerializer.Deserialize<ICommand>(buf);
    return action;
  }

  public void Serialize(IBufferWriter<byte> bufferWriter, ICommand value)
  {
    byte[] buf = JsonSerializer.SerializeToUtf8Bytes(value);
    bufferWriter.Write(buf);
  }
}
