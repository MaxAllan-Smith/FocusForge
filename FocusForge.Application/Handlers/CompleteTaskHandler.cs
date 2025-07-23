using FocusForge.Application.Commands;
using FocusForge.Application.Interfaces;
using FocusForge.Domain.Entities;

namespace FocusForge.Application.Handlers
{
    public class CompleteTaskHandler(ITaskRepository repository)
    {
        public async Task Handle(CompleteTaskCommand command)
        {
            TaskItem task = await repository.GetByIdAsync(command.TaskId);
            task.MarkComplete();
        }
    }
}
