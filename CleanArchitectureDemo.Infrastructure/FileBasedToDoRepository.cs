namespace CleanArchitectureDemo.Infrastructure;

using CleanArchitectureDemo.Domain;
using System.Text.Json;

public class FileBasedToDoRepository
    : ITodoRepository
{
    private readonly string _filePath;

    public FileBasedToDoRepository(string filePath = "todos.json")
    {
        _filePath = filePath;
    }

    public void CreateToDoItem(string title, bool isCompleted = false)
    {
        var todos = ReadTodos();
        todos.Add(new StoredTodoItem(title, isCompleted));
        WriteTodos(todos);
    }

    public IEnumerable<ITodoItem> ListTodos()
    {
        return ReadTodos().Select(todo => new TodoItem(todo.Title)
        {
            IsCompleted = todo.IsCompleted
        });
    }

    public void MarkTodoItemAsCompleted(int index)
    {
        var todos = ReadTodos();

        if (index < 0 || index >= todos.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Invalid todo item index.");
        }

        todos[index] = todos[index] with { IsCompleted = true };
        WriteTodos(todos);
    }

    private List<StoredTodoItem> ReadTodos()
    {
        if (!File.Exists(_filePath))
        {
            return [];
        }

        var content = File.ReadAllText(_filePath);
        return string.IsNullOrWhiteSpace(content)
            ? []
            : JsonSerializer.Deserialize<List<StoredTodoItem>>(content) ?? [];
    }

    private void WriteTodos(List<StoredTodoItem> todos)
    {
        var directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var content = JsonSerializer.Serialize(todos, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(_filePath, content);
    }

    private sealed record StoredTodoItem(string Title, bool IsCompleted);
}
