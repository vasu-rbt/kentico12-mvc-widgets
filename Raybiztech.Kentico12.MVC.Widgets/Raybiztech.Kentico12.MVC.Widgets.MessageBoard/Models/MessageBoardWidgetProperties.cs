using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Raybiztech.Kentico12.MVC.Widgets.MessageBoard.Models
{
    public class MessageBoardWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Custom table Codename*", Tooltip = "Please enter comments custom table code name")]        
        [Required(ErrorMessage = "Please enter a value.")]
        public string CustomTableClassName { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Submit button text*", Tooltip="Enter submit button text")]
        [Required(ErrorMessage = "Please enter a value.")]
        public string SubmitButtonText { get; set; } = "Submit";
    }
}