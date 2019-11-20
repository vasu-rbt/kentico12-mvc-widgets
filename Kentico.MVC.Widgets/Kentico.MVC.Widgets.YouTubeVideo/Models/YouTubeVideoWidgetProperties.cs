using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Raybiztech.Kentico12.MVC.Widgets.YouTubeVideo
{
    public class YouTubeVideoWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Video URL")]
        [Required(ErrorMessage = "Please enter a value.")]
        public string VideoURL { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Width")]
        [Required(ErrorMessage = "Please enter a value.")]
        public string Width { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Height")]
        [Required(ErrorMessage = "Please enter a value.")]
        public string Height { get; set; }

        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 4, Label = "Related Video")]
        public bool IsShowRelatedVideos { get; set; }

        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 5, Label = "FullScreen")]
        public bool IsFullScreen { get; set; }

        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 6, Label = "Auto Play")]
        public bool IsAutoPlay { get; set; }
    }
}
