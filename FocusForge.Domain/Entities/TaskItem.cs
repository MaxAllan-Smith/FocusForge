namespace FocusForge.Domain.Entities
{
    public class TaskItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; private set; }
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

        public void UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Title cannot be empty or null.", nameof(newTitle));
            }

            Title = newTitle;
        }
    }
}