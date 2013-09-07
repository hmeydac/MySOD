namespace MySOD.UI.Tests.Commands
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using UI.Commands;

    [TestClass]
    public class AddTaskCommandTests
    {
        private AddTaskCommand command;

        [TestInitialize]
        public void SetUp()
        {
            this.command = new AddTaskCommand();
        }

        [TestMethod]
        public void AddTaskShouldCallExecutionCompleted()
        {
            var executionCompleted = false;
            this.command.ExecuteCompleted += delegate { executionCompleted = true; };
            this.command.Execute("Test");
            Assert.IsTrue(executionCompleted);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTaskExecuteWithNullShouldThrowException()
        {
            this.command.Execute(null);
            Assert.Fail("Expected a NullArgumentException as no parameter was set.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddTaskExecuteWithoutEventHandlerShouldThrowException()
        {
            this.command.Execute("Test");
            Assert.Fail("Expected a InvalidOperation Exception as no event handler was set.");
        }
    }
}
