using System.ComponentModel.DataAnnotations;
using XamarinToDoApp.Attribute;

namespace XamarinToDoApp.Models
{
    public class LoginModel
    {
        [Required]
        [MinLength(3)]
        [XamarinFormComponent("Editor")]
        public string Login { get; set; }

        [Required]
        [MinLength(3)]
        [XamarinFormComponent("Entry", true)]
        public string Password { get; set; }
    }
}
