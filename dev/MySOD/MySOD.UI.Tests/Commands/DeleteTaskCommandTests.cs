namespace MySOD.UI.Tests.Commands
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MySOD.Core;
    using MySOD.UI.Commands;

    [TestClass]
    public class DeleteTaskCommandTests
    {
        [TestMethod]
        public void ExecuteCommandShouldRemoveTaskFromBacklog()
        {
            var backlog = new Backlog();
            backlog.Add(new WorkTask());
            var command = new DeleteTaskCommand(backlog);
            Assert.IsTrue(command.CanExecute(backlog.GetTask(0)));
            command.Execute(backlog.GetTask(0));
            Assert.AreEqual(0, backlog.TaskCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ExecuteCommandUnknownTaskShouldNotRemoveFromBacklog()
        {
            var backlog = new Backlog();
            backlog.Add(new WorkTask());
            var command = new DeleteTaskCommand(backlog);
            Assert.IsFalse(command.CanExecute(new WorkTask()));
            Assert.IsFalse(command.CanExecute("my variable"));
            command.Execute(new WorkTask());
        }
    }
}
