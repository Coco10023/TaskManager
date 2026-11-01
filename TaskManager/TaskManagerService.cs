
using System.Text.Json;

namespace TaskManager
{
    public class TaskManagerService
    {
        // Lista som innehåller alla uppgifter.
        private List<TaskItem> tasks = new List<TaskItem>();

        // Filen där uppgifterna sparas.
        private readonly string filePath = "tasks.json";

        // Lägger till en ny uppgift.
        public void AddTask(string title, string description, string priority)
        {
            TaskItem task = new TaskItem
            {
                Title = title,
                Description = description,
                Priority = priority
            };

            tasks.Add(task);
        }

        // Visar alla registrerade uppgifter.
        public void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Det finns inga uppgifter.");
                return;
            }

            for (int i = 0; i < tasks.Count; i++)
            {
                TaskItem task = tasks[i];
                string status = task.IsCompleted ? "Klar" : "Ej klar";

                Console.WriteLine(
                    $"{i + 1}. {task.Title} - {task.Description}");

                Console.WriteLine(
                    $"   Prioritet: {task.Priority}, Status: {status}");
            }
        }

        // Markerar en uppgift som slutförd.
        public bool CompleteTask(int index)
        {
            if (index < 0 || index >= tasks.Count)
            {
                return false;
            }

            tasks[index].IsCompleted = true;
            return true;
        }

        // Tar bort en uppgift.
        public bool RemoveTask(int index)
        {
            if (index < 0 || index >= tasks.Count)
            {
                return false;
            }

            tasks.RemoveAt(index);
            return true;
        }


        // Redigerar en befintlig uppgift.
        public bool EditTask(int index, string title,
                             string description, string priority)
        {
            // Kontrollerar att uppgiften finns.
            if (index < 0 || index >= tasks.Count)
            {
                return false;
            }

            // Uppdaterar uppgiftens information.
            tasks[index].Title = title;
            tasks[index].Description = description;
            tasks[index].Priority = priority;

            return true;
        }


        // Filtrerar uppgifter efter status.
        public void FilterTasks(bool completed)
        {
            bool found = false;

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].IsCompleted == completed)
                {
                    string status = completed ? "Klar" : "Ej klar";

                    Console.WriteLine(
                        $"{i + 1}. {tasks[i].Title} - {status}");

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Inga matchande uppgifter hittades.");
            }
        }

        // Sparar alla uppgifter till JSON.
        public void SaveTasks()
        {
            try
            {
                string json = JsonSerializer.Serialize(
                    tasks,
                    new JsonSerializerOptions { WriteIndented = true }
                );

                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kunde inte spara uppgifterna: " + ex.Message);
            }
        }

        // Läser in uppgifter från JSON.
        public void LoadTasks()
        {
            if (!File.Exists(filePath))
            {
                return;
            }

            try
            {
                string json = File.ReadAllText(filePath);

                tasks = JsonSerializer.Deserialize<List<TaskItem>>(json)
                        ?? new List<TaskItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kunde inte läsa in uppgifterna: " + ex.Message);
            }
        }
    }
}
