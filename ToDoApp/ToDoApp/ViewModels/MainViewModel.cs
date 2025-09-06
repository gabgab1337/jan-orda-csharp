using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ToDoApp.Models;
using System.Text.Json;
using System.IO;
using Microsoft.Maui.Storage;
using System.Diagnostics;

namespace ToDoApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly string _saveFilePath = Path.Combine(FileSystem.Current.AppDataDirectory, "todos.json");
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

            LoadToDoItems();
            ToDoItems.CollectionChanged += (s, e) => SaveToDoItems();
        }

        private void SaveToDoItems()
        {
            var json = JsonSerializer.Serialize(ToDoItems);
            File.WriteAllText(_saveFilePath, json);
            Debug.WriteLine("Zapisano");
        }

        private void LoadToDoItems()
        {
            if (File.Exists(_saveFilePath))
            {
                var json = File.ReadAllText(_saveFilePath);
                var items = JsonSerializer.Deserialize<ObservableCollection<ToDoItem>>(json);

                if (items != null)
                {
                    ToDoItems.Clear();
                    foreach (var item in items)
                    {
                        item.PropertyChanged += ToDoItem_PropertyChanged;
                        ToDoItems.Add(item);
                    }
                    Debug.WriteLine("Za³adowano");
                }
            }
        }

        private bool CanAddToDo()
        {
            return !string.IsNullOrWhiteSpace(NewTodoTitle);
        }

        private void OnDeleteToDo(ToDoItem itemToDelete)
        {
            if (itemToDelete != null)
            {
                itemToDelete.PropertyChanged -= ToDoItem_PropertyChanged;
                ToDoItems.Remove(itemToDelete);
            }
            SaveToDoItems();
        }

        private void RemoveCompletedItems()
        {
            var completedItems = ToDoItems.Where(item => item.IsDone).ToList();
            foreach (var item in completedItems)
            {
                ToDoItems.Remove(item);
            }
            SaveToDoItems();
        }

        private bool CanRemoveCompletedItems()
        {
            return ToDoItems.Any(item => item.IsDone);
        }

        private void ToDoItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ToDoItem.IsDone))
            {
                (RemoveCompletedItemsCommand as Command).ChangeCanExecute();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnAddToDo()
        {
            var newItem = new ToDoItem { Title = NewTodoTitle, IsDone = false };
            newItem.PropertyChanged += ToDoItem_PropertyChanged;
            ToDoItems.Add(newItem);
            NewTodoTitle = string.Empty;
            SaveToDoItems();
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}