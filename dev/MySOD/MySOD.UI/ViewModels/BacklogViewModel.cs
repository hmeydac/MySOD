namespace MySOD.UI.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using MySOD.Core;
    using MySOD.UI.Annotations;
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
            this.AddTaskCommand = new AddTaskCommand(this);
            this.DeleteTaskCommand = new DeleteTaskCommand(this.backlog);
            this.UpdateTaskCommand = new UpdateTaskCommand();
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
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<WorkTask> Tasks
        {
            get { return new ObservableCollection<WorkTask>(this.backlog.GetList()); }
        }

        public AddTaskCommand AddTaskCommand { get; set; }

        public DeleteTaskCommand DeleteTaskCommand { get; set; }

        public UpdateTaskCommand UpdateTaskCommand { get; set; }

        public WorkTask SelectedTask
        {
            get
            {
                return this.selectedTask;
            }

            set
            {
                this.selectedTask = value;
                this.OnPropertyChanged();
            }
        }

        public void AddTaskInBacklog(string title)
        {
            var newTask = new WorkTask {Title = title};
            this.Tasks.Add(newTask);
            this.backlog.Add(newTask);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
