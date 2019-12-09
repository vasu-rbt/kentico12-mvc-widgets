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
    }
}
