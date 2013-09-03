using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySOD.Core;
using MySOD.UI.ViewModels;

namespace MySOD.UI.Tests.ViewModels
{
    [TestClass]
    public class BacklogViewModelFixture
    {
        [TestMethod]
        public void BacklogViewModelShouldHaveTaskTitle()
        {
            var viewModel = new BacklogViewModel(new Backlog());
            const string Title = "Task Title";
            viewModel.Title = Title;
            Assert.AreEqual(Title, viewModel.Title);
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
        public void BacklogViewModelShouldNotifyPropertyChanged()
        {
            var viewModel = new BacklogViewModel(new Backlog());
            var propertyChangedName = string.Empty;
            viewModel.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
                {
                    propertyChangedName = e.PropertyName;
                };

            viewModel.Title = "Change me";
            
            Assert.AreEqual("Title", propertyChangedName);
        }
    }
}
