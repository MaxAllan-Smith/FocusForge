using FocusForge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusForge.Tests.UnitTests.Application.Tasks
{
    [TestFixture]
    public class CreateTaskHandlerTests
    {
        [Test]
        public async Task CanCreateTask()
        {
            var handler = new CreateTaskHandler();

            var command = new CreateTaskCommand("Focus on unit tests");
            TaskItem result = await handler.Handle(command);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Title, Is.EqualTo("Focus on unit tests"));
            Assert.That(result.IsCompleted, Is.False);
            Assert.That(result.Id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
