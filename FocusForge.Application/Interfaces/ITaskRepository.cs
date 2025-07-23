using FocusForge.Domain.Entities;

namespace FocusForge.Application.Interfaces
{
    public interface ITaskRepository
    {
        Task AddAsync(TaskItem task);
        Task<TaskItem> GetByIdAsync(Guid id);
    }
}
