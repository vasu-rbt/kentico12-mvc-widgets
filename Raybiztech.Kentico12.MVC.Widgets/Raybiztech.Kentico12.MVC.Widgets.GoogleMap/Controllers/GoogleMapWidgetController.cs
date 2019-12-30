using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.GoogleMap;
using System;
using System.Configuration;
using System.Web.Mvc;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.GoogleMap", typeof(GoogleMapWidgetController), "Google Map", Description = "Displays maps obtained from the Google maps service.", IconClass = "icon-map")]
namespace Raybiztech.Kentico12.MVC.Widgets.GoogleMap
{
    public class GoogleMapWidgetController: WidgetController<GoogleMapWidgetProperties>
    {
        /// <summary>
        /// This method is used to get the longitude and latitude from widget properties and pass to view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var properties = GetProperties();
            var viewModel = new GoogleMapWidgetViewModel
            {
                Latitude = properties.Latitude,
                Longitude = properties.Longitude,
                ApiKey = (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["GoogleMapsApiKey"])) ? ConfigurationManager.AppSettings["GoogleMapsApiKey"] : null
            };
            return PartialView("Widgets/GoogleMapWidget/_GoogleMapWidget", viewModel);
        }
    }
}
