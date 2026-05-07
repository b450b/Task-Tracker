using System.Text.Json;

namespace TaskTracker
{
    public class Program
    {
        static string filePath = "tasks.json";
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Использование: task-cli [команда] [аргументы]");
                Console.WriteLine("Команды: add, list, update, delete, mark-in-progress, mark-done");
                return;
            }

            string command = args[0];
            try
            {
                switch (command)
                {
                    case "add":
                        AddTask(args[1]);
                        break;
                    case "list":
                        ListTasks(args.Length > 1 ? args[1] : "all");
                        break;
                    case "update":
                        UpdateTask(int.Parse(args[1]), args[2]);
                        break;
                    case "delete":
                        DeleteTask(int.Parse(args[1]));
                        break;
                    case "mark-in-progress":
                        ChangeStatus(int.Parse(args[1]), "in-progress");
                        break;
                    case "mark-done":
                        ChangeStatus(int.Parse(args[1]), "done");
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: Возможно, вы ввели неверные аргументы. ({ex.Message})");
            }
        }


        static void AddTask(string description)
        {
            List<Task> tasks = LoadTasks();
            int newId = tasks.Count > 0 ? tasks[tasks.Count - 1].Id + 1 : 1;

            tasks.Add(new Task(newId, description)
            {
                Status = "todo",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });

            SaveTasks(tasks);
            Console.WriteLine($"Задача добавлена успешно (ID: {newId})");
        }

        static void ListTasks(string filter)
        {
            List<Task> tasks = LoadTasks();
            Console.WriteLine($"--- Список задач ({filter}) ---");

            foreach (var task in tasks)
            {
                if (filter == "all" || task.Status == filter)
                {
                    Console.WriteLine(task.ToString());
                }
            }
        }

        static void UpdateTask(int id, string newDesc)
        {
            List<Task> tasks = LoadTasks();
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.Description = newDesc;
                task.UpdatedAt = DateTime.Now;
                SaveTasks(tasks);
                Console.WriteLine("Задача обновлена.");
            }
        }

        static void DeleteTask(int id)
        {
            List<Task> tasks = LoadTasks();
            int removed = tasks.RemoveAll(t => t.Id == id);
            if (removed > 0)
            {
                SaveTasks(tasks);
                Console.WriteLine("Задача удалена.");
            }
        }

        static void ChangeStatus(int id, string newStatus)
        {
            List<Task> tasks = LoadTasks();
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.Status = newStatus;
                task.UpdatedAt = DateTime.Now;
                SaveTasks(tasks);
                Console.WriteLine($"Статус изменен на {newStatus}");
            }
        }


        static List<Task> LoadTasks()
            {
                if (!File.Exists(filePath)) return new List<Task>();
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Task>>(json) ?? new List<Task>();
            }

            static void SaveTasks(List<Task> tasks)
            {
                string json = JsonSerializer.Serialize(tasks);
                File.WriteAllText(filePath, json);
            }
        }
    }
