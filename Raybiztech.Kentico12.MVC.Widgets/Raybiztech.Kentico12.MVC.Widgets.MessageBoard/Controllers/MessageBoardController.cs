using CMS.CustomTables;
using CMS.EventLog;
using CMS.Helpers;
using CMS.Membership;
using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.MessageBoard.Controllers;
using Raybiztech.Kentico12.MVC.Widgets.MessageBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.MessageBoard", typeof(MessageBoardController), "Message Board", Description = "Allows authenticated users to post comments and view other users comments.", IconClass = "icon-message")]
namespace Raybiztech.Kentico12.MVC.Widgets.MessageBoard.Controllers
{
    public class MessageBoardController : WidgetController<MessageBoardWidgetProperties>
    {
        /// <summary>
        /// This method gets properties and stores in model properties 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

            var properties = GetProperties();
            try
            {
                ViewData["CustomtableData"] = GetCustomTableData(properties.CustomTableClassName == null ? null : properties.CustomTableClassName);
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("MessageBoardController", "Index", ex);
            }

            return PartialView("Widgets/MessageBoardWidget/_MessageBoardWidget", new MessageBoardViewModel
            {
                CustomtableName = properties.CustomTableClassName,
                SubmitButtonText = properties.SubmitButtonText,
                CustomTableData = (List<MessageBoardViewModel>)ViewData["CustomtableData"]
            });
        }
        /// <summary>
        /// This method sets the values in custom table
        /// </summary>
        /// <param name="model">It contains comments related data</param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        public ActionResult Comments(MessageBoardViewModel model)
        {
            try
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
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("MessageBoardController", "Comments", ex);
            }
            return PartialView("Widgets/MessageBoardWidget/_MessageBoardWidget", model);
        }
        /// <summary>
        /// This method is used to get custom table data
        /// </summary>
        /// <param name="CustomTableClassName">Pass paramater name to get custom table data</param>
        /// <returns> custom table data </returns>
        public List<MessageBoardViewModel> GetCustomTableData(string CustomTableClassName)
        {
            List<MessageBoardViewModel> customTableData = null;
            var url = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (CustomTableClassName != null)
            {
                try
                {
                    customTableData = CustomTableItemProvider.GetItems(CustomTableClassName).WhereEquals("PageUrl", url).WhereEquals("IsApproved", true)
                          .Select(i => new MessageBoardViewModel()
                          {
                              UserFirstName = i.GetValue("UserFirstName", ""),
                              UserComments = i.GetValue("UserComments", ""),
                              IsApproved = i.GetValue("IsApproved", false),
                              ItemCreatedWhen = i.GetValue("ItemCreatedWhen", DateTimeHelper.ZERO_TIME)
                          }).ToList();
                }
                catch (Exception ex)
                {
                    EventLogProvider.LogException("MessageBoardController", "GetCustomTableData", ex);
                }
            }
            return customTableData;
        }
    }
}