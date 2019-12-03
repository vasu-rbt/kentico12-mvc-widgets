using CMS.Search;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox.Models
{
    public class SmartSearchWidgetViewModel
    {
        public string resultsUrl { get; set; }
        public string PlaceHolder { get; set; }
        public string indexName { get; set; }
        public string buttonName { get; set; }
        public List<SelectListItem> Indexes { get; set; }
        public List<SearchResultItem> Items { get; set; }
    }
 
}
