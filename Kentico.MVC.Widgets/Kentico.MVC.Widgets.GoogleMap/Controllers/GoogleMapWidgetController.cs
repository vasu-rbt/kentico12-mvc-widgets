using Kentico.MVC.Widgets.GoogleMap;
using Kentico.PageBuilder.Web.Mvc;
using System.Web.Mvc;
[assembly: RegisterWidget("Kentico.MVC.Widgets.GoogleMap", typeof(GoogleMapWidgetController), "Google Map widget", Description = "Displays maps obtained from the Google maps service.", IconClass = "icon-map")]
namespace Kentico.MVC.Widgets.GoogleMap
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
