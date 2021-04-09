using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using XamarinToDoApp.Models;

namespace XamarinToDoApp.ViewModels
{
    public class NoteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        NotesListViewModel lvm;

        public NoteModel Note { get; set; }

        public NoteViewModel()
        {
            Note = new NoteModel();
        }

        public NoteViewModel(NoteModel noteModel)
        {
            Note = noteModel;
        }

        public NotesListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public string Name
        {
            get { return Note.Name; }
            set
            {
                if (Note.Name != value)
                {
                    Note.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get { return Note.Description; }
            set
            {
                if (Note.Description != value)
                {
                    Note.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public bool IsValid
        {
            get
            {
                return ((!string.IsNullOrEmpty(Name.Trim())) ||
                    (!string.IsNullOrEmpty(Description.Trim())));
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
