using CMS.Search;
using System;
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
        public string PageNo { get; set; }
        public string PageSize { get; set; }
        public string Index { get; set; }
        public string SearchText { get; set; }
        public string GroupSize { get; set; }
        public int TotalResultCount { get; set; }
        public List<SelectListItem> Indexes { get; set; }
        public List<SearchResultItem> Items { get; set; }
        public Pager Pager { get; set; }

    }


    public class Pager
    {
        public Pager(int totalItems, int? page, int pageSize , int maxsize)
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


