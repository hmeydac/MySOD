using MySOD.UI.ViewModels;

namespace MySOD.UI.Tests.Commands
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Core;
    using UI.Commands;

    [TestClass]
    public class AddTaskCommandTests
    {
        private Backlog backlog;
        private BacklogViewModel backlogViewModel;
        private AddTaskCommand command;

        [TestInitialize]
        public void SetUp()
        {
            this.backlog = new Backlog();
            this.backlogViewModel = new BacklogViewModel(this.backlog);
            this.command = new AddTaskCommand(this.backlogViewModel);
        }

        [TestMethod]
        public void ExecuteCommandShouldAddTaskInBacklog()
        {
            command.CanExecute("New Task");
            command.Execute("New Task");
            Assert.AreEqual(1, backlog.TaskCount);
            Assert.AreEqual("New Task", backlog.GetTask(0).Title);
        }

        [TestMethod]
        public void ExecuteCommandShouldCleanCurrentTextFromViewModel()
        {
            this.backlogViewModel.TaskTitle = "New Task";
            Assert.AreEqual("New Task", this.backlogViewModel.TaskTitle, "Command should read the Task Title parameter from ViewModel");
            command.Execute("New Task");
            Assert.AreEqual(string.Empty, this.backlogViewModel.TaskTitle, "BacklogViewModel should have an empty Task Title after executing command");
        }
    }
}
