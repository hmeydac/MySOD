namespace MySOD.UI.Tests.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MySOD.Core;
    using MySOD.UI.ViewModels;

    [TestClass]
    public class BacklogViewModelFixture
    {
        private BacklogViewModel viewModel;

        private Backlog backlog;

        [TestInitialize]
        public void SetUp()
        {
            this.backlog = new Backlog();
            this.viewModel = new BacklogViewModel(this.backlog);
        }

        [TestMethod]
        public void BacklogViewModelShouldHaveTaskTitle()
        {
            const string Title = "Task Title";
            this.viewModel.TaskTitle = Title;
            Assert.AreEqual(Title, this.viewModel.TaskTitle);
        }

        [TestMethod]
        public void BacklogViewModelShouldHaveTasks()
        {
            this.backlog.Add(new WorkTask());
            CollectionAssert.AreEqual(this.backlog.GetList(), this.viewModel.Tasks);
        }

        [TestMethod]
        public void BacklogViewModelShouldHaveSelectedTask()
        {
            Assert.IsNull(this.viewModel.SelectedTask);
            var propertyChangedName = string.Empty;
            this.viewModel.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                propertyChangedName = e.PropertyName;
            };

            this.viewModel.SelectedTask = new WorkTask();
            Assert.AreEqual("SelectedTask", propertyChangedName);
            Assert.IsNotNull(this.viewModel.SelectedTask);
        }

        [TestMethod]
        public void BacklogViewModelShouldHaveInitializedCommands()
        {
            Assert.IsNotNull(this.viewModel.AddTaskCommand);
            Assert.IsInstanceOfType(this.viewModel.AddTaskCommand, typeof(ICommand));
        }

        [TestMethod]
        public void AddTaskExecutionCompleteShouldAddTaskInBacklog()
        {
            Assert.AreEqual(0, this.backlog.TaskCount);
            this.viewModel.AddTaskCommand.Execute("test");
            Assert.AreEqual(1, this.backlog.TaskCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddTaskExecutionWithNoParameterShouldFail()
        {
            this.viewModel.AddTaskCommand.Execute(null);
            Assert.Fail();
        }
    }
}
