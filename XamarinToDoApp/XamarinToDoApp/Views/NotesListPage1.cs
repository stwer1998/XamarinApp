using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinToDoApp.ViewModels;

namespace XamarinToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class NotesListPage1 : ContentPage
    {
        public NotesListViewModel notesListViewModel { get; private set; }
        public NotesListPage1()
        {
            notesListViewModel = new NotesListViewModel(Store.Notes) { Navigation = this.Navigation };

            var stackLayout = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            var createButton = new Button { Text = "Добавить", Command = notesListViewModel.CreateNoteCommand };

            var listView = new ListView() { ItemsSource=notesListViewModel.Notes, HasUnevenRows=true  };

            //var binding = new Binding { Source = notesListViewModel.SelectedNote, Mode = BindingMode.TwoWay };

            //listView.SelectedItem = binding;
            listView.ItemTapped += (s, e) => notesListViewModel.SelectedNote = (NoteViewModel)((ListView)s).SelectedItem;
            listView.ItemTemplate = new DataTemplate(() => 
            {
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");

                Label descriptionLabel = new Label();
                descriptionLabel.SetBinding(Label.TextProperty, "Description");

                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Vertical,
                        Children = { nameLabel, descriptionLabel }
                    }
                };
            });
            stackLayout.Children.Add(createButton);
            stackLayout.Children.Add(listView);

            Content = stackLayout;
        }
    }
}
