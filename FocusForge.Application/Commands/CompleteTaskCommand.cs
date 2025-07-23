namespace FocusForge.Application.Commands
{
    public class CompleteTaskCommand(Guid id)
    {
        public Guid Id { get; } = id;
    }
}
