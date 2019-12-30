using CMS.DocumentEngine;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Raybiztech.Kentico12.MVC.Widgets.Repeater
{
    public class RepeaterPropertiesViewModel
    {
        /// <summary>
        /// Page Types purpose
        /// </summary>
        public List<SelectListItem> AvailableTypes { get; set; }
        /// <summary>
        /// Page type
        /// </summary>
        public string PageType { get; set; }
        /// <summary>
        /// Contains all data related to a particular page type
        /// </summary>
        public List<TreeNode> PageTypeData { get; set; }
        /// <summary>
        /// Widget is visible or not
        /// </summary>
        public bool Visible { get; set; }
        public string DataId { get; set; }
        /// <summary>
        /// Pagination is enable or not
        /// </summary>
        public bool PaginationEnable { get; set; }
        public string ContentBefore { get; set; } = "";
        public string ContentAfter { get; set; } = "";
        public string NoDataText { get; set; } = "";

        //Contains all pager information
        public Pager Pager { get; set; }
    }
    public class Pager
    {
        public Pager()
        {
        }
        /// <summary>
        /// Based on parameters generate a dynamic pagination data
        /// </summary>
        /// <param name="totalItems">Total items count</param>
        /// <param name="page">Page Number</param>
        /// <param name="pageSize">Page Size</param>
        /// <param name="maxsize">Group Size of Pages</param>
        public Pager(int totalItems, int? page, int pageSize, int maxsize)
        {
            // calculate total, start and end pages
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - ((int)Math.Ceiling((decimal)maxsize / 2));
            var endPage = currentPage + ((int)Math.Floor((decimal)maxsize / 2) - 1);
            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > maxsize)
                {
                    startPage = endPage - (maxsize - 1);
                }
            }
            TotalItems = totalItems;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}