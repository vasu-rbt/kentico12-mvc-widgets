using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.LogonForm.Models
{
    public class LogonFormWidgetViewModel
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [DisplayName("Password")]
        public string Password { get; set; }

        public string RedirectUrl { get; set; }
        public string ButtonText { get; set; }
        public string LoginFailureText { get; set; }
    }
}
