using System;
using System.Collections.Generic;
using System.Text;
using XamarinToDoApp.Models;

namespace XamarinToDoApp
{
    public static class Store
    {
        public static LoginModel LoginModel { get; private set; }

        public static List<NoteModel> Notes { get; private set; }

        public static void Init(LoginModel loginModel, List<NoteModel> notes)
        {
            LoginModel = loginModel;

            Notes = notes;
        }
    }
}
