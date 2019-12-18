using CMS.DocumentEngine;
using CMS.EventLog;
using CMS.Localization;
using CMS.SiteProvider;
using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.LazyLoading.Controller;
using Raybiztech.Kentico12.MVC.Widgets.LazyLoading.Model.LazyLoadingWidget;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;

[assembly: RegisterWidget ("Raybiztech.Kentico12.MVC.Widgets.LazyLoading", typeof (LazyLoadingWidgetController), "Lazy Loading ", Description = "Displays list with View more and View Less button which can work as to view more data and remove data.", IconClass = "icon-l-list-article")]
namespace Raybiztech.Kentico12.MVC.Widgets.LazyLoading.Controller
{
   public class LazyLoadingWidgetController:WidgetController<LazyLoadingWidgetProperties>
    {
        public LazyLoadingWidgetController ( )
        {

        }
        public LazyLoadingWidgetController ( IWidgetPropertiesRetriever<LazyLoadingWidgetProperties> propertiesRetriever,
                                        ICurrentPageRetriever currentPageRetriever ) : base (propertiesRetriever, currentPageRetriever)
        {

        }
        public ActionResult Index( )
        {
            LazyLoadingWidgetViewModel model = new LazyLoadingWidgetViewModel ();
            var properties = GetProperties ();
            try
            {
                model.AvailableTypes = GetTreeData(properties.Pagetype);
                var selectedPagePath = properties.Path == null ? "/" : properties.Path.FirstOrDefault ().NodeAliasPath;

                if ((properties.Pagetype != null) && (properties.Pagesize != 0) && (properties.Columns != null) && (properties.OrderBy != null))
                {
                    model.PageType = properties.Pagetype;
                    model.Pagesize = Convert.ToInt32 (properties.Pagesize);
                    model.Heading = properties.Heading;
                    model.Columns = properties.Columns;
                    model.Orderby = properties.OrderBy;
                    model.Path = selectedPagePath;
                    model.PageNumber = 1;
                    model.ID = DateTime.Now.Ticks.ToString ();
                    model.Sitename = SiteContext.CurrentSiteName;
                    model.CustomView = properties.CustomView;
                    model.Documentculture = LocalizationContext.CurrentCulture.CultureCode;
                    model.DataCount = GetListCount ( properties.Pagetype, selectedPagePath);

                    return PartialView ("~/Views/Shared/Widgets/LazyLoadingWidget/_LazyLoadingWidget.cshtml", model);
                }
                else
                {
                    return PartialView ("~/Views/Shared/Widgets/LazyLoadingWidget/_LazyLoadingWidget.cshtml", model);
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException ("LazyLoadingWidgetController", "Index", ex);
                return null;
            }
        }
        public ActionResult LazyLoadingList ( string id, string pagenumber, string pagesize, string pagetype, string path, string columns, string orderby, string sitename, string Documentculture, string Customview )
        {
            path = path + "%";
            try
            {
                var model = GetListData (id, Convert.ToInt32 (pagenumber), Convert.ToInt32 (pagesize), pagetype, path, columns, orderby, sitename, Documentculture, Customview);
                return View ("~/Views/Shared/Widgets/LazyLoadingWidget/_LazyLoadingList.cshtml", model);
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException ("LazyLoadingWidgetController", "LazyLoadingList", ex);
                return null;
            }
        }
        private List<LazyLoadingWidgetViewModel> GetListData ( string id, int pagenumber, int pagesizes, string pagetype, string path, string columns, string orderby, string sitename, string Documentculture, string Customview )
        {
            var count = 0;
            if (pagenumber > 1)
            {
                count = (pagenumber - 1) * pagesizes;
            }
            var totalcount = pagenumber * pagesizes;
            List<LazyLoadingWidgetViewModel> list = new List<LazyLoadingWidgetViewModel> ();
            try
            {
                var result = DocumentHelper.GetDocuments
                    (sitename, path, Documentculture, false, pagetype, null, orderby, -1, true, totalcount, columns, new TreeProvider ());

                DataTable dtresult = result.Tables[0];
                foreach (DataRow row in dtresult.Rows.Cast<DataRow> ().Skip (count).Take (pagesizes).ToList ())
                {
                    LazyLoadingWidgetViewModel obj = new LazyLoadingWidgetViewModel ();
                    List<PageTypeData> item = GetItem (row);
                    obj.PageData = item;
                    obj.Columns = columns;
                    obj.ID = id;
                    obj.CustomView = Customview;
                    list.Add (obj);
                }
                return list;
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException ("LazyLoadingWidgetController", "GetListData", ex);
                return list;
            }
        }
        private static List<PageTypeData> GetItem ( DataRow dr )
        {
            List<PageTypeData> objResult = new List<PageTypeData> ();
            try
            {
                foreach (DataColumn column in dr.Table.Columns)
                {
                    PageTypeData obj = new PageTypeData ();
                    obj.ColumnName = column.ColumnName;
                    obj.ColumnValue = dr[column.ColumnName].ToString ();
                    objResult.Add (obj);
                }
                return objResult;
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException ("LazyLoadingWidgetController", "GetItem", ex);
                return objResult;
            }
        }
        private int GetListCount (string pagetype, string path)
        {
            try
            {
                var result = DocumentHelper.GetDocuments().WhereLike("NodeAliasPath", path + "%").WhereEquals("ClassName", pagetype).Count ();
                return result;
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException ("LazyLoadingTestWidgetController", "GetListCount", ex);
                return 0;
            }
        }
        public List<SelectListItem> GetTreeData ( string selectedPage )
        {
            var pagetypes = new List<SelectListItem> ();
            try
            {
                //Get All page types classes
                var types = DocumentTypeHelper.GetDocumentTypeClasses ().WhereEquals ("ClassIsContentOnly", true).TypedResult.ToList ();

                foreach (var type in types)
                {
                    pagetypes.Add (new SelectListItem ()
                    {
                        Text = type.ClassDisplayName,
                        Value = type.ClassName,
                        Selected = (type.ClassName == selectedPage)
                    });
                }
                return pagetypes;
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException ("LazyLoadingTestWidgetController", "GetTreeData", ex);
                return pagetypes;
            }
        }
    }
}
