using FocusForge.Application.Commands;
using FocusForge.Domain.Entities;

namespace FocusForge.Application.Handlers
{
    public class CompleteTaskHandler(Dictionary<Guid, TaskItem> store)
    {
        public Task Handle(CompleteTaskCommand command)
        {
            if (!store.TryGetValue(command.TaskId, out TaskItem? task))
            {
                throw new KeyNotFoundException($"Task with ID {command.TaskId} not found.");
            }

            task.MarkComplete();
            return Task.CompletedTask;
        }
    }
}
