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
        private string title;

        private WorkTask selectedTask;

        public BacklogViewModel(Backlog backlog)
        {
            this.backlog = backlog;
            this.AddTaskCommand = new AddTaskCommand(this.backlog);
            this.DeleteTaskCommand = new DeleteTaskCommand(this.backlog);
            this.UpdateTaskCommand = new UpdateTaskCommand();
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
