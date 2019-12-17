using CMS.DocumentEngine;
using System.Collections.Generic;
namespace Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel.Models
{
   public class ImageVideoCarouselWidgetViewModel
    {
        /// <summary>
        /// Contains TreeNode Data
        /// </summary>
        public List<TreeNode> Path { get; set; }
        public bool Visible { get; set; }
        public string Item { get; set; }
    }
}
