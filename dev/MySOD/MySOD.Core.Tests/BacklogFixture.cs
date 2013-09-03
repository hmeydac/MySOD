namespace MySOD.Core.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BacklogFixture
    {
        [TestMethod]
        public void AddTaskToBacklogShouldContainTask()
        {
            var backlog = new Backlog();
            var task = new WorkTask();

            backlog.Add(task);
            Assert.AreEqual(1, backlog.TaskCount());
        }

        [TestMethod]
        public void GetTaskShouldReturnTask()
        {
            var backlog = new Backlog();
            var task = new WorkTask();
            backlog.Add(task);
            var actualTask = backlog.GetTask(0);
            Assert.AreEqual(task, actualTask);
        }

        [TestMethod]
        public void RemoveTaskShouldRemoveItFromBacklog()
        {
            var backlog = new Backlog();
            var task = new WorkTask();
            backlog.Add(task);
            backlog.Remove(0);
            Assert.AreEqual(0, backlog.TaskCount());
        }
    }
}
