﻿using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Raybiztech.Kentico12.MVC.Widgets.GoogleMap
{
   public class GoogleMapWidgetProperties: IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Latitude")]
        [Required(ErrorMessage = "Please enter Latitude.")]
        public string Latitude { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Longitude")]
        [Required(ErrorMessage = "Please enter Logitude.")]
        public string Longitude { get; set; }
    }
}
