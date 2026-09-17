namespace CleanArchitectureDemo.Domain;

public class TodoItem
    : ITodoItem
{
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}


