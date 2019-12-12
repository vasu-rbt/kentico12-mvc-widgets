using CMS.DocumentEngine;
using System.Collections.Generic;
namespace Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel.Models
{
   public class ImageVideoCarouselWidgetViewModel
    {
        public List<TreeNode> Path { get; set; }
        public bool Visible { get; set; }
        public string Item { get; set; }
    }
}
