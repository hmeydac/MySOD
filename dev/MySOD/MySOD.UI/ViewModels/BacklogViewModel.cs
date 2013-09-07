namespace MySOD.UI.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using MySOD.Core;
    using MySOD.UI.Commands;

    public class BacklogViewModel : INotifyPropertyChanged
    {
        private readonly Backlog backlog;
        private string taskTitle;

        private WorkTask selectedTask;

        public BacklogViewModel(Backlog backlog)
        {
            this.TaskTitle = string.Empty;
            this.backlog = backlog;
            this.AddTaskCommand = new AddTaskCommand();
            this.AddTaskCommand.ExecuteCompleted += this.AddTaskCommandExecuteCompleted;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string TaskTitle
        {
            get
            {
                return this.taskTitle;
            }

            set
            {
                this.taskTitle = value;
                this.OnPropertyChanged("TaskTitle");
            }
        }

        public ObservableCollection<WorkTask> Tasks
        {
            get { return new ObservableCollection<WorkTask>(this.backlog.GetList()); }
        }

        public AddTaskCommand AddTaskCommand { get; set; }

        public WorkTask SelectedTask
        {
            get
            {
                return this.selectedTask;
            }

            set
            {
                this.selectedTask = value;
                this.OnPropertyChanged("SelectedTask");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void AddTaskCommandExecuteCompleted(object sender, CommandExecutionEventArgs e)
        {
            var task = (WorkTask)e.Result;
            this.backlog.Add(task);
        }
    }
}
