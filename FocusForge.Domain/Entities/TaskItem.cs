namespace FocusForge.Domain.Entities
{
    public class TaskItem
    {
        public string Title { get; }
        public bool IsCompleted { get; private set; }

        public TaskItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be empty or null.", nameof(title));
            }

            Title = title;
            IsCompleted = false;
        }

        public void MarkComplete()
        {
            IsCompleted = true;
        }
    }
}