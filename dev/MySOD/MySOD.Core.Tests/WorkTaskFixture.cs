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
        public void WorkTaskShouldHaveACompletionMark()
        {
            var task = new WorkTask();
            Assert.IsFalse(task.IsCompleted);
        }

        [TestMethod]
        public void CloseWorkTaskShouldMarkTaskAsCompleted()
        {
            var task = new WorkTask();
            task.Complete();
            Assert.IsTrue(task.IsCompleted);
        }
    }
}
