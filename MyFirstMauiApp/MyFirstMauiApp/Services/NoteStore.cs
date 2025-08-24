using MyFirstMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMauiApp.Services
{
    public static class NoteStore
    {
        public static ObservableCollection<Note> Notes { get; } =
            new ObservableCollection<Note>
            {
            //new Note { Text = "Welcome Baby", CreatedAt = DateTime.Now }
            };
    }
}
