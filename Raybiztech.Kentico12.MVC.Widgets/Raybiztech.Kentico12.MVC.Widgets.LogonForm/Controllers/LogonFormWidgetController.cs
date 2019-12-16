using Kentico.Membership;
using Raybiztech.Kentico12.MVC.Widgets.LogonForm.Models;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Raybiztech.Kentico12.MVC.Widgets.LogonForm.Controllers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.LogonForm", typeof(LogonFormWidgetController), "Logon form", Description = "Displays a form that allows users to log into the website. Authentication requires a valid user name and password.", IconClass = "icon-user")]

namespace Raybiztech.Kentico12.MVC.Widgets.LogonForm.Controllers
{
    public class LogonFormWidgetController : WidgetController<LogonFormWidgetProperties>
    {
        /// <summary>
        /// get the user info from kentico membership
        /// </summary>
        public UserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UserManager>();
            }
        }
        /// <summary>
        /// this method is used sigout when user click on logout
        /// </summary>
        public SignInManager SignInManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<SignInManager>();
            }
        }
        /// <summary>
        /// this action method used to display Logon Form as widget 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var properties = GetProperties();

            return PartialView("Widgets/LogonFormWidget/_LogonFormWidget",new LogonFormWidgetViewModel {
                RedirectUrl=properties.RedirectUrl,
                ButtonText=properties.ButtonText,
                LoginFailureText=properties.LoginFailureText
            });
        }
        public async Task<ActionResult> Login(LogonFormWidgetViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("Widgets/LogonFormWidget/_LogonFormWidget", model);
            }
            var signInResult = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (signInResult == SignInStatus.Success)
            {
                return Json(new { success = true });
            }
            if (signInResult == SignInStatus.Failure)
            {

                return Json(new { success = false });
            }
            return PartialView("Widgets/LoginWidget/_LogonFormWidget");
        }
    }
}
