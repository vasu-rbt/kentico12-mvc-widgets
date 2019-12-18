using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.LazyLoading.Model.LazyLoadingWidget
{
    public class LazyLoadingWidgetProperties : IWidgetProperties
    {
        public string Pagetype { get; set; }

        [EditingComponent (PathSelector.IDENTIFIER, Order = 1)]
        [EditingComponentProperty (nameof (PathSelectorProperties.RootPath), "/")]
        public IList<PathSelectorItem> Path { get; set; }

        [Range (1, 100, ErrorMessage = "Please enter valid number")]
        [EditingComponent (IntInputComponent.IDENTIFIER, Order = 5, Label = "Page Size*", Tooltip = "Displays latest Top N records.")]
        public int Pagesize { get; set; } 

        [EditingComponent (TextInputComponent.IDENTIFIER, Order = 2, Label = "Main Heading", Tooltip = "Heading Text")]
        public string Heading { get; set; } 

        [Required (ErrorMessage = "Please enter columns information")]
        [EditingComponent (TextInputComponent.IDENTIFIER, Order = 3, Label = "Columns*", Tooltip = "Columns")]
        public string Columns { get; set; } 

        [Required (ErrorMessage = "Please enter OrderBy information")]
        [EditingComponent (TextInputComponent.IDENTIFIER, Order = 4, Label = "OrderBy*", Tooltip = "OrderBy")]
        public string OrderBy { get; set; }

        [EditingComponent (TextAreaComponent.IDENTIFIER, Order = 6, Label = "Custom View", Tooltip = "Customize View")]
        public string CustomView { get; set; } 
    }
}
