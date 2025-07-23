using FocusForge.Application.Commands;
using FocusForge.Application.Handlers;
using FocusForge.Domain.Entities;

namespace FocusForge.Tests.UnitTests.Application.Tasks
{
    [TestFixture]
    public class CreateTaskHandlerTests
    {
        [Test]
        public async Task CanCreateTask()
        {
            CreateTaskHandler handler = new();

            CreateTaskCommand command = new("Focus on unit tests");
            TaskItem result = await handler.Handle(command);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("Focus on unit tests"));
            Assert.That(result.IsCompleted, Is.False);
            Assert.That(result.TaskId, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
