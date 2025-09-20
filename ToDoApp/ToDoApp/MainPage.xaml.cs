using System.ComponentModel;
using System.Runtime.CompilerServices;
using ToDoApp.ViewModels;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace ToDoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
        
        private void txtfield_Completed(object sender, EventArgs e)
        {
            if (BindingContext is ToDoApp.ViewModels.MainViewModel vm && vm.AddToDoCommand.CanExecute(null))
            {
                vm.AddToDoCommand.Execute(null);
            }
        }

        private async void Export_Clicked(object sender, EventArgs e)
        {   
            if (BindingContext is ToDoApp.ViewModels.MainViewModel vm) { 
                var json = JsonSerializer.Serialize(vm.ToDoItems);
                var fileName = $"ToDoExport_{DateTime.Now:yyyyMMdd_HHmmss}.json";

                var folder = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Wybierz folder do zapisu!"
                });

                if (folder != null)
                {
                    var directoryPath = Path.GetDirectoryName(folder.FullPath);
                    var filePath = Path.Combine(directoryPath, fileName);
                    await File.WriteAllTextAsync(filePath, json);
                    await DisplayAlert("Sukces!!!", "Plik zapisany!", "Wyœmienicie!");
                }
            }
        }

        //private async void Import_Clicked(object sender, EventArgs e)
        //{

        //}
    }
}
