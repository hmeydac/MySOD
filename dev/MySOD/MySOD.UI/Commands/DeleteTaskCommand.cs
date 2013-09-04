namespace MySOD.UI.Commands
{
    using System;
    using System.Windows.Input;

    using MySOD.Core;
    using MySOD.UI.Properties;

    public class DeleteTaskCommand : ICommand
    {
        private readonly Backlog backlog;

        public DeleteTaskCommand(Backlog backlog)
        {
            this.backlog = backlog;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var task = parameter as WorkTask;
            if (task == null)
            {
                return false;
            }

            return this.backlog.Contains(task);
        }

        public void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
            {
                throw new ArgumentException(Resources.DeleteTaskCommandInvalidExecute, "parameter");
            }

            this.backlog.Remove((WorkTask)parameter);
        }
    }
}
