using System;
using System.Windows.Input;

namespace MySOD.UI.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public event EventHandler ExecuteCompleted;

        public abstract bool CanExecute(object parameter);

        public virtual void Execute(object parameter)
        {
            if (this.ExecuteCompleted != null)
            {
                this.ExecuteCompleted(this, new EventArgs());
            }
        }
    }
}
