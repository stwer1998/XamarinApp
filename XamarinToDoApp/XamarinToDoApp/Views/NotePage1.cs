using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinToDoApp.ViewModels;

namespace XamarinToDoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class NotePage1 : ContentPage
    {
        public NoteViewModel ViewModel { get; private set; }
        public NotePage1(NoteViewModel vm)
        {
            ViewModel = vm;

            var stackLayout = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            var stackLayout1 = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            stackLayout1.Children.Add(new Label { Text = "Name" });

            var nameEntry = new Entry { Text = ViewModel.Name };
            Binding nameBinding = new Binding { Source = ViewModel, Path = "Name" };
            nameEntry.SetBinding(Entry.TextProperty, nameBinding);

            stackLayout1.Children.Add(nameEntry);
            var descriptionEntry = new Entry { Text = ViewModel.Description };
            var descriptionBinding = new Binding { Source = ViewModel, Path = "Description" };
            descriptionEntry.SetBinding(Entry.TextProperty, descriptionBinding);

            stackLayout1.Children.Add(new Label { Text = "Description" });
            stackLayout1.Children.Add(descriptionEntry);

            var stackLayout2 = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            stackLayout2.Children.Add(new Button { Text = "Добавить", Command = vm.ListViewModel.SaveNoteCommand, CommandParameter = ViewModel });
            stackLayout2.Children.Add(new Button { Text = "Удалить", Command = vm.ListViewModel.DeleteNoteCommand, CommandParameter = ViewModel });
            stackLayout2.Children.Add(new Button { Text = "Назад", Command = vm.ListViewModel.BackCommand });



            stackLayout.Children.Add(stackLayout1);
            stackLayout.Children.Add(stackLayout2);

            Content = stackLayout;
        }
    }
}
