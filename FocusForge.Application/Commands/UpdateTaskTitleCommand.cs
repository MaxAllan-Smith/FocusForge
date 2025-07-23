namespace FocusForge.Application.Commands
{
    public class UpdateTaskTitleCommand(Guid taskId, string newTitle)
    {
        public Guid TaskId { get; init; } = taskId;
        public string NewTitle { get; init; } = newTitle;
    }
}
