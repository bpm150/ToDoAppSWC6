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




        /*
         

Review end from last time (lecture 5)
OnSaveButtonClicked
https://youtu.be/BdYqEUfyJ8w?list=PLdbymrfiqF-wmh3VsbxysBsu2O9w6Z3Ks&t=3698

Idea:
Somewhere, somebody is going to bind this page to a Note object
(eventual goal)

Job of OnSaveButtonClicked
Grab everything on ?the page, assume it is of type Node, and read its text property

“Every page has got a BindingContext”
Whatever the page is bound to

NoteEntryPage : ContentPage
“is a”

Every ContentPage has a BindingContext



QUESTION: (If not here, where is the type safety enforced?)
var note = (Note)BindingContext;
Can this type cast fail or throw?


Then never have to work with the Editor control directly
Later say “Hey BindingContext, you know where the Text is bound to, give me the
Text of the Note”
Text property is bound to that text box

(Thus avoids reading from editor control’s Text directly)





Looking at OnSaveButtonClicked, what creates the BindingContext object?
BindingContext derives from INotifyPropertyChanged, IDynamicResourceHandler,
but where do we get this BindingContext from?

Clearly not from sender or e, is it global?
At what scope is BindingContext visible?

What if we had different bindings to different xaml elements?
Could we have two different BindingContext objects simultaneously?



QUESTION? Also, how did the Save Button get associated with the Text box
It is nearby, but how did it get connected




** QUESTION? Why did we not need something like a BindingContext for the
* soundboard app?
Is it because we didn’t need two-way binding for the soundboard but we do for
the ToDoApp?
Realize that BindingContext is part of Xamarin and not UWP...
Is there something like BindingContext in UWP?

             
             */


            
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                var filename = Path.Combine(App.FolderPath, 
                    $"{Path.GetRandomFileName()}.notes.txt");

            // Remove form here? to App.xaml.cs or from elsewhere



                // FolderPath not defined
                // Two pages both need to know about this variable
                // Put at top layer available for both
                // App.xaml.cs
                File.WriteAllText(filename, note.Text);
            } else
            {
                File.WriteAllText(note.Filename, note.Text);
            }

            // After save, what want to do

            // Navigation is built in of ContentPage
            await Navigation.PopAsync();
            // Call to this page pushed into stack
            // Now you do work, hit save, get out of the call and go back


            //await Navigation.Push();
            // Go to someplace else

            // When first load app
            // Mp put into call stack
            // Plus sign on UI
            // Then note onto call stack
            // Pop off of stack
            // We haven't seen push yet


            async void OnDeleteButtonClicked(object sender, EventArgs e)
            {
                // recall MainPage.xaml.cs

                // Which flie to delete?
                // filename is part of Node property

                // Get the BindingContext


                // Isntead of crash from (Note)

                // Prevent crashing form happening

                var note = BindingContext as Note;
                if (note == null)
                    return;

                if exists delete

                        await Navigation.PopAsync();
            }

        }
    }
}