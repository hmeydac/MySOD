namespace MySOD.UI.Commands
{
    using System;

    using MySOD.Core;

    public class AddTaskCommand : BaseCommand
    {
        public override bool CanExecute(object parameter)
        {
            var taskName = parameter as string;
            return !string.IsNullOrEmpty(taskName);
        }

        public override void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
            {
                throw new ArgumentNullException("parameter");
            }

            var newTask = new WorkTask { Title = (string)parameter };
            this.RaiseExecutionCompleted(newTask);
        }
    }
}
