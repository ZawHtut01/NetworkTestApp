using MyFirstMauiApp.Views;

namespace MyFirstMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // register route for AddNotePage so we can navigate via Shell
            //Routing.RegisterRoute(nameof(AddNotePage), typeof(AddNotePage));
        }
    }
}
