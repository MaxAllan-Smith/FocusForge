using FocusForge.Application.Commands;
using FocusForge.Application.Handlers;
using FocusForge.Domain.Entities;
using FocusForge.Infrastructure.Repositories;

namespace FocusForge.Tests.UnitTests.Application.Tasks
{
    [TestFixture]
    public class CompleteTaskHandlerTests
    {
        [Test]
        public async Task CanMarkTaskAsComplete()
        {
            InMemoryTaskRepository repo = new();
            TaskItem task = new("Write more tests");
            await repo.AddAsync(task);

            CompleteTaskHandler handler = new(repo);
            CompleteTaskCommand command = new(task.TaskId);

            await handler.Handle(command);

            Assert.That(task.IsCompleted, Is.True);
        }

        [Test]
        public void ThrowsIfTaskNotFound()
        {
            InMemoryTaskRepository repo = new();
            CompleteTaskHandler handler = new(repo);
            CompleteTaskCommand command = new(Guid.NewGuid());

            KeyNotFoundException? ex = Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command));
            Assert.That(ex.Message, Does.Contain("not found"));
        }
    }
}
