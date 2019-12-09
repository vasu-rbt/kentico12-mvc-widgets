using CMS.CustomTables;
using CMS.Membership;
using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.MessageBoard.Controllers;
using Raybiztech.Kentico12.MVC.Widgets.MessageBoard.Models;
using System.Web.Mvc;
[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.MessageBoard", typeof(MessageBoardController), "MessageBoard Widget", Description = "Allows authenticated users to post comments", IconClass = "icon-message")]
namespace Raybiztech.Kentico12.MVC.Widgets.MessageBoard.Controllers
{
    public class MessageBoardController : WidgetController<MessageBoardWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            var customtableClassname = properties.CustomTableClassName;
            return PartialView("Widgets/MessageBoardWidget/_MessageBoardWidget", new MessageBoardViewModel { CustomtableName = customtableClassname });
        }
        [ValidateAntiForgeryToken]
        public ActionResult Comments(MessageBoardViewModel model)
        {          
            string comment = model.UserComments;
            UserInfo objUserInfo = UserInfoProvider.GetUserInfo(User.Identity.Name);
            string customTableClassName = model.CustomtableName;
            CustomTableItem newCustomTableItem = CustomTableItem.New(customTableClassName);
            newCustomTableItem.SetValue("UserComments", comment);
            newCustomTableItem.SetValue("UserFirstName", objUserInfo.GetValue("FirstName", "").ToString());
            newCustomTableItem.SetValue("UserLastName", objUserInfo.GetValue("LastName", "").ToString());
            newCustomTableItem.SetValue("UserEmail", objUserInfo.GetValue("Email", "").ToString());
            newCustomTableItem.SetValue("PageUrl", model.PageUrl);
            newCustomTableItem.Insert();
            return PartialView("Widgets/MessageBoardWidget/_MessageBoardWidget");
        }
    }
}