using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoApp.ViewModels;

namespace ToDoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
