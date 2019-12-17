using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace Raybiztech.Kentico12.MVC.Widgets.RegistrationForm
{
    public class RegistrationFormWidgetProperties : IWidgetProperties
    {
        #region ToolTips
        public const string visibleToolTip = "Indicates if the widget should displayed.";
        public const string titleToolTip = "It shows a title of a form.";
        public const string buttonTextToolTip = "Registration form button text.";
        public const string redirectUrlToolTip = "After register it redirect to this specific Url. Url pattern like this Ex:-/{ContollerName}/{ActionName}";
        #endregion
        #region Widget Properties
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Visible", Order = 0, Tooltip = visibleToolTip)]
        public bool Visible { get; set; } = true;
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Title", Order = 1, Tooltip = titleToolTip)]
        public string Title { get; set; } = "Registration Form";
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Button text", Order = 2, Tooltip = buttonTextToolTip)]
        public string ButtonText { get; set; } = "Register";
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Redirect Url", Order = 3, Tooltip = redirectUrlToolTip)]
        public string RedirectUrl { get; set; } = "/";
        #endregion
    }
}