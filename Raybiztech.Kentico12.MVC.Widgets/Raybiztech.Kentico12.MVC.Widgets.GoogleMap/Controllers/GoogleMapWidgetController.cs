using Raybiztech.Kentico12.MVC.Widgets.GoogleMap;
using Kentico.PageBuilder.Web.Mvc;
using System.Web.Mvc;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.GoogleMap", typeof(GoogleMapWidgetController), "Google Map", Description = "It displays map obtained from the Google maps service using Latitude and Longitude", IconClass = "icon-map")]
namespace Raybiztech.Kentico12.MVC.Widgets.GoogleMap
{
    public class GoogleMapWidgetController: WidgetController<GoogleMapWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            var viewModel = new GoogleMapWidgetViewModel
            {
                Latitude=properties.Latitude,
                Longitude=properties.Longitude,
                ApiKey=properties.ApiKey
            };
            return PartialView("Widgets/GoogleMapWidget/_GoogleMapWidget", viewModel);
        }
    }
}
