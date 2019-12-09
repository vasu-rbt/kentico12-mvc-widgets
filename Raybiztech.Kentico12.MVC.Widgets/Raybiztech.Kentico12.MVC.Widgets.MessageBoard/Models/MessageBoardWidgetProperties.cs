using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Raybiztech.Kentico12.MVC.Widgets.MessageBoard.Models
{
    public class MessageBoardWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "CustomTable ClassName*")]        
        [Required(ErrorMessage = "Please enter a value.")]
        public string CustomTableClassName { get; set; }
    }
}
