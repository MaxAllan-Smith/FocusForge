using FocusForge.Application.Commands;
using FocusForge.Application.Interfaces.MediatR;
using FocusForge.Domain.Entities;

namespace FocusForge.Application.Handlers
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskItem>
    {
        public Task<TaskItem> Handle(CreateTaskCommand request)
        {
            TaskItem task = new(request.Title);
            return Task.FromResult(task);
        }
    }
}
