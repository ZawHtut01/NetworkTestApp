using MyFirstMauiApp.ViewModels;

namespace MyFirstMauiApp.Views;

public partial class AddNotePage : ContentPage
{
    public AddNotePage()
    {
        InitializeComponent();
        BindingContext = new AddNoteViewModel();
    }
}