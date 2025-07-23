using FocusForge.Application.Commands;
using FocusForge.Application.Interfaces;

namespace FocusForge.Application.Handlers
{
    public class DeleteTaskHandler(ITaskRepository taskRepository)
    {
        public Task Handle(DeleteTaskCommand command)
        {
            return taskRepository.DeleteAsync(command.TaskId);
        }
    }
}
