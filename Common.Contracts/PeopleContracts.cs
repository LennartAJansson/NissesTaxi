namespace Common.Contracts;

public class CommandEvent
{
  public Guid Id { get; set; }
  public DateTimeOffset Date { get; set; }
  public required ICommand Command { get; set; }
}

public record AddPersonCommand(Guid Id, string Name) : ICommand
{
  public static AddPersonCommand Create(Guid id, string name)
    => new AddPersonCommand(id, name);
};
public record UpdatePersonCommand(Guid Id, string Name) : ICommand
{
  public static UpdatePersonCommand Create(Guid id, string name)
    => new UpdatePersonCommand(id, name);
};
public record DeletePersonCommand(Guid Id) : ICommand
{
  public static DeletePersonCommand Create(Guid id)
    => new DeletePersonCommand(id);
};