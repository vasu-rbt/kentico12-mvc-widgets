using Kentico.Membership;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CMS.Activities.Loggers;
using System.Web;
using CMS.EventLog;
using Raybiztech.Kentico12.MVC.Widgets.RegistrationForm;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.Registrationform", typeof(RegistrationFormController), "Registration Form", Description = "Displays a form that allows visitors to register on the website as new users.", IconClass = "icon-user")]
namespace Raybiztech.Kentico12.MVC.Widgets.RegistrationForm
{
    public class RegistrationFormController : WidgetController<RegistrationFormWidgetProperties>
    {
        #region Properties
        private readonly IMembershipActivityLogger mMembershipActivitiesLogger;
        /// <summary>
        /// Provides access to the Kentico.Membership.SignInManager instance.
        /// </summary>
        public SignInManager SignInManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<SignInManager>();
            }
        }
        /// <summary>
        /// Provides access to the Kentico.Membership.UserManager instance.
        /// </summary>
        public UserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UserManager>();
            }
        }
        public RegistrationFormController()
        {
        }
        #endregion
        public RegistrationFormController(IMembershipActivityLogger membershipActivitiesLogger)
        {
            mMembershipActivitiesLogger = membershipActivitiesLogger;
        }
        /// <summary>
        /// <param name="membershipActivitiesLogger">Using user login into site</param>
        /// <param name="propertiesRetriever">It will retrive the widget properties of current page</param>
        /// <param name="currentPageRetriever">It will retrive the current page information of widget</param>
        public RegistrationFormController(IMembershipActivityLogger membershipActivitiesLogger, IWidgetPropertiesRetriever<RegistrationFormWidgetProperties> propertiesRetriever,
           ICurrentPageRetriever currentPageRetriever) : base(propertiesRetriever, currentPageRetriever)
        {
            mMembershipActivitiesLogger = membershipActivitiesLogger;
        }
        #region Methods
        /// <summary>
        /// GET:Display Registration Form in widget
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            try
            {
                return View("~/Views/Shared/Widgets/RegistrationFormWidget/_RegistrationFormWidget.cshtml");
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("RegistrationFormController", "RegisterGet", ex);
                return null;
            }
        }
        /// <summary>
        /// Register the user details into a Users module
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Register(RegistrationFormViewModel model)
        {
            try
            {
                //Model invalid state it redirects to same view
                if (!ModelState.IsValid)
                {
                    return View("~/Views/Shared/Widgets/RegistrationFormWidget/_RegistrationFormWidget.cshtml");
                }
                // Prepares a new user entity using the posted registration data
                var user = new User
                {
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Enabled = true
                };
                // Attempts to create the user in the Kentico database
                var registerResult = new IdentityResult();
                //After taken user detaild it will give some response 
                registerResult = await UserManager.CreateAsync(user, model.Password);
                if (registerResult != null)
                {
                    //Already User exists..
                    if (!registerResult.Succeeded && ((string[])registerResult.Errors)[0] != null)
                    {
                        model.ValidationMessage = ((string[])registerResult.Errors)[0];
                        if (model.ValidationMessage != "")
                        {
                            model.ValidationMessage = "User '"+user.Email+"' already exists";
                        }
                        return Json(new { ErrorMessage = model.ValidationMessage, RegisterSuccess="" });
                    }
                    if (registerResult.Succeeded)
                    {
                        //After user register redirect to registration success page
                        model.ValidationMessage = "Registration Success..";
                        return Json(new { ErrorMessage = model.ValidationMessage});
                    }
                }
                else
                {
                    //Registration failed
                    model.ValidationMessage = "Registration Failed.....";
                    return Json(new { ErrorMessage = model.ValidationMessage });
                }
            }
            catch (Exception ex)
            {
                //Store the exception deatls into a event log module in kentico
                EventLogProvider.LogException("RegistrationFormController", "RegisterPost", ex);
            }
            return View("~/Views/Shared/Widgets/RegistrationFormWidget/_RegistrationFormWidget.cshtml", model);
        }
        #endregion
    }
}