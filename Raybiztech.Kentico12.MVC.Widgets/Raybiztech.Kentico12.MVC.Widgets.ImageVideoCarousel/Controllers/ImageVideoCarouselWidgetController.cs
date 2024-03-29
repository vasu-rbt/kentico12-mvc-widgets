﻿using CMS.DocumentEngine;
using CMS.EventLog;
using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel.Controllers;
using Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel", typeof(ImageVideoCarouselWidgetController), "Image Video Carousel", Description = "Displays image and video slides using pages", IconClass = "icon-w-content-slider")]
namespace Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel.Controllers
{
    public class ImageVideoCarouselWidgetController : WidgetController<ImageVideoCarouselWidgetProperties>
    {
        #region method
        /// <summary>
        ///Get carousel data using this method and display carousel widget
        /// </summary>
        /// <returns>Based on the model data it should display view</returns>
        public ActionResult Index()
        {
            //Get the current widget properties
            var properties = GetProperties();
            List<TreeNode> treeNodeData = new List<TreeNode>();
            string selectedPagePath = string.Empty;
            try
            {
                //Get selected path from widget properties
                selectedPagePath = properties.Path == null ? "" : properties.Path.FirstOrDefault().NodeAliasPath;
                var page = DocumentHelper.GetDocuments()
                           .Columns("NodeAliasPath", "ClassName", "DocumentId", "NodeOrder", "NodeId")
                           .WhereEquals("NodeAliasPath", (!String.IsNullOrEmpty(selectedPagePath)) ? selectedPagePath : null).ToList();
                var className = page.Select(c => c.ClassName).FirstOrDefault();
                if (!string.IsNullOrEmpty(properties.ClassName))
                {
                    //Get TreeNode data based on the partcular class name
                    treeNodeData = DocumentHelper.GetDocuments(properties.ClassName)
                                     .Path(selectedPagePath, PathTypeEnum.Children)
                                     .NestingLevel(1)
                                     .OrderBy(properties.OrderBy)
                                     .Take(Convert.ToInt32(properties.TopN))
                                     .ToList();
                }
            }
            catch (Exception ex)
            {
                EventLogProvider.LogException("ImageVideoCarouselWidget", "Index", ex);
            }
            return PartialView("Widgets/CarouselWidget/_ImageVideoCarouselWidget", new ImageVideoCarouselWidgetViewModel
            {
                Path = treeNodeData.ToList(),
                Visible = properties.Visible,
                Item = selectedPagePath
            });
        }
        #endregion
    }
}