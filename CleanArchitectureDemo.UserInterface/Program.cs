using CleanArchitectureDemo.Application;
using CleanArchitectureDemo.Domain;

Console.WriteLine("Hello, World!");

var todo = new TodoItem("Hello");

Console.WriteLine(todo.Title);

var repo = new TodoRepository();

repo.CreateToDoItem("Hello 2");

var todoList = repo.ListTodos();

Console.WriteLine(todoList.First().Title);