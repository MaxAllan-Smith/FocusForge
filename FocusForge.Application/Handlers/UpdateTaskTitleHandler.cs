using FocusForge.Application.Commands;
using FocusForge.Application.Interfaces;
using FocusForge.Domain.Entities;

namespace FocusForge.Application.Handlers
{
    public class UpdateTaskTitleHandler(ITaskRepository taskRepository)
    {
        public async Task Handle(UpdateTaskTitleCommand command)
        {
            TaskItem task = await taskRepository.GetByIdAsync(command.TaskId);

            if (string.IsNullOrWhiteSpace(command.NewTitle))
            {
                throw new ArgumentException("Title cannot be empty or null.", nameof(command.NewTitle));
            }

            task.UpdateTitle(command.NewTitle);
        }
    }
}