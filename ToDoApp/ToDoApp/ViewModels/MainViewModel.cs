using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ToDoItem> ToDoItems { get; set; } = new ObservableCollection<ToDoItem>();

        private string _newTodoTitle;
        public string NewTodoTitle
        {
            get => _newTodoTitle;
            set
            {
                if (_newTodoTitle != value)
                {
                    _newTodoTitle = value;
                    OnPropertyChanged();

                    (AddToDoCommand as Command).ChangeCanExecute();
                }
            }
        }

        public ICommand AddToDoCommand { get; }

        public MainViewModel()
        {
            AddToDoCommand = new Command(OnAddToDo, CanAddToDo);
        }

        private void OnAddToDo()
        {
            ToDoItems.Add(new ToDoItem { Title =  NewTodoTitle, IsDone = false });
            NewTodoTitle = string.Empty;
        }

        private bool CanAddToDo()
        {
            return !string.IsNullOrWhiteSpace(NewTodoTitle);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}