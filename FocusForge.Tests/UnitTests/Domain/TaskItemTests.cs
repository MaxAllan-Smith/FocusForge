namespace FocusForge.Tests.UnitTests.Domain
{
    public class TaskItemTests
    {
        [Test]
        public void CanCreateAndCompleteTask()
        {
            var task = new TaskItem("Write test plan");

            Assert.AreEqual("Write test plan", task.Title);
            Assert.IsFalse(task.IsCompleted);

            task.MarkComplete();

            Assert.IsTrue(task.IsCompleted);
        }

        [Test]
        public void ThrowsIfTitleIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new TaskItem(""));
        }
    }
}
