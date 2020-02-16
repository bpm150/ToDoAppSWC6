using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string filename = Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), "notes.txt");
        public MainPage()
        {
            InitializeComponent();
            if (File.Exists(filename))
            {
                editor.Text = File.ReadAllText(filename);
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(filename, editor.Text);
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            editor.Text = string.Empty;
        }

    }
}
