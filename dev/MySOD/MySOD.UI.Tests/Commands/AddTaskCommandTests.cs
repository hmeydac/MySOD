namespace MySOD.UI.Tests.Commands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MySOD.Core;
    using MySOD.UI.Commands;

    [TestClass]
    public class AddTaskCommandTests
    {
        [TestMethod]
        public void ExecuteCommandShouldAddTaskInBacklog()
        {
            var backlog = new Backlog();
            var command = new AddTaskCommand(backlog);
            var parameter = "New Task";

            command.CanExecute(parameter);
            command.Execute(parameter);
            Assert.AreEqual(1, backlog.TaskCount);
            Assert.AreEqual(parameter, backlog.GetTask(0).Title);
        }
    }
}
