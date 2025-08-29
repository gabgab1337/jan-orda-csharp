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

        // public int ActiveTaskCount => ToDoItems.Count(item => !item.IsDone);
        // public int CompletedTaskCount => ToDoItems.Count(item => item.IsDone);
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
        public ICommand RemoveCompletedItemsCommand { get; }

        public MainViewModel()
        {
            AddToDoCommand = new Command(OnAddToDo, CanAddToDo);
            RemoveCompletedItemsCommand = new Command(RemoveCompletedItems, CanRemoveCompletedItems);
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

        private void RemoveCompletedItems()
        {
            var completedItems = ToDoItems.Where(item => item.IsDone).ToList();
            foreach (var item in completedItems)
            {
                ToDoItems.Remove(item);
            }
        }

        private bool CanRemoveCompletedItems()
        {
            return ToDoItems.Any(item => item.IsDone);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}