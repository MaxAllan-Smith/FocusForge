using FocusForge.Application.Commands;
using FocusForge.Domain.Entities;

namespace FocusForge.Application.Handlers
{
    public class CompleteTaskHandler(Dictionary<Guid, TaskItem> store)
    {
        public Task Handle(CompleteTaskCommand command)
        {
            if (!store.TryGetValue(command.Id, out TaskItem? task))
            {
                throw new KeyNotFoundException($"Task with ID {command.Id} not found.");
            }

            task.MarkComplete();
            return Task.CompletedTask;
        }
    }
}
