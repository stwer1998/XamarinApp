using Firebase.Database;
using Newtonsoft.Json;
using Plugin.LocalNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using XamarinToDoApp.Models;

namespace XamarinToDoApp
{
    public class FireBaseRepository
    {
        FirebaseClient firebase;

        public FireBaseRepository()
        {
            firebase = new FirebaseClient("https://xamarinnote-555d1-default-rtdb.europe-west1.firebasedatabase.app/");
                                         //https://xamarinnote-555d1-default-rtdb.europe-west1.firebasedatabase.app/
        }

        public void Some()
        {
            
        }

        public void Init(LoginModel loginModel)
        {
            CrossLocalNotifications.Current.Show($"Добрый день", $"{loginModel.Login} {loginModel.Password}");
            var data = firebase.Child($"{loginModel.Login}1{loginModel.Password}")
                                .OnceSingleAsync<List<NoteModel>>()
                                .Result;

            if (data == null || data.Count < 1)
            {
                Store.Init(loginModel, new List<NoteModel>());
            }
            else
            {
                Store.Init(loginModel, data);
            }
        }

        public void SaveData() 
        {
            var data = JsonConvert.SerializeObject(Store.Notes);
            firebase.Child($"{Store.LoginModel.Login}1{Store.LoginModel.Password}").PutAsync(data).Wait();//перезапись child
        }



        private class Some1
        {
            public string Key { get; set; }
            public List<NoteModel> Object { get; set; }
        }
    }
}
