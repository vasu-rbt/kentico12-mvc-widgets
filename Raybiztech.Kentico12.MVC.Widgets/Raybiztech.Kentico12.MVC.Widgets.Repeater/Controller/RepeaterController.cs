using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Web.Mvc;
using CMS.EventLog;
using Raybiztech.Kentico12.MVC.Widgets.Repeater;
using System.Linq;
using System.Collections.Generic;
using CMS.DocumentEngine;
using CMS.Localization;
using CMS.SiteProvider;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.Repeater", typeof(RepeaterController), "Repeater", Description = "The Repeater widget displays the content of specified pages based on assigned views.", IconClass = "icon-w-repeater")]
namespace Raybiztech.Kentico12.MVC.Widgets.Repeater
{
    public class RepeaterController : WidgetController<RepeaterProperties>
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public RepeaterController()
        {
        }
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="propertiesRetriever">It fetch the widget properties.</param>
        /// <param name="currentPageRetriever">It get the current page information of widget.</param>
        public RepeaterController(IWidgetPropertiesRetriever<RepeaterProperties> propertiesRetriever,
                                        ICurrentPageRetriever currentPageRetriever) : base(propertiesRetriever, currentPageRetriever)
        {
        }
        #endregion
        #region Methods
        /// <summary>
        /// Display repeater data in a widget
        /// </summary>
        /// <returns>Based on the model data it should render particular partial view</returns>
        public ActionResult Index()
        {
            List<SelectListItem> pagetypes = new List<SelectListItem>();
            string pageTypeName = "";
            string noDataText = "";
            try
            {
                string dataId = DateTime.Now.Ticks.ToString();
                int page = 1;
                bool fileExists;
                List<TreeNode> pages;
                var properties = GetProperties();
                //Set the widget properties data based on dynamic id
                TempData["CurrentData_" + dataId] = properties;
                TempData.Keep();
                noDataText = properties.NoDataText;
                string selectedPath = properties.Path == null ? "/" : properties.Path.FirstOrDefault().NodeAliasPath;
                pageTypeName = properties.PageType == null ? "" : properties.PageType;
                //Get all page types classes
                pagetypes = GetTreeData(properties.PageType);
                //Create object for Pager class
                Pager pager = new Pager();
                if (properties.PaginationEnable)
                {
                    //Get total records of a particluar page type
                    var totalItemsCount = GetTotalPagesCount(properties.PageType, selectedPath, properties.TopN, properties.Columns, properties.WhereCondition, properties.OrderBy, properties.MaximumNestingLevel, properties.SelectOnlyPublished);
                    //Based on parameters generate a dynamic pagination data
                    pager = new Pager(totalItemsCount, page, int.Parse(properties.PageSize == null ? "4" : properties.PageSize), int.Parse(properties.GroupSize == null ? "3" : properties.GroupSize));
                    //Get particular page type data based on wiget properties
                    pages = GetParticularTreeNodeData(properties.PageType, selectedPath, properties.TopN, properties.Columns, properties.WhereCondition, properties.OrderBy, properties.MaximumNestingLevel, pager.PageSize, pager.CurrentPage, properties.PaginationEnable, properties.SelectOnlyPublished);
                }
                else
                {
                    //Get pagetype data based on parameters
                    pages = GetParticularTreeNodeData(properties.PageType, selectedPath, properties.TopN, properties.Columns, properties.WhereCondition, properties.OrderBy, properties.MaximumNestingLevel, 0, 0, properties.PaginationEnable, properties.SelectOnlyPublished);
                }
                if (!properties.Visible)
                {
                    return PartialView("Widgets/Repeater/_NoData", new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = properties.PageType, PageTypeData = pages, Visible = properties.Visible, NoDataText = noDataText });
                }
                if (pages.Count == 0)
                {
                    return PartialView("Widgets/Repeater/_NoData", new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = properties.PageType, PageTypeData = pages, Visible = properties.Visible, NoDataText = noDataText });
                }
                //Here check the view file name is there or not in the current project.
                fileExists = CheckViewFileExistingOrNot(properties.ViewName);
                if (fileExists)
                {
                    return PartialView(properties.ViewName, new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = properties.PageType, PageTypeData = pages, ContentBefore = properties.ContentBefore, ContentAfter = properties.ContetAfter, PaginationEnable = properties.PaginationEnable, DataId = dataId, Pager = pager });
                }
                else
                {
                    return PartialView("Widgets/Repeater/_ViewNotFound", new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = properties.PageType, PageTypeData = pages });
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("RepeaterController", "Index", ex);
                return PartialView("Widgets/Repeater/_NoData", new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = pageTypeName, Visible = true, NoDataText = noDataText });
            }
        }
        /// <summary>
        /// This is pagination specific method. It gets current page data.
        /// </summary>
        /// <param name="page">Current page number</param>
        /// <param name="dataID">Dynamic Id</param>
        /// <returns>Returns current pagetype data based on parameters</returns>
        public ActionResult RepeaterWithPagination(int? page, string dataID = "")
        {
            List<SelectListItem> pagetypes = new List<SelectListItem>();
            string pageTypeName = "";
            string noDataText = "";
            try
            {
                RepeaterProperties properties = new RepeaterProperties();
                //Get the widget properties data based on dynamic id
                if (TempData["CurrentData_" + dataID] != null)
                {
                    properties = (RepeaterProperties)TempData["CurrentData_" + dataID];
                    TempData.Keep();
                }
                bool fileExists;
                noDataText = properties.NoDataText;
                string selectedPath = properties.Path == null ? "/" : properties.Path.FirstOrDefault().NodeAliasPath;
                pageTypeName = properties.PageType == null ? "" : properties.PageType;
                //Get All page types classes
                pagetypes = GetTreeData(properties.PageType);
                List<TreeNode> pages;
                Pager pager = new Pager();
                if (properties.PaginationEnable)
                {
                    //Get total records of a particluar page type
                    var totalItemsCount = GetTotalPagesCount(properties.PageType, selectedPath, properties.TopN, properties.Columns, properties.WhereCondition, properties.OrderBy, properties.MaximumNestingLevel, properties.SelectOnlyPublished);
                    //Based on parameters generate a dynamic pagination data
                    pager = new Pager(totalItemsCount, page, int.Parse(properties.PageSize == null ? "4" : properties.PageSize), int.Parse(properties.GroupSize == null ? "3" : properties.GroupSize));
                    //Get particular page type data based on wiget properties
                    pages = GetParticularTreeNodeData(properties.PageType, selectedPath, properties.TopN, properties.Columns, properties.WhereCondition, properties.OrderBy, properties.MaximumNestingLevel, pager.PageSize, pager.CurrentPage, properties.PaginationEnable, properties.SelectOnlyPublished);
                }
                else
                {
                    pages = GetParticularTreeNodeData(properties.PageType, selectedPath, properties.TopN, properties.Columns, properties.WhereCondition, properties.OrderBy, properties.MaximumNestingLevel, 0, 0, properties.PaginationEnable, properties.SelectOnlyPublished);
                }
                if (!properties.Visible)
                {
                    return PartialView("Widgets/Repeater/_NoData", new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = properties.PageType, PageTypeData = pages, Visible = properties.Visible, NoDataText = noDataText });
                }
                if (pages.Count == 0)
                {
                    return PartialView("Widgets/Repeater/_NoData", new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = properties.PageType, PageTypeData = pages, Visible = properties.Visible, NoDataText = noDataText });
                }
                fileExists = CheckViewFileExistingOrNot(properties.ViewName);
                if (fileExists)
                {
                    return PartialView(properties.ViewName, new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = properties.PageType, PageTypeData = pages, ContentBefore = properties.ContentBefore, ContentAfter = properties.ContetAfter, PaginationEnable = properties.PaginationEnable, DataId = dataID, Pager = pager });
                }
                else
                {
                    return PartialView("Widgets/Repeater/_ViewNotFound", new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = properties.PageType, PageTypeData = pages });
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("RepeaterController", "RepeaterWithPagination", ex);
                return PartialView("Widgets/Repeater/_NoData", new RepeaterPropertiesViewModel { AvailableTypes = pagetypes, PageType = pageTypeName, Visible = true, NoDataText = noDataText });
            }
        }
        /// <summary>
        /// Check the View file is there or not in the current project.
        /// </summary>
        /// <param name="fileName">View file name with path</param>
        /// <returns>Checks the view name existing or not in the current project. If the file is there true/false.</returns>
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
        /// <summary>
        /// Get all page types data
        /// </summary>
        /// <param name="selectedPage">Selected page type</param>
        /// <returns>All page types classes of particular site</returns>
        public List<SelectListItem> GetTreeData(string selectedPage)
        {
            //Get All page types classes
            var types = DocumentTypeHelper.GetDocumentTypeClasses().WhereEquals("ClassIsContentOnly", true).TypedResult.ToList();
            var pagetypes = new List<SelectListItem>();
            foreach (var type in types)
            {
                pagetypes.Add(new SelectListItem()
                {
                    Text = type.ClassDisplayName,
                    Value = type.ClassName,
                    Selected = (type.ClassName == selectedPage)
                });
            }
            return pagetypes;
        }
        /// <summary>
        /// Get total records count based on condition for pagination total pages purpose
        /// </summary>
        /// <param name="className">Selected pagetype name</param>
        /// <param name="selectedPath"></param>
        /// <param name="count">Selected topN records value</param>
        /// <param name="columns">Selected columns</param>
        /// <param name="whereCondition">Specific where condition</param>
        /// <param name="orderBy">Order by filter data</param>
        /// <param name="maxNestingLevel">Selected nesting Level</param>
        /// <param name="selectOnlyPublish">If select only publish true/false</param>
        /// <returns>Count of total records of a particular page type</returns>
        public int GetTotalPagesCount(string className, string selectedPath, string count, string columns, string whereCondition, string orderBy, string maxNestingLevel, bool selectOnlyPublish)
        {
            TreeProvider tree = new TreeProvider();
            int totalItemsCount = 0;
            if (DocumentTypeHelper.GetDocumentTypeClasses().WhereEquals("ClassName", className).TypedResult.Count() >= 1)
            {
                count = count == null ? "0" : count;
                int maximumNestingLevel = int.Parse(maxNestingLevel == null ? "-1" : maxNestingLevel);
                columns = columns == null ? "" : columns;
                whereCondition = whereCondition == null ? "" : whereCondition;
                orderBy = orderBy == null ? "" : orderBy;
                string cultureCode = LocalizationContext.CurrentCulture.CultureCode == null ? "en-Us" : LocalizationContext.CurrentCulture.CultureCode;
                string siteName = SiteContext.CurrentSiteName == null ? "" : SiteContext.CurrentSiteName;
                selectedPath = selectedPath + "%";
                totalItemsCount = DocumentHelper.GetDocuments(siteName, selectedPath, cultureCode, false, className, whereCondition, orderBy, maximumNestingLevel, selectOnlyPublish, int.Parse(count), columns, tree).Count();
            }
            return totalItemsCount;
        }
        /// <summary>
        /// Get particular pagetye data based on widget properties
        /// </summary>
        /// <param name="className">Current page type name</param>
        /// <param name="selectedPath">Selected page path</param>
        /// <param name="count">Number of records display</param>
        /// <param name="columns">Selected columns</param>
        /// <param name="whereCondition">Where condition filter data</param>
        /// <param name="orderBy">Order by filter data</param>
        /// <param name="maxNestingLevel">Selected nesting Level</param>
        /// <param name="pageSize">Current page size in pagination</param>
        /// <param name="pageNumber">Current page number</param>
        /// <param name="paginationEnable">If pagination enalbe true/false</param>
        /// <param name="selectOnlyPublish">If select only publish true/false</param>
        /// <returns>Particular pagetype data based on these parameters</returns>
        public List<TreeNode> GetParticularTreeNodeData(string className, string selectedPath, string count, string columns, string whereCondition, string orderBy, string maxNestingLevel, int pageSize, int pageNumber, bool paginationEnable, bool selectOnlyPublish)
        {
            List<TreeNode> pages = new List<TreeNode>();
            if (DocumentTypeHelper.GetDocumentTypeClasses().WhereEquals("ClassName", className).TypedResult.Count() >= 1)
            {
                //Create object for TreeProvider
                TreeProvider tree = new TreeProvider();
                count = count == null ? "0" : count;
                int maximumNestingLevel = int.Parse(maxNestingLevel == null ? "-1" : maxNestingLevel);
                columns = columns == null ? "" : columns;
                whereCondition = whereCondition == null ? "" : whereCondition;
                orderBy = orderBy == null ? "" : orderBy;
                //Get current culture code
                string cultureCode = LocalizationContext.CurrentCulture.CultureCode == null ? "en-Us" : LocalizationContext.CurrentCulture.CultureCode;
                //Get current sitename
                string siteName = SiteContext.CurrentSiteName == null ? "" : SiteContext.CurrentSiteName;
                selectedPath = selectedPath + "%";
                if (paginationEnable)
                {
                    //Fetch the data based on the current page size
                    pages = DocumentHelper.GetDocuments(siteName, selectedPath, cultureCode, false, className, whereCondition, orderBy, maximumNestingLevel, selectOnlyPublish, int.Parse(count), columns, tree).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
                }
                else
                {
                    pages = DocumentHelper.GetDocuments(siteName, selectedPath, cultureCode, false, className, whereCondition, orderBy, maximumNestingLevel, selectOnlyPublish, int.Parse(count), columns, tree).ToList();
                }
            }
            return pages;
        }
        #endregion
    }
}