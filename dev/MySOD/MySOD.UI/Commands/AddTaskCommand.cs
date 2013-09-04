using System;
using System.Windows.Input;
using MySOD.Core;
using MySOD.UI.ViewModels;

namespace MySOD.UI.Commands
{
    public class AddTaskCommand : BaseCommand
    {
        public AddTaskCommand(BacklogViewModel backlogViewModel)
        {
        }

        public event EventHandler CanExecuteChanged;

        public override bool CanExecute(object parameter)
        {
            var taskName = parameter as string;
            return !string.IsNullOrEmpty(taskName);
        }

        public override void Execute(object parameter)
        {
            this.backlogViewModel.Tasks.Add(new WorkTask { Title = (string)parameter });
        }
    }
}
