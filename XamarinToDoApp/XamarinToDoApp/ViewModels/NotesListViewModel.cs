using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinToDoApp.Models;
using XamarinToDoApp.Views;

namespace XamarinToDoApp.ViewModels
{
    public class NotesListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NoteViewModel> Notes { get; set; }

        public ICommand CreateNoteCommand { protected set; get; }
        public ICommand DeleteNoteCommand { protected set; get; }
        public ICommand SaveNoteCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }
        
        NoteViewModel selectedNote;

        public INavigation Navigation { get; set; }

        public NotesListViewModel()
        {
            Notes = new ObservableCollection<NoteViewModel>();
            CreateNoteCommand = new Command(CreateNote);
            DeleteNoteCommand = new Command(DeleteNote);
            SaveNoteCommand = new Command(SaveNote);
            BackCommand = new Command(Back);
        }


        public NotesListViewModel(List<NoteModel> noteModels)
        {
            Notes = new ObservableCollection<NoteViewModel>();
            CreateNoteCommand = new Command(CreateNote);
            DeleteNoteCommand = new Command(DeleteNote);
            SaveNoteCommand = new Command(SaveNote);
            BackCommand = new Command(Back);

            foreach (var item in noteModels)
            {
                Notes.Add(new NoteViewModel(item)
                {
                    ListViewModel = this,                    
                });
            }
        }

        private void SaveNote(object noteObject)
        {
            NoteViewModel note = noteObject as NoteViewModel;
            if (note != null && note.IsValid && !Notes.Contains(note))
            {
                Notes.Add(note);
            }
            Back();
        }

        private void Back()
        {
            if (selectedNote != null)
            {
                selectedNote.Note.Selected = false;
                selectedNote = null;
            }
            Navigation.PopAsync();
        }

        private void DeleteNote(object noteObject)
        {
            NoteViewModel note = noteObject as NoteViewModel;
            if (note != null)
            {
                Store.Notes.Remove(note.Note);
                Notes.Remove(note);
            }
            Back();
        }

        private void CreateNote()
        {
            var note = new NoteModel();
            Store.Notes.Add(note);
            Navigation.PushAsync(new NotePage1(new NoteViewModel(note) {ListViewModel = this }));
        }

        public NoteViewModel SelectedNote
        {
            get { return selectedNote; }
            set
            {
                //if (selectedNote != value)
                {
                    //NoteViewModel tempNote = value;
                    selectedNote = value;
                    selectedNote.Note.Selected = true;
                    OnPropertyChanged("SelectedNote");
                    Navigation.PushAsync(new NotePage1(selectedNote));
                }
            }
        }

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
