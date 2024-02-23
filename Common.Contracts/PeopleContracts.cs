namespace Common.Contracts;

public record AddPersonCommand(Guid Id, string Name);
public record UpdatePersonCommand(Guid Id, string Name);
public record DeletePersonCommand(Guid Id);