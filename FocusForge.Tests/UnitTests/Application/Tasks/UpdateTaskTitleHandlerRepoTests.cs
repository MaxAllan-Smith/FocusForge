using FocusForge.Application.Commands;
using FocusForge.Application.Handlers;
using FocusForge.Domain.Entities;
using FocusForge.Infrastructure.Repositories;

namespace FocusForge.Tests.UnitTests.Application.Tasks
{
    [TestFixture]
    public class UpdateTaskTitleHandlerRepoTests
    {
        [Test]
        public async Task CanUpdateTitle_UsingRepository()
        {
            InMemoryTaskRepository repo = new();
            TaskItem task = new("Original");
            await repo.AddAsync(task);

            UpdateTaskTitleHandler handler = new UpdateTaskTitleHandler(repo);
            UpdateTaskTitleCommand command = new(task.TaskId, "Updated");

            await handler.Handle(command);

            TaskItem updated = await repo.GetByIdAsync(task.TaskId);
            Assert.That(updated.Title, Is.EqualTo("Updated"));
        }

        [Test]
        public void ThrowsIfTaskNotFound_UsingRepository()
        {
            InMemoryTaskRepository repo = new();
            UpdateTaskTitleHandler handler = new UpdateTaskTitleHandler(repo);

            UpdateTaskTitleCommand command = new(Guid.NewGuid(), "Any");

            KeyNotFoundException? ex = Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command));
            Assert.That(ex.Message, Does.Contain("not found"));
        }

        [Test]
        public async Task ThrowsIfTitleInvalid_UsingRepository()
        {
            InMemoryTaskRepository repo = new();
            TaskItem task = new("Valid");
            await repo.AddAsync(task);

            UpdateTaskTitleHandler handler = new UpdateTaskTitleHandler(repo);
            UpdateTaskTitleCommand command = new(task.TaskId, "   ");

            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command));
            Assert.That(ex.Message, Does.Contain("Title"));
        }
    }
}
