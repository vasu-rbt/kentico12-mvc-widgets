using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox.Models
{
    public class SmartSearchBoxWidgetProperties : IWidgetProperties
    {

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Search Result Url",Tooltip ="search/{ActionMethodName}")]
        [Required(ErrorMessage = ("Please enter search result Url"))]
        public string Text { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "PlaceHolder Name")]
        public string PlaceHolder { get; set; }
        public string Index { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Button Text")]
        [Required(ErrorMessage = ("Please enter button name"))]
        public string ButtonName { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Page Size")]
        [EditingComponentProperty("Size", 100)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter Numbers Only")]
        public string PageSize { get; set; } = "12";
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Page")]
        [EditingComponentProperty("Size", 100)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter Numbers Only")]
        public string Page { get; set; } = "1";
    }
}
