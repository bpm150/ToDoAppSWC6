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
    public partial class NodesPage : ContentPage
    {
        public NodesPage()
            // As son as page is to be loaded, constructor called

        // Life cyle of pages

        // On Appearing
        {
            InitializeComponent();
        }

        // override
        // inheriting from another class
        // start with override, shows you what base class provides
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // template of the method got from parent

            // override behavior to change the behavior
            // sometimes you wnat to keep what parent does plus add more


            var notes = new List<Note>();
            // fill the notes with all notes have in file system
            // recall each note is in own file


            // create var called files

            // enumerate through directly
            // look in dir every file that ends with notes.txt

            // randomname.notes.txt

            // find all these
            // read each one
            // read into list of node

            // list populated from file system

            // think about your design first, dont' jus tstart writngin code



            var files = Directory.EnumerateFiles(App.FolderPath, "*notes.txt");
            // if there were any notes
            // gives you a list of file names
            // havne't opened them yet
            // does give you the entire path

            foreach (var filename in files)
            {
                // create a note object dump into notes array

                // Note the object init with {}
                notes.Add(new Note
                {
                    Filename = filename,
                    Text = File.ReadAllText(filename), // file is note, nothing else
                    Date = File.GetCreationTime(filename)
                });

                // Programmatically bind vs. soundboard

                listView.ItemsSource = notes.OrderBy(n => n.Date).ToList();
                // Intrpret as List
                    // pass a lambda
                    // go thorugh each one and order by the date

            // Where would need a comparison

            // OrderBy tooltip give me a Func
            // Where will require you to pass a boolean back
            // OrderBy is not a filtering


            // Recall TextCell Text and Detail already bound in xaml
            // Now binding next level op in code aboce
            }

            async void OnNoteAddedClicked(object sender, EventArgs e)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = new Note(),
                                        // new empty note
                                        // bind to empty note
                                        // note that this is a two-way binding
                });
                // specify the page
                // create an instance of the page

                // must tell what this page will be bound to
                // bind it while is creating



                private async void OnListViewItemSelected(object sender, SelectedItemChangedArgs e)
                {
                    // this happens when you click on something

                    // EventArgs is parent class of all eventargs
                    // SelectedItemChangedArgs?
                    // how do I know?
                    // go back to 

                    if (e.SelectedItem != null)
                    {
                        await Navigation.PushAsync(new NoteEntryPage{ 
                            BindingContext = e.SelectedItem as Note

                        }
                            
                            )

                            // review this

                    // somebody is calling mainpage by deafult must fix

                    }

                }

            }
        }
    }
}