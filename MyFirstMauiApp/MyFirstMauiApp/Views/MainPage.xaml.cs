using Microsoft.Maui.Controls;
using MyFirstMauiApp.ViewModels;
using MyFirstMauiApp.Views;

namespace MyFirstMauiApp.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    private async void OnAddNoteClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddNotePage));
    }
}
