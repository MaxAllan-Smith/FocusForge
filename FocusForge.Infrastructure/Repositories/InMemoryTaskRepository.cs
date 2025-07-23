using FocusForge.Application.Interfaces;
using FocusForge.Domain.Entities;
using System.Collections.Concurrent;

namespace FocusForge.Infrastructure.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly ConcurrentDictionary<Guid, TaskItem> _store = new();

        public Task AddAsync(TaskItem task)
        {
            _store[task.TaskId] = task;
            return Task.CompletedTask;
        }

        public Task<TaskItem> GetByIdAsync(Guid id)
        {
            if (_store.TryGetValue(id, out TaskItem? task))
            {
                return Task.FromResult(task);
            }

            throw new KeyNotFoundException($"Task with ID {id} not found.");
        }
    }
}