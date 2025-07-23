using FocusForge.Application.Commands;
using FocusForge.Domain.Entities;

namespace FocusForge.Application.Handlers
{
    public class UpdateTaskTitleHandler(Dictionary<Guid, TaskItem> store)
    {
        public Task Handle(UpdateTaskTitleCommand command)
        {
            if (!store.TryGetValue(command.TaskId, out TaskItem? task))
            {
                throw new KeyNotFoundException($"Title with ID {command.TaskId} not found.");
            }

            if (string.IsNullOrWhiteSpace(command.NewTitle))
            {
                throw new ArgumentException("Title cannot be empty or null.", nameof(command.NewTitle));
            }

            task.UpdateTitle(command.NewTitle);
            return Task.CompletedTask;
        }
    }
}
