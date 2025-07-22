using FocusForge.Domain.Entities;

namespace FocusForge.Tests.UnitTests.Domain
{
    [TestFixture]
    public class TaskItemTests
    {
        [Test]
        public void CanCreateAndCompleteTask()
        {
            // Arrange
            TaskItem task = new("Write test plan");

            // Assert initial state
            Assert.That(task.Title, Is.EqualTo("Write test plan"));
            Assert.That(task.IsCompleted, Is.False);

            // Act
            task.MarkComplete();

            // Assert final state
            Assert.That(task.IsCompleted, Is.True);
        }

        [Test]
        public void ThrowsIfTitleIsEmpty()
        {
            // Act & Assert
            ArgumentException? ex = Assert.Throws<ArgumentException>(() => new TaskItem(""));
            Assert.That(ex.Message, Does.Contain("Title"));
        }
    }
}
