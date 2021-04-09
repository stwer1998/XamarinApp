using System.Collections.Generic;
using Xamarin.Forms;
using XamarinToDoApp.Models;

namespace XamarinToDoApp.Pages
{
    class LoginPage : ContentPage
    {
        private UserModel userModel;
        public LoginPage(UserModel userModel)
        {
            this.userModel = userModel;

            var generator = new GeneratorForm<LoginModel>(new LoginModel());

            var content = generator.Generate();

            generator.Notify += Button_Click;

            this.Content = content;
        }

        private void Button_Click(LoginModel loginModel) 
        {
            //userModel.LoginModel = loginModel;
            //userModel.Notes = new List<NoteModel> { new NoteModel {Name="name",Description="description",ImgUri= "https://imgd.aeplcdn.com/476x268/n/cw/ec/38904/mt-15-front-view.jpeg" },
            //new NoteModel {Name="name1",Description="description1",ImgUri= "https://imgd.aeplcdn.com/476x268/n/cw/ec/38904/mt-15-front-view.jpeg" },
            //new NoteModel {Name="name2",Description="description2",ImgUri= "https://imgd.aeplcdn.com/476x268/n/cw/ec/38904/mt-15-front-view.jpeg" }
            //};

        }
    }
}
