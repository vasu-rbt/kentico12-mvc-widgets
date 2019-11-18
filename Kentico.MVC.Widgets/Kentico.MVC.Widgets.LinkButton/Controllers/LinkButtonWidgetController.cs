using Kentico.PageBuilder.Web.Mvc;
using Kentico.MVC.Widgets.LinkButton;
using System.Web.Mvc;

[assembly: RegisterWidget("Kentico.MVC.Widgets.LinkButton", typeof(LinkButtonWidgetController), "Link Button widget", Description = "Set the text of link button", IconClass = "icon-w-link")]

namespace Kentico.MVC.Widgets.LinkButton
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
