using FocusForge.Application.Commands;
using FocusForge.Application.Handlers;
using FocusForge.Domain.Entities;

namespace FocusForge.Tests.UnitTests.Application.Tasks
{
    [TestFixture]
    public class UpdateTaskTitleHandlerTests
    {
        [Test]
        public async Task CanUpdateTaskTitle()
        {
            TaskItem task = new TaskItem("Old title");
            Dictionary<Guid, TaskItem> store = new Dictionary<Guid, TaskItem>
            {
                { task.TaskId, task }
            };

            UpdateTaskTitleHandler handler = new UpdateTaskTitleHandler(store);
            UpdateTaskTitleCommand command = new UpdateTaskTitleCommand(task.TaskId, "New title");

            await handler.Handle(command);

            Assert.That(task.Title, Is.EqualTo("New title"));
        }

        [Test]
        public void ThrowsIfTaskNotFound()
        {
            Dictionary<Guid, TaskItem> store = new Dictionary<Guid, TaskItem>();
            UpdateTaskTitleHandler handler = new UpdateTaskTitleHandler(store);
            UpdateTaskTitleCommand command = new UpdateTaskTitleCommand(Guid.NewGuid(), "Any title");

            KeyNotFoundException? ex = Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command));
            Assert.That(ex.Message, Does.Contain("not found"));
        }

        [Test]
        public void ThrowsIfNewTitleIsInvalid()
        {
            TaskItem task = new TaskItem("Initial title");
            Dictionary<Guid, TaskItem> store = new Dictionary<Guid, TaskItem>
            {
                { task.TaskId, task }
            };

            UpdateTaskTitleHandler handler = new UpdateTaskTitleHandler(store);
            UpdateTaskTitleCommand command = new UpdateTaskTitleCommand(task.TaskId, " ");

            ArgumentException? ex = Assert.ThrowsAsync<ArgumentException>(() => handler.Handle(command));
            Assert.That(ex.Message, Does.Contain("Title"));
        }
    }
}
