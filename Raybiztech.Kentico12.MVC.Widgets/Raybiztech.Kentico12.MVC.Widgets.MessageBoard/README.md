# MessageBoard

Allows authenticated users to post comments and view other users comments 

# Installation

Install the Raybiztech.Kentico12.MVC.Widget.MessageBoard NuGet Package to your Kentico 12 MVC Site.

# Widget

User must create a custom table to store data with the following mandatory fields:

- UserFirstName*
- UserComments*
- UserEmail*
- PageUrl* 

This is a widget which allows you to add a MessageBoard to your screen with an attribute that can be configured while adding. The property that can be configured is:

- Custom table Codename*
- Submit button text*

*Required fields

# Author

This widget was created by Raju Swamy @ Ray Business Technologies Pvt Ltd.
Last updated 12-12-2019.

# License

This widget is provided under MIT license.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

This widget has been tested on Kentico 12 MVC version (12.0.29). 

# Uninstall instructions

After uninstalling this package from the solution, if you are still seeing the widget on the page tab in Kentico CMS then please follow the below steps.

Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.MessageBoard.dll) and delete
-> Rebuild the solution
