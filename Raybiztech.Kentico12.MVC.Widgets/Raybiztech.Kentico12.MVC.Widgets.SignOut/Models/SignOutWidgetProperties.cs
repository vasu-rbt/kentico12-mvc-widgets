using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.SignOut.Models
{
    public class SignOutWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Button Text *", Tooltip ="Sets the text caption of the sign out button.")]
        [Required(ErrorMessage = "Please Enter Button Text")]
        public string ButtonText { get; set; } = "Sign Out";
    }
}
