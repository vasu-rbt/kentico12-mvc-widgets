using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.LinkButton;
using System.Web.Mvc;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.LinkButton", typeof(LinkButtonWidgetController), "Link Button widget", Description = "Set the text of link button", IconClass = "icon-w-link")]

namespace Raybiztech.Kentico12.MVC.Widgets.LinkButton
{
    public class LinkButtonWidgetController : WidgetController<LinkButtonWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            var viewModel = new LinkButtonWidgetViewModel
            {
                LinkText = properties.LinkText,
                LinkCSSClass = properties.LinkCSSClass,
                LinkURL = properties.LinkURL,
                LinkTarget=properties.LinkTarget
            };

            return PartialView("Widgets/LinkButtonWidget/_LinkButtonWidget", viewModel);
        }
    }
}
