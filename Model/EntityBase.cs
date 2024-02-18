namespace Model;

public abstract class EntityBase
{
  public Guid Id { get; set; }
  //Här kan man fylla i allt som ska finnas i alla entiteter
  //t.ex. CreatedAt, UpdatedAt, DeletedAt

}
