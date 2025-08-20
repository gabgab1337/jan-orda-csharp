using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoApp.Models;

namespace ToDoApp.ViewModels
{
  public class MainViewModel : INotifyPropertyChanged
  {
    public ObservableCollection<ToDoItem> ToDoItems { get; set; } = new ObservableCollection<ToDoItem>();
  }
}