namespace CleanArchitectureDemo.Domain;

public interface ITodoItem
{
    public string Titel { get; set; }
    public bool IsCompleted { get; set; }
}
