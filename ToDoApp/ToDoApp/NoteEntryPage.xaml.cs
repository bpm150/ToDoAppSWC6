using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, 
                    $"{Path.GetRandomFileName()}.notes.txt");
                File.WriteAllText(filename, note.Text);
            } else
            {
                File.WriteAllText(note.Filename, note.Text);
            }
        }
    }
}