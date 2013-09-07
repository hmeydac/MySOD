namespace MySOD.UI.Commands
{
    using System;
    using System.Windows.Input;

    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public event EventHandler<CommandExecutionEventArgs> ExecuteCompleted;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        public void RaiseExecutionCompleted(object result)
        {
            if (this.ExecuteCompleted == null)
            {
                throw new InvalidOperationException("Could not raise event Execution Completed as it was not no handled by the application.");
            }

            this.ExecuteCompleted(this, new CommandExecutionEventArgs(result));
        }
    }
}
