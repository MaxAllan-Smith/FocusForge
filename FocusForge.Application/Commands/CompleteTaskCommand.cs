namespace FocusForge.Application.Commands
{
    public class CompleteTaskCommand(Guid id)
    {
        public Guid TaskId { get; } = id;
    }
}
