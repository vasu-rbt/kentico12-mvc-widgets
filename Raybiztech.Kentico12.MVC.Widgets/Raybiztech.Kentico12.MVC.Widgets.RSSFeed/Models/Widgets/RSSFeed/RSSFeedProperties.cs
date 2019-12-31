using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.RSSFeed
{
    public class RSSFeedProperties: IWidgetProperties
    {
        #region Tooltips
        public const string visibleToolTip = "Indicates if the widget should be displayed.";
        public const string rssFeedUrlToolTip = "URL of the RSS feed. RSS Feed Url like this E.g:- https://www.samplesite.com/sample.xml";
        public const string viewPathToolTip = "Configure the view with the corresponding rss feed url related fields and with the proper design after assigning the view path to this field(View Path). View path is being considered from 'Views/Shared/' path, just input the remaining path of a partial view without the extension. E.g:- Widgets/RSSFeed/_RSSFeedList";
        public const string contentBeforeToolTip = "HTML content placed before the widget. Can be used to display a header or add some encapsulating code, such as <div> or <table> elements to achieve the required layout.";
        public const string contentAfterToolTip = "HTML content placed after the widget. Can be used to display a footer or close the tags contained in the ContentBefore value, such as </div> or </table> elements.";
        public const string noDataTextToolTip = "Text to be displayed if no records are found.";
        #endregion
        #region Widget Properties
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Visible", Order = 0, Tooltip = visibleToolTip)]
        public bool Visible { get; set; } = true;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please give the rss feed url")]
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "RSS Feed Url*", Order = 1, Tooltip = rssFeedUrlToolTip)]
        public string RSSFeedUrl { get; set; } = "";
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "View path*", Order = 2, Tooltip = viewPathToolTip)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please give the view name")]
        public string ViewName { get; set; } = "Widgets/RSSFeed/_RSSFeedList";
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Content before", Order = 3, Tooltip = contentBeforeToolTip)]
        public string ContentBefore { get; set; } = "";
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Content after", Order = 4, Tooltip = contentAfterToolTip)]
        public string ContetAfter { get; set; } = "";
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "No record found text", Order = 5, Tooltip = noDataTextToolTip)]
        public string NoDataText { get; set; } = "<h4>No data found.</h4><p>Please check the settings of a widget.</p>";
        #endregion
    }
}