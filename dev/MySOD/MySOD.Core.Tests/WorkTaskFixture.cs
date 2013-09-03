namespace MySOD.Core.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WorkTaskFixture
    {
        [TestMethod]
        public void WorkTaskShouldHaveTitle()
        {
            var task = new WorkTask();
            const string Title = "My Title";
            
            // Act
            task.Title = Title;
            
            // Assert
            Assert.AreEqual(Title, task.Title);
        }

        [TestMethod]
        public void WorkTaskShouldHaveDescription()
        {
            var task = new WorkTask();
            const string Description = "Description";

            // Act
            task.Description = Description;
            
            // Assert
            Assert.AreEqual(Description, task.Description);
        }

        [TestMethod]
        public void WorkTaskShouldHaveWeight()
        {
            var task = new WorkTask();
            const int Weight = 20;

            // Act
            task.Weight = Weight;
            
            // Assert
            Assert.AreEqual(Weight, task.Weight);
        }

        [TestMethod]
        public void WorkTaskShouldHaveMarkForToday()
        {
            var task = new WorkTask();
            var forToday = true;

            // Act
            task.ForToday = true;
            Assert.IsTrue(task.ForToday);
            task.ForToday = false;
            Assert.IsFalse(task.ForToday);
        }

        [TestMethod]
        public void WorkTaskShouldHaveACompletionMark()
        {
            var task = new WorkTask();
            Assert.IsFalse(task.IsCompleted());
        }

        [TestMethod]
        public void CloseWorkTaskShouldMarkTaskAsCompleted()
        {
            var task = new WorkTask();
            task.Complete();
            Assert.IsTrue(task.IsCompleted());
        }
    }
}
