using System;
using System.Linq;
using System.Net;
using CMS.EventLog;
using System.Web.Mvc;
using System.Xml.Linq;
using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.RSSFeed;


[assembly: RegisterWidget("RSSFeedWidget", typeof(RSSFeedWidgetController), "RSS Feed", Description = "Displays the content of specified RSS Feed Url based on assigned views.", IconClass = "icon-w-rss-feed")]
namespace Raybiztech.Kentico12.MVC.Widgets.RSSFeed
{
    public class RSSFeedWidgetController : WidgetController<RSSFeedProperties>
    {
        #region Constructors
        public RSSFeedWidgetController()
        {
        }
        public RSSFeedWidgetController(IWidgetPropertiesRetriever<RSSFeedProperties> propertiesRetriever,
                                        ICurrentPageRetriever currentPageRetriever) : base(propertiesRetriever, currentPageRetriever)
        {
        }
        #endregion
        #region Methods
        /// <summary>
        /// Get RSS Feed data and display as a RSS Feed widget
        /// </summary>
        /// <returns>RSS Feed data</returns>
        public ActionResult Index()
        {
            RSSFeedPropertiesViewModel model = new RSSFeedPropertiesViewModel();
            WebClient wclient = new WebClient();
            try
            {
                var properties = GetProperties();
                bool fileExists;
                model.Visible = properties.Visible;
                model.NoDataText = properties.NoDataText;
                model.ContentBefore = properties.ContentBefore;
                model.ContentAfter = properties.ContetAfter;
                if (!string.IsNullOrEmpty(properties.RSSFeedUrl))
                {
                    string RSSData = wclient.DownloadString(properties.RSSFeedUrl);
                    XDocument xml = XDocument.Parse(RSSData);
                    model.RssData = xml.Descendants("item");
                }
                if (!properties.Visible || model.RssData.Count() == 0)
                {
                    return PartialView("Widgets/RSSFeed/_NoData", model);
                }
                fileExists = CheckViewFileExistingOrNot(properties.ViewName);
                if (fileExists)
                {
                    return PartialView(properties.ViewName, model);
                }
                else
                {
                    return PartialView("Widgets/RSSFeed/_ViewNotFound", model);
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("RSSFeedWidgetController", "Index", ex);
                return PartialView("Widgets/RSSFeed/_NoData", model);
            }
        }
        /// <summary>
        /// Check the View file is there or not
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns></returns>
        public bool CheckViewFileExistingOrNot(string fileName)
        {
            bool fileIsThere = false;
            var relativePath = "~/Views/Shared/" + fileName + ".cshtml";
            var absolutePath = HttpContext.Server.MapPath(relativePath);
            if (System.IO.File.Exists(absolutePath))
            {
                fileIsThere = true;
            }
            return fileIsThere;
        }
        #endregion
    }
}