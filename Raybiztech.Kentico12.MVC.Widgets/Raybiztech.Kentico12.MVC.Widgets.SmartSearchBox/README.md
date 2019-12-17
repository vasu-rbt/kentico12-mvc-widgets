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

Enter the search results page URL field based on below attribute routing format
<pre>		
        [Route("Search/{searchresults}")]
        public ActionResult SearchResults(string searchtext, string page)
        {
            //Code here
        }
</pre>

Intialize the ' routes.MapMvcAttributeRoutes()' at the top  in RouteConfig.cs->RegisterRoutes() file in App_Start folder.
 <pre>
        public static void RegisterRoutes(RouteCollection routes)
        {
            var defaultCulture = CultureInfo.GetCultureInfo("en-US");

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Map routes to Kentico HTTP handlers and features enabled in ApplicationConfig.cs
            // Always map the Kentico routes before adding other routes. Issues may occur if Kentico URLs are matched by a general route, for example images might not be displayed on pages
            routes.Kentico().MapRoutes();
            //Intialize the Atribute routing hear.
            routes.MapMvcAttributeRoutes();
            // Redirect to administration site if the path is "admin"
            routes.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "AdminRedirect", action = "Index" }
            );

		}
</pre>	

# Author

This widget was created by Vinod Kumar Chindam @ Ray Business Technologies Pvt Ltd.

# License

This widget is provided under MIT license.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

This widget has been tested on Kentico 12.0.29 MVC and can be used on Kentico 12.0.29 MVC instance and higher.