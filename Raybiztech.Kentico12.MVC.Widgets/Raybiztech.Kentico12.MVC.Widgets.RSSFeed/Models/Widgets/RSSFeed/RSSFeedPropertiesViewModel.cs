using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Raybiztech.Kentico12.MVC.Widgets.RSSFeed
{
    public class RSSFeedPropertiesViewModel
    {
        public bool Visible { get; set; }
        public string ContentBefore { get; set; }
        public string ContentAfter { get; set; }
        public string NoDataText { get; set; }
        /// <summary>
        /// Common property for all RSS Feed data.This property data contains based on RSS Feed Url.
        /// </summary>
        public IEnumerable<XElement> RssData {get; set;}
    }
}