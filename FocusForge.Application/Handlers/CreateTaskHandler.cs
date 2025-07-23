using FocusForge.Application.Commands;
using FocusForge.Domain.Entities;

namespace FocusForge.Application.Handlers
{
    public class CreateTaskHandler
    {
        public Task<TaskItem> Handle(CreateTaskCommand command)
        {
            TaskItem task = new TaskItem(command.Title);
            return Task.FromResult(task);
        }
    }
}
