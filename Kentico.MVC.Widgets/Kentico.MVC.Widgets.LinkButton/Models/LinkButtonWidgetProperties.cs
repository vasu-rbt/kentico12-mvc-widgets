using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace Kentico.MVC.Widgets.LinkButton
{
    public class LinkButtonWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order=1, Label = "Link text")]
        public string LinkText { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 2, Label = "Link CSS class")]
        public string LinkCSSClass { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 3, Label = "Link URL")]
        public string LinkURL { get; set; }

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 4, Label = "Link target")]
        public string LinkTarget { get; set; }
    }
}
