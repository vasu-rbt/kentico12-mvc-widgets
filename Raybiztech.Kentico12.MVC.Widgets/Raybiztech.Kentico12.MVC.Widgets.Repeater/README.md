# Repeater

Displays the content of specified pages based on assigned views.

# Installation

Install the Raybiztech.Kentico12.MVC.Widget.Repeater. 12.0.29 NuGet Package to your Kentico 12 MVC Site.

To support **page builder** in **web.config** file(path **~/Views/web.config**). Add namespace(**Kentico.PageBuilder.Web.Mvc**) in format like below in web.config file:

<code>&lt;namespaces&gt;</code><br>
<code>&lt;add namespace="Kentico.PageBuilder.Web.Mvc"/&gt;</code><br>
<code>&lt;/namespaces&gt;</code><br>

# Requirements
* **Kentico 12.0.29** or later
* **[Jquery jquery-version.min.js]**. All minified versions working.

# Widget

Displays the content of specified pages based on assigned views. Repeater

The repeater fields that can be configured are:

-**Widget Properties**:

* **Visible:-** Indicates if the widget should be displayed. By default, the visible checkbox was checked.
* **Select only published:-** Specifies whether the widget only loads published pages.
* **Pages path:-** Specifies the path of the selected pages. If you leave the path empty, the widget either loads all child pages or selects the current page(depending on the page type and configuration of the widget other properties).
* **View path*****:-** Configure the view with the corresponding page type-related fields and with the proper design after assigning the view path to this field(**View Path**). View path is being considered from **'~/Views/Shared/'** path, just input the remaining path of a partial view without the extension. **E.g.: Articles/_ArticleViewList**
* **Select top N pages:-** Specifies the maximum of pages to be loaded. At least as many pages as in the 'visible' value of the 'initialization script' property needs to be specified. If empty, all possible pages will be selected.
* **Columns:-** If specified, only selected database columns are loaded by the widget, which improves the performance of the system. Specified columns need to be common to all selected page types and entered as all lists separated by commas (,), Any user-defined columns must have an alias - anonymous columns are not supported.
* **Maximum nesting level:-** Specifies the maximum number of content tree sub-levels from which the content is to be loaded. This number is relative, i.e. it is counted from the beginning of the path specified for the content of the web part. Entering **-1** causes all sub-levels to be included. You did not declare any value. By default, it has taken value **-1**.
* **Order by:-** Sets the value of the ORDER BY clause in the SELECT statement used to retrieve the content. You can specify only the columns common to all of the selected page types.
* **Where condition:-** Sets the value of the WHERE clause in the SELECT statement used to retrieve the content. Given Condition like this **Ex:-DocumentName='Test'**. Here you can write the where conditions like SQL format only.
* **Enable paging:-** Indicates if the displayed data should be paged.
* **Page size:-** Determines the maximum number of records displayed per page. You did not declare any value. By default page size value is 4.
* **Group size:-** Sets the maximum amount of page number links that will be displayed together. You did not declare any value. Any additional links that do not fit can be accessed in the next or previous group. By default group size value is 3.
* **Content before:-** HTML content placed before the widget. It can be used to display a header or add some encapsulating code, such as **<div>** or **<table>** elements to achieve the required layout.
* **Content after:-** HTML content placed after the widget. Can be used to display a footer or close the tags contained in the ContentBefore value, such as **</div>** or **</table>** elements.
* **No record found text:-** Text to be displayed if no records are found. This data changes dynamically.

 ***Required fields**

  In this repeater widget properties, it is mandatory to give View path.

-**InlineEditor**:

* **Page type:-** This is a dropdown, it contains all content only page types. By using this drop-down selector chooses a particular page type. After configuring widget properties.

-**Views:-** After installing this package by default views(path **~/Views/Shared/Widgets/Repeater**) will be added to your project.

* **_ArticleList.cshtml:-** This view is an example of a specific page type of an **Article**. This page type contains some specific fields like **ArticleTitle**, **ArticleSummary**. By using this view it will display the **Article** page type data. This view will be a reference for the Inline Editor page type selector, displaying article page type data and pagination. Suppose you want to display some other page type data, create a new view and specify column names like this view. You can display any page type data follow this **Article** page type example.
* **_NoData.cshtml:-** This view is rendered when the page type related data doesn't exist or invalid widget properties values.
* **_ViewNotFound.cshtml:-** This view is rendered when the widget property of View path has a wrong view name or wrong path.

# Article Pagetype Import

	1) This is example page type for repeater. 
	2) Download the latest export file from (PageType -> Data -> export_pagetype_article_20191227_1747.zip )
	3) In Kentico, go to the Sites application
	4) Select "Import sites or objects"
	5) Upload the package and import it (don't forget to check the "Import code files" checkbox)
	6) Now you are ready to use it in the Pages application

# Author

This widget was created by Raviteja Gonuguntla @ Ray Business Technologies Pvt Ltd.

# License

This widget is provided under MIT license.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

This widget has been tested on Kentico 12.0.29 MVC and can be used on Kentico 12.0.29 MVC instance and higher.

# Uninstall instructions

After uninstall this package from the solution still able to see the widget on page tab in Kentico CMS please follow the below steps.

Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.Repeater.dll) and delete
-> Rebuild the solution
