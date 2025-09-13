namespace ProjectManagerAPI.Models;

public enum TaskStatus
{
    Todo,
    InProgress,
    Completed,
    Cancelled
}

public class ProjectTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; private set; }
    public User AssignedTo { get; set; }
    public DateTime DueDate { get; set; }

    public ProjectTask(int id, string title, string description, DateTime dueDate)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        Status = TaskStatus.Todo;
    }

    public void AssignUser(User user)
    {
        AssignedTo = user;
        Console.WriteLine($"Tarefa '{Title}' atribuída a {user.Username}.");
    }

    public void CompletedTask()
    {
         if (Status == TaskStatus.Completed || Status == TaskStatus.Cancelled)
        {
            Console.WriteLine($"Atenção: A tarefa '{Title}' já está finalizada ou cancelada.");
            return;
        }
        Status = TaskStatus.Completed;
        Console.WriteLine($"Tarefa '{Title}' concluída!");
    }
}