using FocusForge.Application.Commands;
using FocusForge.Application.Handlers;
using FocusForge.Domain.Entities;
using FocusForge.Infrastructure.Repositories;

namespace FocusForge.Tests.UnitTests.Application.Tasks
{
    [TestFixture]
    public class DeleteTaskHandlerTests
    {
        [Test]
        public async Task CanDeleteTask()
        {
            InMemoryTaskRepository repo = new();
            TaskItem task = new("Delete me");
            await repo.AddAsync(task);

            DeleteTaskHandler handler = new(repo);
            DeleteTaskCommand command = new(task.TaskId);

            await handler.Handle(command);

            Assert.ThrowsAsync<KeyNotFoundException>(() => repo.GetByIdAsync(task.TaskId));
        }

        [Test]
        public void ThrowsIfTaskNotFound()
        {
            InMemoryTaskRepository repo = new();
            DeleteTaskHandler handler = new(repo);
            DeleteTaskCommand command = new(Guid.NewGuid());

            KeyNotFoundException? ex = Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command));
            Assert.That(ex.Message, Does.Contain("not found"));
        }
    }
}
