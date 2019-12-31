# RSS Feed

Displays the content of specified RSS Feed Url based on assigned views.

# Installation

Install the Raybiztech.Kentico12.MVC.Widgets.RSSFeed. 12.0.29 NuGet Package to your Kentico 12 MVC Site.

# Requirements
* **Kentico 12.0.29** or later

# Widget

Displays the content of specified RSS Feed Url based on assigned views.

The RSS Feed fields that can be configured are:

-**Widget Properties**:

* **Visible:-** Indicates if the widget should be displayed. By default, the visible checkbox was checked.
* **RSS Feed Url:-*** URL of the RSS feed. RSS Feed Url like this E.g:- https://www.samplesite.com/sample.xml
* **View path:-*** Configure the view with the corresponding rss feed url related fields and with the proper design after assigning the view path to this field(View Path). View path is being considered from 'Views/Shared/' path, just input the remaining path of a partial view without the extension. E.g:- Widgets/RSSFeed/_RSSFeedList
* **Content before:-** HTML content placed before the widget. It can be used to display a header or add some encapsulating code, such as **<div>** or **<table>** elements to achieve the required layout.
* **Content after:-** HTML content placed after the widget. Can be used to display a footer or close the tags contained in the ContentBefore value, such as **</div>** or **</table>** elements.
* **No record found text:-** Text to be displayed if no records are found. This data changes dynamically.

  ***Required fields**

  In this RSS Feed widget properties, it is mandatory to give View path and RSS Feed Url.

-**Views:-** After installing this package by default views(path **~/Views/Shared/Widgets/RSSFeed**) will be added to your project.

* **_RSSFeedList.cshtml:-** This view is an example of a specific RSS Feed Url(**https://www.feedforall.com/sample.xml**). This RSS Feed contains some specific fields like **title**, **description**. By using this view it will display the given RSS Feed Url data. Suppose you want to display some other RSS Feed data, create a new view and specify column names like this view. You can display any RSS Feed data follow this **RSS Feed Url(https://www.feedforall.com/sample.xml)** of an RSS Feed example.
* **_NoData.cshtml:-** This view is rendered when the RSS Feed related data doesn't exist or invalid widget properties values like wrong RSS Feed url.
* **_ViewNotFound.cshtml:-** This view is rendered when the widget property of View path has a wrong view name or wrong path.

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

Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.RSSFeed.dll) and delete
-> Rebuild the solution
