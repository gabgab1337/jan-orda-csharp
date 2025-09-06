using System.ComponentModel;

namespace ToDoApp.Models
{
  public class ToDoItem : INotifyPropertyChanged
  {
    private string _title;
    public string Title
    {
      get => _title;
      set
      {
        if (_title != value)
        {
          _title = value;
          OnPropertyChanged(nameof(Title));
        }
      }
    }

    private bool _isDone;
    public bool IsDone
    {
      get => _isDone;
      set
      {
        if (_isDone != value)
        {
          _isDone = value;
          OnPropertyChanged(nameof(IsDone));
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}