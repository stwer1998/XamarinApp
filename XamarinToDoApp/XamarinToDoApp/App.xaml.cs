using Plugin.LocalNotifications;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinToDoApp.Models;
using XamarinToDoApp.Views;

namespace XamarinToDoApp
{
    public partial class App : Application
    {
        private UserModel userModel { get; set; }
        FireBaseRepository FireBaseRepository { get; set; }
        public App()
        {
            InitializeComponent();

            #region Note with fireBase
            //Store.Init("sa");
            //FireBaseRepository = new FireBaseRepository();
            //FireBaseRepository.Init(new LoginModel {Login="login",Password="login" });
            //var page = new NotesListPage1();


            //var selected = page.notesListViewModel.Notes.FirstOrDefault(x => x.Note.Selected == true);
            //if (selected != null)
            //{
            //    page.notesListViewModel.SelectedNote = selected;
            //}
            #endregion
            var page = new MainPage();

            MainPage = new NavigationPage(page);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            //FireBaseRepository.SaveData();
        }

        protected override void OnResume()
        {
        }
    }
}
