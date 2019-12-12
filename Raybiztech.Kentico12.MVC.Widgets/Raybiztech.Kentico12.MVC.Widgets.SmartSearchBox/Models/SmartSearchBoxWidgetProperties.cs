using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox.Models
{
    public class SmartSearchBoxWidgetProperties : IWidgetProperties
    {

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 0, Label = "Search results page URL", Tooltip = "search/{ActionMethodName}")]
        [Required(ErrorMessage = ("Please enter search result URL"))]
        public string Text { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Watermark text", Tooltip = "The text entered here will be displayed in the search textbox if it is empty. It automatically disappears when a user starts entering their own input.")]
        public string PlaceHolder { get; set; }
        public string Index { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Search button text", Tooltip = "Sets the text caption of the search button.")]
        [Required(ErrorMessage = ("Please enter button name"))]
        public string ButtonName { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Search label text", Tooltip = "Sets the text displayed before the search textbox.")]
        public string LableName { get; set; }
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 4, Label = "Show search label", Tooltip = "Indicates if the label before the search box should be displayed.")]
        public bool ShowSearchLabel { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 5, Label = "Page Size")]
        [EditingComponentProperty("Size", 100)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = ("Please enter page size"))]
        public string PageSize { get; set; } = "10";
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 7, Label = " Group Size")]
        [EditingComponentProperty("Size", 100)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter Numbers Only")]
        [Required(ErrorMessage = ("Please enter Group Size"))]
        public string GroupSize { get; set; } = "4";

    }
}
