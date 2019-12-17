# GoogleMap

It displays map obtained from the Google maps service using Latitude,Longitude and Google API Key.

# Installation

Install the Kentico.MVC.Widget.GoogleMap.12.0.29 NuGet Package to your Kentico 12 MVC Site. 

# Widget

This is a widget which allows you to add a GoogleMap to your screen with certain attributes that can be configured while adding. The properties that can be configured are:

- Latitude*
- Longitude*
- Google API Key*

*Required fields

Make sure to insert your Google Maps API token into application settings(Web.config):

<code>&lt;appSettings&gt;</code><br>
     <code>
          &lt;add key="GoogleMapsApiKey" value="{key}" /&gt;
     </code> <br>
<code>&lt;appSettings/&gt;</code>

# Author

This widget was created by Raju Swamy @ Ray Business Technologies Pvt Ltd.

# License

This widget is provided under MIT license.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

This widget has been tested on Kentico 12.0.29 MVC and can be used on Kentico 12.0.29 MVC instance and higher.
# Uninstall instructions

After uninstall this package from the solution still able to see the widget on page tab in Kentico CMS please follow the below steps.

Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.GoogleMap.dll) and delete
-> Rebuild the solution