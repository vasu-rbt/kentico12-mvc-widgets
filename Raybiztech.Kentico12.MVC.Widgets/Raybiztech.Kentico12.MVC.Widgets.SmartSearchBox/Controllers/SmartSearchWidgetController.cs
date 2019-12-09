using CMS.EventLog;
using CMS.Membership;
using CMS.Search;
using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox.Controllers;
using Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox", typeof(SmartSearchWidgetController), "Smart search box", Description = "Provides a text box where users can enter search expressions. Searching redirects users to a page that displays the search results. The indexes used by the search are specified by the widget displaying the results. You can configure the Smart search box to display results instantly while users type the search text.", IconClass = "icon-magnifier")]
namespace Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox.Controllers
{
    public class SmartSearchWidgetController : WidgetController<SmartSearchBoxWidgetProperties>
    {
    
    public SmartSearchWidgetController()
        {

        }
        public SmartSearchWidgetController(IWidgetPropertiesRetriever<SmartSearchBoxWidgetProperties> propertiesRetriever,
                                        ICurrentPageRetriever currentPageRetriever) : base(propertiesRetriever, currentPageRetriever)
        {

        }
        public ActionResult Index()
        {
            SmartSearchWidgetViewModel model = new SmartSearchWidgetViewModel();
            try
            {
                var properties = GetProperties();
                model.ResultsUrl = properties.Text;
                model.PlaceHolder = properties.PlaceHolder;
                model.IndexName = properties.Index;
                model.ButtonName = properties.ButtonName;
                model.LableName = properties.LableName;
                model.LableMode = properties.ShowSearchLabel;
                model.PageNo = properties.Page;
                model.PageSize = properties.PageSize;
                model.TotalResultCount = properties.TotalResults;
                var indexes = SearchIndexInfoProvider.GetSearchIndexes();
                List<SelectListItem> addList = new List<SelectListItem>();
                foreach (SearchIndexInfo index in indexes)
                {
                    addList.Add(new SelectListItem() { Text = index.IndexCodeName, Value = index.IndexCodeName, Selected = (index.IndexCodeName == model.IndexName) });
                }
                model.Indexes = addList;
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("SmartSearchWidgetController", "Index", ex);

            }
            return PartialView("Widgets/SmartSearchBoxWidget/_SmartSearchBoxWidget", model);
        }

        [Route("Search/{searchresults}")]
        public ActionResult SearchResults(string searchtext, string page, string pagesize)
        {
            SearchResult searchResults = new SearchResult();
            SmartSearchWidgetViewModel dataList = new SmartSearchWidgetViewModel();
            try
            {
                SearchParameters searchParameters;
                int pageNo = page != null ? Convert.ToInt32(page) : 1;
                int pageSize = pagesize != null ? Convert.ToInt32(pagesize) : 12;
                int totalCount = TempData["count"] != null ? Convert.ToInt32(TempData["count"].ToString()) : 40;
                string Index = TempData["Index"] != null ? TempData["Index"].ToString() : "";
                dataList.PageSize = Convert.ToString(pageSize);
                dataList.SearchText = searchtext;
                TempData.Keep();
                dataList.PageNo =Convert.ToString(pageNo);
                dataList.PageSize = Convert.ToString(pageSize);

                searchParameters = SearchParameters.PrepareForPages(searchtext, new[] { Index }, pageNo, totalCount, MembershipContext.AuthenticatedUser);
                searchResults = SearchHelper.Search(searchParameters);
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("SmartSearchWidgetController", "SearchResults", ex);
            }
            dataList.Items = searchResults.Items;

            return View("Widgets/SmartSearchBoxWidget/_SmartSearchResultWidget", dataList);
        }

        public ActionResult PaginationSearchResults(string searchtext, string page, string pagesize)
        {
            SearchResult searchResults = new SearchResult();
            SmartSearchWidgetViewModel dataList = new SmartSearchWidgetViewModel();
            try
            {
                SearchParameters searchParameters;
                int pageNo = page != null ? Convert.ToInt32(page) : 1;
                int pageSize = pagesize != null ? Convert.ToInt32(pagesize) : 12;
                string Index = TempData["Index"] != null ? TempData["Index"].ToString() : "";
                dataList.PageSize = Convert.ToString(pageSize);
                TempData.Keep();
                dataList.PageNo = Convert.ToString(pageNo);
                dataList.PageNo = Convert.ToString(pageSize);
                dataList.SearchText = searchtext;
                searchParameters = SearchParameters.PrepareForPages(searchtext, new[] { Index }, pageNo, pageSize, MembershipContext.AuthenticatedUser);
                searchResults = SearchHelper.Search(searchParameters);
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("SmartSearchWidgetController", "SearchResults", ex);
            }
            dataList.Items = searchResults.Items;

            return PartialView("Widgets/SmartSearchBoxWidget/_PaginationView", dataList);
        }
        public ActionResult AssignValues(string index,string count)
        {
            bool status = false;
            try
            {
                TempData["Index"] = index;
                TempData["count"] = count;
                TempData.Keep();
                status = true;
            }
            catch(Exception ex)
            {

                EventLogProvider.LogException("SmartSearchWidgetController", "AssignValues", ex);
            }
       
            return Json(status, JsonRequestBehavior.AllowGet);

        }

    }
}
