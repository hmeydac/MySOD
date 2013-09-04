namespace MySOD.UI.Tests.ViewModels
{
    using System.ComponentModel;
    using System.Windows.Input;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MySOD.Core;
    using MySOD.UI.ViewModels;

    [TestClass]
    public class BacklogViewModelFixture
    {
        [TestMethod]
        public void BacklogViewModelShouldHaveTaskTitle()
        {
            var viewModel = new BacklogViewModel(new Backlog());
            const string Title = "Task Title";
            viewModel.TaskTitle = Title;
            Assert.AreEqual(Title, viewModel.TaskTitle);
        }

        [TestMethod]
        public void BacklogViewModelShouldHaveTasks()
        {
            var backlog = new Backlog();
            backlog.Add(new WorkTask());
            var viewModel = new BacklogViewModel(backlog);
            CollectionAssert.AreEqual(backlog.GetList(), viewModel.Tasks);
        }

        [TestMethod]
        public void BacklogViewModelShouldHaveSelectedTask()
        {
            var viewModel = new BacklogViewModel(new Backlog());
            Assert.IsNull(viewModel.SelectedTask);
            var propertyChangedName = string.Empty;
            viewModel.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                propertyChangedName = e.PropertyName;
            };

            viewModel.SelectedTask = new WorkTask();
            Assert.AreEqual("SelectedTask", propertyChangedName);
            Assert.IsNotNull(viewModel.SelectedTask);
        }

        [TestMethod]
        public void BacklogViewModelShouldHaveInitializedCommands()
        {
            var viewModel = new BacklogViewModel(new Backlog());
            Assert.IsNotNull(viewModel.AddTaskCommand);
            Assert.IsNotNull(viewModel.DeleteTaskCommand);
            Assert.IsNotNull(viewModel.UpdateTaskCommand);
            Assert.IsInstanceOfType(viewModel.AddTaskCommand, typeof(ICommand));
            Assert.IsInstanceOfType(viewModel.DeleteTaskCommand, typeof(ICommand));
            Assert.IsInstanceOfType(viewModel.UpdateTaskCommand, typeof(ICommand));
        }
    }
}
