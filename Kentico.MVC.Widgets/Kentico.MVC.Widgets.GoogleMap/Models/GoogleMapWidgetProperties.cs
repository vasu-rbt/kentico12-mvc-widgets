using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Kentico.MVC.Widgets.GoogleMap
{
   public class GoogleMapWidgetProperties: IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Latitude")]
        [Required(ErrorMessage = "Required")]
        public string Latitude { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Longitude")]
        [Required(ErrorMessage = "Required")]
        public string Longitude { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER,Order = 3,Label = "API key")]
        public string ApiKey { get; set; }
    }
}
