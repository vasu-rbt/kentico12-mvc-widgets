using System.Collections.Generic;
using System.Web.Mvc;

namespace Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox.Models
{
    public class IndexWidgetPropertes
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
        public List<SelectListItem> Types { get; set; }
    }
}
