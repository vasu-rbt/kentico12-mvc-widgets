using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.LogonForm.Models
{
    public class LogonFormWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "RedirectUrl")]
        [Required(ErrorMessage = "Please Enter RedirectUrl")]
        public string RedirectUrl { get; set; } = "/";
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Button Text")]
        [Required(ErrorMessage = "Please Enter Butto Text")]
        public string ButtonText { get; set; } = "Sign In";
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Logon failure text")]
        [Required(ErrorMessage = "Please Enter Logon failure text")]
        public string LoginFailureText { get; set; } = "Sorry! The Email address/Password that you have entered is incorrect.";
    }
}
