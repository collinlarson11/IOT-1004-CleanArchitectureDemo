using CleanArchitectureDemo.Application;

var repository = new TodoRepository();
var isRunning = true;

while (isRunning)
{
	Console.WriteLine();
	Console.WriteLine("Todo Menu");
	Console.WriteLine("1. Add todo item");
	Console.WriteLine("2. List todo items");
	Console.WriteLine("3. Mark todo item as complete");
	Console.WriteLine("4. Exit");
	Console.Write("Choose an option: ");

	switch (Console.ReadLine())
	{
		case "1":
			Console.Write("Enter a todo item: ");
			var title = Console.ReadLine();

			if (string.IsNullOrWhiteSpace(title))
			{
				Console.WriteLine("A todo item cannot be empty.");
				break;
			}

			repository.CreateToDoItem(title);
			Console.WriteLine("Todo item added.");
			break;

		case "2":
			var todos = repository.ListTodos().ToList();

			if (todos.Count == 0)
			{
				Console.WriteLine("No todo items found.");
				break;
			}

			Console.WriteLine("Todo Items:");
			for (var index = 0; index < todos.Count; index++)
			{
				var todo = todos[index];
				Console.WriteLine($"{index + 1}. [{(todo.IsCompleted ? "x" : " ")}] {todo.Title}");
			}

			break;

		case "3":
			var todosToComplete = repository.ListTodos().ToList();

			if (todosToComplete.Count == 0)
			{
				Console.WriteLine("No todo items found.");
				break;
			}

			Console.WriteLine("Enter the number of the todo item to complete:");
			for (var index = 0; index < todosToComplete.Count; index++)
			{
				var todo = todosToComplete[index];
				Console.WriteLine($"{index + 1}. [{(todo.IsCompleted ? "x" : " ")}] {todo.Title}");
			}

			Console.Write("Todo item number: ");
			if (!int.TryParse(Console.ReadLine(), out var itemNumber) ||
				itemNumber < 1 || itemNumber > todosToComplete.Count)
			{
				Console.WriteLine("Please enter a valid todo item number.");
				break;
			}

			repository.MarkTodoItemAsCompleted(itemNumber - 1);
			Console.WriteLine("Todo item marked as complete.");
			break;

		case "4":
			isRunning = false;
			Console.WriteLine("Goodbye.");
			break;

		default:
			Console.WriteLine("Please choose 1, 2, 3, or 4.");
			break;
	}
}