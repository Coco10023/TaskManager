
using TaskManager;

// Skapar ett objekt som hanterar alla uppgifter.
TaskManagerService manager = new TaskManagerService();

// Läser in sparade uppgifter när programmet startar.
manager.LoadTasks();

bool running = true;

while (running)
{
    Console.WriteLine("\n=== TASK MANAGER ===");
    Console.WriteLine("1. Lägg till uppgift");
    Console.WriteLine("2. Visa alla uppgifter");
    Console.WriteLine("3. Markera uppgift som slutförd");
    Console.WriteLine("4. Ta bort uppgift");
    Console.WriteLine("5. Filtrera uppgifter");
    Console.WriteLine("6. Redigera uppgift");
    Console.WriteLine("6. Avsluta");

    Console.Write("\nVälj ett alternativ: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Write("Ange uppgiftens namn: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Ange beskrivning: ");
            string description = Console.ReadLine() ?? "";

            Console.Write("Ange prioritet (Låg/Medel/Hög): ");
            string priority = Console.ReadLine() ?? "Medel";

            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Uppgiften måste ha ett namn.");
            }
            else
            {
                manager.AddTask(title, description, priority);
                manager.SaveTasks();
                Console.WriteLine("Uppgiften har lagts till!");
            }
            break;

        case "2":
            manager.ShowTasks();
            break;

        case "3":
            manager.ShowTasks();

            Console.Write("Ange numret på uppgiften som är klar: ");

            if (int.TryParse(Console.ReadLine(), out int completeIndex))
            {
                if (manager.CompleteTask(completeIndex - 1))
                {
                    manager.SaveTasks();
                    Console.WriteLine("Uppgiften är nu slutförd!");
                }
                else
                {
                    Console.WriteLine("Ogiltigt uppgiftsnummer.");
                }
            }
            else
            {
                Console.WriteLine("Du måste ange ett giltigt nummer.");
            }
            break;

        case "4":
            manager.ShowTasks();

            Console.Write("Ange numret på uppgiften som ska tas bort: ");

            if (int.TryParse(Console.ReadLine(), out int removeIndex))
            {
                if (manager.RemoveTask(removeIndex - 1))
                {
                    manager.SaveTasks();
                    Console.WriteLine("Uppgiften har tagits bort!");
                }
                else
                {
                    Console.WriteLine("Ogiltigt uppgiftsnummer.");
                }
            }
            else
            {
                Console.WriteLine("Du måste ange ett giltigt nummer.");
            }
            break;

        case "5":
            Console.WriteLine("1. Visa slutförda uppgifter");
            Console.WriteLine("2. Visa ej slutförda uppgifter");
            Console.Write("Välj alternativ: ");

            string? filterChoice = Console.ReadLine();

            if (filterChoice == "1")
                manager.FilterTasks(true);
            else if (filterChoice == "2")
                manager.FilterTasks(false);
            else
                Console.WriteLine("Ogiltigt val.");
            break;


        case "6":
            manager.ShowTasks();

            Console.Write("Ange numret på uppgiften du vill redigera: ");

            if (int.TryParse(Console.ReadLine(), out int editIndex))
            {
                Console.Write("Ange ny titel: ");
                string newTitle = Console.ReadLine() ?? "";

                Console.Write("Ange ny beskrivning: ");
                string newDescription = Console.ReadLine() ?? "";

                Console.Write("Ange ny prioritet (Låg/Medel/Hög): ");
                string newPriority = Console.ReadLine() ?? "Medel";

                if (string.IsNullOrWhiteSpace(newTitle))
                {
                    Console.WriteLine("Titeln får inte vara tom.");
                }
                else if (manager.EditTask(editIndex - 1,
                         newTitle, newDescription, newPriority))
                {
                    manager.SaveTasks();
                    Console.WriteLine("Uppgiften har uppdaterats!");
                }
                else
                {
                    Console.WriteLine("Ogiltigt uppgiftsnummer.");
                }
            }
            else
            {
                Console.WriteLine("Du måste ange ett giltigt nummer.");
            }
            break;

        case "7":
            running = false;
            Console.WriteLine("Programmet avslutas.");
            break;

        default:
            Console.WriteLine("Ogiltigt val. Försök igen.");
            break;
    }
}
