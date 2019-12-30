using CMS.DocumentEngine;
using CMS.EventLog;
using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.ImageCard.Model;
using Raybiztech.Kentico12.MVC.Widgets.ImageCard.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.ImageCard", typeof(ImageCardWidgetController), "Image Card", Description = "Displays image, caption with a target link using pages", IconClass = "icon-l-cols-3")]
namespace Raybiztech.Kentico12.MVC.Widgets.ImageCard.Controller
{
    public class ImageCardWidgetController : WidgetController<ImageCardWidgetProperties>
    {
        #region method
        /// <summary>
        ///Get image card data using this method and return to partial view.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var properties = GetProperties();
            List<TreeNode> treeNodeData = new List<TreeNode>();
            string selectedPagePath = string.Empty;
            try
            {
                selectedPagePath = properties.Path == null ? "" : properties.Path.FirstOrDefault().NodeAliasPath;
                var page = DocumentHelper.GetDocuments()
                           .Columns("NodeAliasPath", "ClassName", "NodeOrder", "NodeId", "DocumentId")
                           .WhereEquals("NodeAliasPath", (!String.IsNullOrEmpty(selectedPagePath)) ? selectedPagePath : null).OrderBy(properties.OrderBy).ToList();
                var clss = page.Select(c => c.ClassName).FirstOrDefault();
                if (!string.IsNullOrEmpty(properties.ClassName))
                {
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
            return PartialView("Widgets/ImageCardWidget/_ImageCardWidget", new ImageCardWidgetViewModel
            {
                Path = treeNodeData,
                Visible = properties.Visible,
                SelectedValue = selectedPagePath
            });
        }
        #endregion
    }
}
