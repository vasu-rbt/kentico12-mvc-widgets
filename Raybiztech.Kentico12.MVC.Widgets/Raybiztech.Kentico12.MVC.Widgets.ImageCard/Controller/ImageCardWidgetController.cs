using Kentico.PageBuilder.Web.Mvc;
using System.Web.Mvc;
using System.Linq;
using CMS.DocumentEngine;
using Raybiztech.Kentico12.MVC.Widgets.ImageCard.Model;
using Raybiztech.Kentico12.MVC.Widgets.ImageCard.Controller;
using System;
using System.Collections.Generic;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.ImageCard", typeof(ImageCardWidgetController), "Image Card", Description = "Displays image, caption with a target link using pages", IconClass = "icon-l-cols-3")]
namespace Raybiztech.Kentico12.MVC.Widgets.ImageCard.Controller
{
    public class ImageCardWidgetController : WidgetController<ImageCardWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();

            var selectedPagePath = properties.Path == null ? "" : properties.Path.FirstOrDefault().NodeAliasPath;
            var page = DocumentHelper.GetDocuments()
                       .Columns("NodeAliasPath", "ClassName", "NodeOrder", "NodeId","DocumentId")
                       .WhereEquals("NodeAliasPath", (!String.IsNullOrEmpty(selectedPagePath)) ? selectedPagePath : null).OrderBy(properties.OrderBy).ToList();
            var clss = page.Select(c => c.ClassName).FirstOrDefault();
            List<TreeNode> treeNodeData=new List<TreeNode>();
            if(!string.IsNullOrEmpty(properties.ClassName))
            {
                treeNodeData = DocumentHelper.GetDocuments(properties.ClassName)
                                 .Path(selectedPagePath, PathTypeEnum.Children)
                                 .NestingLevel(1)
                                 .OrderBy(properties.OrderBy)
                                 .Take(Convert.ToInt32(properties.TopN))
                                 .ToList();
            }
            return PartialView("Widgets/ImageCardWidget/_ImageCardWidget", new ImageCardWidgetViewModel
            {
                Path = treeNodeData,
                Visible = properties.Visible,
                SelectedValue= selectedPagePath
            });
        }
    }
}
