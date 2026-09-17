using CleanArchitectureDemo.Domain;

namespace CleanArchitectureDemo.Application;

public class TodoRepository : ITodoRepository
{
    public void CreateToDoItem(string title, bool IsCompleted = false)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> ListTodos()
    {
        throw new NotImplementedException();
    }
}
