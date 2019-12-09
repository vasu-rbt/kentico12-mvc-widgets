using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
namespace Raybiztech.Kentico12.MVC.Widgets.CurrentUser.Models
{
    public class CurrentUserWidgetProperties: IWidgetProperties
    {
        [EditingComponent(CheckBoxComponent.IDENTIFIER,Label = "Show user full name", Order =1)]
        public bool ShowUserFullName { get; set; } = true;
    }
}
