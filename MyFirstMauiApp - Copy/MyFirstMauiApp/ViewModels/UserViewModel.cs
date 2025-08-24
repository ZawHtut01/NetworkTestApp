using MyFirstMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMauiApp.ViewModels
{

    public class UserViewModel
    {
        public UserModel User { get; set; } = new();

        public ICommand SubmitCommand { get; }

        public UserViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        private void OnSubmit()
        {
            App.Current.MainPage.DisplayAlert(
                "Submitted",
                $"Name: {User.Name}\nEmail: {User.Email}",
                "OK");
        }
    }
}
