namespace FocusForge.Application.Commands
{
    public class DeleteTaskCommand(Guid taskId)
    {
        public Guid TaskId { get; init; } = taskId;
    }
}
