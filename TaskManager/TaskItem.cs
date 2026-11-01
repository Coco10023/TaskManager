
namespace TaskManager
{
    public class TaskItem
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";

        public string Priority { get; set; } = "Medel";
        public bool IsCompleted { get; set; } = false;
    }
}
