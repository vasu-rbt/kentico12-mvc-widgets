﻿using CMS.Search;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox.Models
{
    public class SmartSearchWidgetViewModel
    {
        public string ResultsUrl { get; set; }
        public string PlaceHolder { get; set; }
        public string IndexName { get; set; }
        public string ButtonName { get; set; }
        public string LableName { get; set; }
        public bool LableMode { get; set; }
        public List<SelectListItem> Indexes { get; set; }
        public List<SearchResultItem> Items { get; set; }
    }
 
}