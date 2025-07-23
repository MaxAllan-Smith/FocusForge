using FocusForge.Application.Commands;
using FocusForge.Application.Handlers;
using FocusForge.Domain.Entities;
using FocusForge.Infrastructure.Repositories;

namespace FocusForge.Tests.UnitTests.Application.Tasks
{
    [TestFixture]
    public class CompleteTaskHandlerRepoTests
    {
        [Test]
        public async Task CanMarkTaskAsComplete_UsingRepository()
        {
            InMemoryTaskRepository repo = new();
            TaskItem task = new TaskItem("Finish test");
            await repo.AddAsync(task);

            CompleteTaskHandler handler = new CompleteTaskHandler(repo);
            CompleteTaskCommand command = new CompleteTaskCommand(task.TaskId);

            await handler.Handle(command);

            var updated = await repo.GetByIdAsync(task.TaskId);
            Assert.That(updated.IsCompleted, Is.True);
        }

        [Test]
        public void ThrowsIfTaskNotFound_UsingRepository()
        {
            InMemoryTaskRepository repo = new();
            CompleteTaskHandler handler = new CompleteTaskHandler(repo);

            CompleteTaskCommand command = new CompleteTaskCommand(Guid.NewGuid());

            KeyNotFoundException? ex = Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command));
            Assert.That(ex.Message, Does.Contain("not found"));
        }
    }
}
