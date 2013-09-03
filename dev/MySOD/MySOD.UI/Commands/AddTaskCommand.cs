using System;
using System.Windows.Input;
using MySOD.Core;

namespace MySOD.UI.Commands
{
    public class AddTaskCommand : ICommand
    {
        private readonly Backlog backlog;

        public AddTaskCommand(Backlog backlog)
        {
            this.backlog = backlog;
        }

        public bool CanExecute(object parameter)
        {
            var taskName = parameter as string;
            return !string.IsNullOrEmpty(taskName);
        }

        public void Execute(object parameter)
        {
            this.backlog.Add(new WorkTask(){ Title = (string)parameter });
        }

        public event EventHandler CanExecuteChanged;
    }
}
