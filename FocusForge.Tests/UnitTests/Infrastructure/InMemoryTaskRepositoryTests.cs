using FocusForge.Domain.Entities;
using FocusForge.Infrastructure.Repositories;

namespace FocusForge.Tests.UnitTests.Infrastructure
{
    [TestFixture]
    public class InMemoryTaskRepositoryTests
    {
        [Test]
        public async Task CanAddAndRetrieveTask()
        {
            InMemoryTaskRepository repo = new();

            TaskItem? task = new("Save this");
            await repo.AddAsync(task);

            TaskItem? loaded = await repo.GetByIdAsync(task.TaskId);

            Assert.That(loaded, Is.Not.Null);
            Assert.That(loaded.Title, Is.EqualTo("Save this"));
        }

        [Test]
        public void ThrowsIfTaskNotFound()
        {
            InMemoryTaskRepository repo = new();

            KeyNotFoundException? ex = Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await repo.GetByIdAsync(Guid.NewGuid());
            });

            Assert.That(ex.Message, Does.Contain("not found"));
        }
    }
}
