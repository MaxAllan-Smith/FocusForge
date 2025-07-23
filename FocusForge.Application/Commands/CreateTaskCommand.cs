namespace FocusForge.Application.Commands
{
    public class CreateTaskCommand(string title)
    {
        public string Title { get; } = title;
    }
}
