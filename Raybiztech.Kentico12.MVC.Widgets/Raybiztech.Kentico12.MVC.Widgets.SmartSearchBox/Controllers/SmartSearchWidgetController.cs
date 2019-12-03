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
                model.resultsUrl = properties.Text;
                model.PlaceHolder = properties.PlaceHolder;
                model.indexName = properties.Index;
                model.buttonName = properties.ButtonName;
                TempData["Index"] = properties.Index;
                TempData["Page"] = properties.Page;
                TempData["PageSize"] = properties.PageSize;
                var indexes = SearchIndexInfoProvider.GetSearchIndexes();
                List<SelectListItem> addList = new List<SelectListItem>();
                foreach (SearchIndexInfo index in indexes)
                {
                    addList.Add(new SelectListItem() { Text = index.IndexCodeName, Value = index.IndexCodeName });
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
        public ActionResult SearchResults(string searchtext)
        {
            SearchResult searchResults = new SearchResult();
            SmartSearchWidgetViewModel dataList = new SmartSearchWidgetViewModel();
            try
            {
                SearchParameters searchParameters;
                TempData.Keep("Index");
                TempData.Keep("PageSize");
                TempData.Keep("Page");
                int page = TempData["Page"] != null ? Convert.ToInt32(TempData["Page"].ToString()) : 12;
                int pageSize = TempData["PageSize"] != null ? Convert.ToInt32(TempData["PageSize"].ToString()) : 12;
                string Index = TempData["Index"] != null ? TempData["Index"].ToString() : "";
                searchParameters = SearchParameters.PrepareForPages(searchtext, new[] { Index }, page, pageSize, MembershipContext.AuthenticatedUser);
                searchResults = SearchHelper.Search(searchParameters);
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("SmartSearchWidgetController", "SearchResults", ex);
            }
            dataList.Items = searchResults.Items;
            return View("Widgets/SmartSearchBoxWidget/_SmartSearchResultWidget", dataList);
        }

    }
}
