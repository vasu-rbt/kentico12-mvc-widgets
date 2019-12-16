using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel.Models
{
    public class ImageVideoCarouselWidgetProperties:IWidgetProperties
    {
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 0, Label = "Visible")]
        public bool Visible { get; set; } = true;
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Image Video Carousel PageType", Tooltip = "Please select the Image Video Carousel PageType. Ex: DancingGoatMvc.ImageVideoCarousel.")]
        [Required(ErrorMessage = "Please enter an image video carousel page type class name")]
        public string ClassName { get; set; }
        [EditingComponent(PathSelector.IDENTIFIER, Order = 2, Label = "Path",Tooltip ="Please Select Image Video Carousel Path")]
        [EditingComponentProperty(nameof(PathSelectorProperties.RootPath), "/")]
        public IList<PathSelectorItem> Path { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "TopN", Tooltip = "Displays Top N records")]
        [Range(1, 100, ErrorMessage = "Please enter valid number")]
        public string TopN { get; set; } = "4";
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "OrderBy")]
        public string OrderBy { get; set; }
    }
}
