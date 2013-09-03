namespace MySOD.Core.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class BacklogFixture
    {
        [TestMethod]
        public void AddTaskToBacklogShouldContainTask()
        {
            var backlog = new Backlog();
            var task = new WorkTask();

            backlog.Add(task);
            Assert.AreEqual(1, backlog.TaskCount);
        }

        [TestMethod]
        public void ReplaceTaskInBacklogShouldContainNewTask()
        {
            var backlog = new Backlog();
            var oldTask = new WorkTask() { Title = "Old Title" };
            var newTask = new WorkTask() { Title= "New Title" };
            backlog.Add(oldTask);
            backlog.Replace(newTask, 0);
            Assert.AreEqual(1, backlog.TaskCount);
            Assert.AreEqual(newTask, backlog.GetTask(0));
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
            Assert.AreEqual(0, backlog.TaskCount);
        }

        [TestMethod]
        public void AddMultipleTasksToBacklogShouldKeepSameOrder()
        {
            var backlog = new Backlog();
            var expectedTasks = new List<WorkTask>{
                new WorkTask(),
                new WorkTask(),
                new WorkTask()
            };

            expectedTasks.ForEach(backlog.Add);            
                        
            Assert.AreEqual(3, backlog.TaskCount);
            CollectionAssert.AreEqual(expectedTasks, backlog.GetList());
        }
    }
}
