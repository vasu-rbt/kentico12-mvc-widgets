using System.Collections.Generic;
using System.Web.Mvc;

namespace Raybiztech.Kentico12.MVC.Widgets.LazyLoading.Model.LazyLoadingWidget
{
    public class LazyLoadingWidgetViewModel
    {
        #region WidgetProperties
        public string PageType { get; set; }
        public string Path { get; set; }
        public string Heading { get; set; }
        public string Columns { get; set; }
        public string Orderby { get; set; }
        public int PageNumber { get; set; }
        public int Pagesize { get; set; }
        public int Count { get; set; }
        public string Sitename { get; set; }
        public string Documentculture { get; set; }
        public int DataCount { get; set; }
        public List<PageTypeData> PageData { get; set; }
        public string ID { get; set; }
        public List<SelectListItem> AvailableTypes { get; internal set; }
        public string CustomView { get; set; }
        #endregion
    }
    public class PageTypeData
    {
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }
}
