using MyFirstMauiApp.Models;
using MyFirstMauiApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFirstMauiApp.ViewModels
{
    public class AddNoteViewModel : INotifyPropertyChanged
    {
        private string _noteText = string.Empty;
        public string NoteText
        {
            get => _noteText;
            set
            {
                if (_noteText == value) return;
                _noteText = value;
                OnPropertyChanged();
                ((Command)SaveNoteCommand).ChangeCanExecute();
            }
        }

        public ICommand SaveNoteCommand { get; }

        public AddNoteViewModel()
        {
            SaveNoteCommand = new Command(async () =>
            {
                if (!string.IsNullOrWhiteSpace(NoteText))
                {
                    NoteStore.Notes.Add(new Note { Text = NoteText, CreatedAt = DateTime.Now });
                    await Shell.Current.GoToAsync(".."); // go back
                }
            }, () => !string.IsNullOrWhiteSpace(NoteText));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
