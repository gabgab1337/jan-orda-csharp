using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
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

                    OnPropertyChanged(nameof(TitleCharacterCount));
                    IsAddButtonEnabled = !string.IsNullOrWhiteSpace(value);
                }
            }
        }

        private bool _isAddButtonEnabled;
        public bool IsAddButtonEnabled
        {
            get => _isAddButtonEnabled;
            set
            {
                if(_isAddButtonEnabled != value)
                {
                    _isAddButtonEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public string TitleCharacterCount => $"Liczba znaków: {NewTodoTitle?.Length ?? 0}";

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnClearedClicked(object sender, EventArgs e)
        {
            NewTodoTitle = string.Empty;
        }

        #region INotifyPropertyChanged Implementation
        // Implementujemy interfejs
        public event PropertyChangedEventHandler PropertyChanged;

        // Tworzymy metodę do eventu
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
