using FocusForge.Application.Interfaces.MediatR;
using FocusForge.Domain.Entities;

namespace FocusForge.Application.Commands
{
    public class CreateTaskCommand(string title) : IRequest<TaskItem>
    {
        public string Title { get; } = title;
    }
}
