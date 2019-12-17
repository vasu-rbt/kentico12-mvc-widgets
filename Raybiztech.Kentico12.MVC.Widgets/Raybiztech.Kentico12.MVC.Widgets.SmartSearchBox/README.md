# Smart SearchBox

Provides a text box where users can enter search expressions. Searching redirects users to a page that displays the search results. The indexes used by the search are specified by the widget displaying the results. You can configure the Smart search box to display results instantly while users type the search text.

# Installation

Install the Raybiztech.Kentico12.MVC.Widget.SmartSearchBox.12.0.29 NuGet Package to your Kentico 12 MVC Site. 

# Widget

This is a widget which allows you to add a SmartSearchBox to your screen with certain attributes that can be configured while adding. The properties that can be configured are:

- Search results page URL*
- Watermark text
- Search button text*
- Search label text
- Show search label
- Page Size*
- Group Size*

*Required fields

Suppose we are enter Search results page URL field like 'Search'.
Add below routing in RouteConfig.cs file in App_Start folder.
<pre>		
    routes.MapRoute(
     name: "Search",
     url: "Search/{id}",
	 defaults: new { controller = "SmartSearchWidget", action = "SearchResults", id = UrlParameter.Optional });
</pre>

# Requirments

jquery-3.3.1.min.js

# Author

This widget was created by Vinod Kumar Chindam @ Ray Business Technologies Pvt Ltd.

# License

This widget is provided under MIT license.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

This widget has been tested on Kentico 12.0.29 MVC and can be used on Kentico 12.0.29 MVC instance and higher.

# Uninstall instructions

After uninstall this package from the solution still able to see the widget on page tab in Kentico CMS please follow the below steps.

Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.SmartSearchBox.dll) and delete
-> Rebuild the solution
