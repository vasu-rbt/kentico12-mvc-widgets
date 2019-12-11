using CMS.DocumentEngine;
using Kentico.Components.Web.Mvc.FormComponents;
using System.Collections.Generic;

namespace Raybiztech.Kentico12.MVC.Widgets.ImageCard.Model
{
    public class ImageCardWidgetViewModel
    {
        public List<TreeNode> Path { get; set; }
        public bool Visible { get; set; }
    }
}
