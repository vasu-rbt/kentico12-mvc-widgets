using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.CurrentUser.Controllers;
using Raybiztech.Kentico12.MVC.Widgets.CurrentUser.Models;
using System.Web.Mvc;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.CurrentUser", typeof(CurrentUserWidgetController), "Current user", Description = "Displays the user name and full name of the current user.", IconClass = "icon-user")]

namespace Raybiztech.Kentico12.MVC.Widgets.CurrentUser.Controllers
{
    public class CurrentUserWidgetController: WidgetController<CurrentUserWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            return PartialView("Widgets/CurrentUserWidget/_CurrentUser", new CurrentUserViewModel
            {
                ShowUserFullName = properties.ShowUserFullName
            });
        }
    }
}

