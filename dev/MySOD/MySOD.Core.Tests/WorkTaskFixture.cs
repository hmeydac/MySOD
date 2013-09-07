namespace MySOD.Core.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WorkTaskFixture
    {
        private WorkTask task;

        const string Title = "My Title";

        [TestInitialize]
        public void SetUp()
        {
            this.task = new WorkTask();
        }

        [TestMethod]
        public void WorkTaskShouldHaveTitle()
        {
            // Act
            this.task.Title = Title;
            
            // Assert
            Assert.AreEqual(Title, this.task.Title);
        }       

        [TestMethod]
        public void WorkTaskShouldHaveACompletionMark()
        {
            Assert.IsFalse(this.task.IsCompleted);
        }

        [TestMethod]
        public void CloseWorkTaskShouldMarkTaskAsCompleted()
        {
            this.task.Complete();
            Assert.IsTrue(this.task.IsCompleted);
        }

        [TestMethod]
        public void ToStringMethodShouldReturnTaskTitle()
        {
            this.task.Title = Title;
            Assert.AreEqual(Title, this.task.ToString());
        }
    }
}
