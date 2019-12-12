using CMS.DocumentEngine;
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
        public ActionResult Index()
        {
            var properties = GetProperties();
            var selectedPagePath = properties.Path == null ? null : properties.Path.FirstOrDefault().NodeAliasPath;
            var page = DocumentHelper.GetDocuments()
                       .Columns("NodeAliasPath", "ClassName","DocumentId","NodeOrder","NodeId")
                       .WhereEquals("NodeAliasPath", (!String.IsNullOrEmpty(selectedPagePath)) ? selectedPagePath : null).ToList();
            var className = page.Select(c => c.ClassName).FirstOrDefault();
            List<TreeNode> treeNodeData = new List<TreeNode>();
            if (!string.IsNullOrEmpty(properties.ClassName))
            {
                treeNodeData = DocumentHelper.GetDocuments(properties.ClassName)
                                 .Path(selectedPagePath, PathTypeEnum.Children)
                                 .NestingLevel(1)
                                 .OrderBy(properties.OrderBy)
                                 .Take(Convert.ToInt32(properties.TopN))
                                 .ToList();
            }
            return PartialView("Widgets/CarouselWidget/_ImageVideoCarouselWidget", new ImageVideoCarouselWidgetViewModel
            {
                Path = treeNodeData.ToList(),
                Visible = properties.Visible
            });
        }
    }
}