using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Raybiztech.Kentico12.MVC.Widgets.Repeater
{
    public class RepeaterProperties : IWidgetProperties
    {
        #region ToolTips Constants
        public const string visibleToolTip = "Indicates if the widget should be displayed.";
        public const string selectOnlyPublishedToolTip = "Specifies whether the widget only loads published pages.";
        public const string pathToolTip = "Specifies the path of the selected pages. If you leave the path empty, the widget either loads all child pages or selects the current page(depending on the page type and configuration of the widget other properties).";
        public const string topNToolTip = "Specifies the maximum of pages to be loaded. At least as many pages as in the 'visible' value of the 'initialization script' property need to be specified. If empty, all possible pages will be selected.";
        public const string columnsToolTip = "If specified, only selected database columns are loaded by the widget, which improves the performance of the system. Specified columns need to be common to all selected page types and entered as all lists separated by commas (,), Any user defined columns must have an alias - anonymous columns are not supported.";
        public const string maximumNestingLevel = "Specifies the maximum number of content tree sub-levels from which the content is to be loaded. This number is relative, i.e. it is counted from the beginning of the path specified for the content of the web part. Entering -1 causes all sub-levels to be included.";
        public const string orderByToolTip = "Sets the value of the ORDER BY clause in the SELECT statement used to retrieve the content. You can specify only the columns common to all of the selected page types.";
        public const string whereToolTip = "Sets the value of the WHERE clause in the SELECT statement used to retrieve the content. Given Condition like this Ex:-DocumentName='Test'";
        public const string paginationEnableToolTip = "Indicates if the displayed data should be paged.";
        public const string pageSizeToolTip = "Determines the maximum number of records displayed per page. By default page size value is 4.";
        public const string groupSizeToolTip = "Sets the maximum amount of page number links that will be displayed together. Any additional links that do not fit can be accessed in the next or previous group. By default group size value is 3.";
        public const string contentBeforeToolTip = "HTML content placed before the widget. Can be used to display a header or add some encapsulating code, such as <div> or <table> elements to achieve the required layout.";
        public const string contentAfterToolTip = "HTML content placed after the widget. Can be used to display a footer or close the tags contained in the ContentBefore value, such as </div> or </table> elements.";
        public const string viewPathToolTip = "Configure the view with the corresponding page type-related fields and with the proper design after assigning the view path to this field(View Path). View path is being considered from 'Views/Shared/' path, just input the remaining path of a partial view without the extension. E.g.: Articles/_ArticleViewList";
        public const string noDataTextToolTip = "Text to be displayed if no records are found.";
        #endregion
        #region Widget Properties
        /// <summary>
        /// Selected page type
        /// </summary>
        public string PageType { get; set; } = "";
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Visible", Order = 0, Tooltip = visibleToolTip)]
        public bool Visible { get; set; } = true;
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Select only published", Order = 1, Tooltip = selectOnlyPublishedToolTip)]
        public bool SelectOnlyPublished { get; set; } = false;
        [EditingComponent(PathSelector.IDENTIFIER,Order =2,Label="Pages path",Tooltip = pathToolTip)]
        [EditingComponentProperty(nameof(PathSelectorProperties.RootPath), "/")]
        public IList<PathSelectorItem> Path { get; set; }
        [EditingComponent(TextInputComponent.IDENTIFIER,Label = "View path*", Order =3,Tooltip = viewPathToolTip)]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Please give the view Name")]
        public string ViewName { get; set; } = "Widgets/Repeater/_ArticleList";
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Select top N pages", Order = 4, Tooltip = topNToolTip)]
        [Range(1, 100, ErrorMessage = "Please enter valid number")]
        public string TopN { get; set; } = "10";
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Columns", Order = 5, Tooltip = columnsToolTip)]
        public string Columns { get; set; } = "";
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Maximum nesting level", Order = 6, Tooltip = maximumNestingLevel)]
        [Range(-1, 100, ErrorMessage = "Please enter valid number")]
        public string MaximumNestingLevel { get; set; } = "-1";
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Order by", Order = 7, Tooltip = orderByToolTip)]
        public string OrderBy { get; set; } = "";
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Where condition", Order = 8, Tooltip = whereToolTip)]
        public string WhereCondition { get; set; } = "";
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Enable paging", Order = 9, Tooltip = paginationEnableToolTip)]
        public bool PaginationEnable { get; set; } = false;
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Page size", Order = 10, Tooltip = pageSizeToolTip)]
        [Range(1, 100, ErrorMessage = "Please enter valid number")]
        public string PageSize { get; set; } = "";
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Group size", Order = 11, Tooltip = groupSizeToolTip)]
        [Range(1, 100, ErrorMessage = "Please enter valid number")]
        public string GroupSize { get; set; } = "";
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Content before", Order =12,Tooltip =contentBeforeToolTip)]
        public string ContentBefore { get; set; } = "";
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Content after", Order = 13,Tooltip = contentAfterToolTip)]
        public string ContetAfter { get; set; } = "";
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "No record found text", Order = 14, Tooltip = noDataTextToolTip)]
        public string NoDataText { get; set; } = "<h4>No data found</h4><p>Please check the settings of a widget.</p>";
        #endregion

    }
}