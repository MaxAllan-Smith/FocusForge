using FocusForge.Application.Commands;
using FocusForge.Application.Handlers;
using FocusForge.Domain.Entities;

namespace FocusForge.Tests.UnitTests.Application.Tasks
{
    [TestFixture]
    public class CompleteTaskHandlerTests
    {
        [Test]
        public async Task CanMarkTaskAsComplete()
        {
            // Arrange
            TaskItem task = new("Write more tests");
            Dictionary<Guid, TaskItem> store = new()
            {
                { task.TaskId, task }
            };

            CompleteTaskHandler handler = new(store);
            CompleteTaskCommand command = new(task.TaskId);

            // Act
            await handler.Handle(command);

            // Assert
            Assert.That(task.IsCompleted, Is.True);
        }

        [Test]
        public void ThrowsIfTaskNotFound()
        {
            // Arrange
            Dictionary<Guid, TaskItem> store = new();
            var handler = new CompleteTaskHandler(store);
            var command = new CompleteTaskCommand(Guid.NewGuid());

            // Act + Assert
            KeyNotFoundException? ex = Assert.ThrowsAsync<KeyNotFoundException>(() => handler.Handle(command));
            Assert.That(ex.Message, Does.Contain("not found"));
        }
    }
}
