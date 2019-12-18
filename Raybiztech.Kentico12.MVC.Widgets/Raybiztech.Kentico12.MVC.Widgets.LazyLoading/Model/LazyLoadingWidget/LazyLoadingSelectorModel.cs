using System.Collections.Generic;
using System.Web.Mvc;
namespace Raybiztech.Kentico12.MVC.Widgets.LazyLoading.Model.LazyLoadingWidget
{
    public class LazyLoadingSelectorModel
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public List<SelectListItem> Types { get; set; }
    }
}
