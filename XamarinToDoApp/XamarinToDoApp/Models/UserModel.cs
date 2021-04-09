using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinToDoApp.Models
{
    public class UserModel
    {
        public LoginModel LoginModel { get; set; }

        public List<string> Notes { get; set; }

        public StateModel State { get; set; }
    }
}
