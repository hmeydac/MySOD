using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MySOD.Core;
using MySOD.UI.Annotations;

namespace MySOD.UI.ViewModels
{
    public class BacklogViewModel : INotifyPropertyChanged
    {
        private readonly Backlog backlog;
        private string title;

        public BacklogViewModel(Backlog backlog)
        {
            this.backlog = backlog;
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<WorkTask> Tasks
        {
            get { return new ObservableCollection<WorkTask>(this.backlog.GetList()); }
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
