# Lazy Loading
Enables User to get a list of objects on the basis of selected PageType,selected Path,Column Names provided.
You can Provide PageType and Path and Column Name(separated by comma),Order by which List needs to be sorted in Order by Field.
Page Size would be Number of entities will be displayed at first and in every click of View More that Number of entities will be added more by every click of View More.
Every Click of View Less would enable to delete Pagesize number of entity in every click of View Less.


# Installation
Install the Raybiztech.Kentico12.MVC.Widget.LazyLoading
NuGet Package to your Kentico 12 MVC Site. 

# Widget

This is a widget which allows you to Load list of data of specified with certain attributes that can be configured while adding.The properties that can be configured are:

- PageType* (as Inline Editor Drop down)
- Path*     (Select)
- Main Heading(optional)
- Columns*  (Comma separated)
- Order By*
- Page Size*
- Custom View*

*Required fields

If after giving all the fields you are not getting any data.Please Check Column Names and all the mandatory fields given properly.


# Requirments

jquery-3.3.1.js

# Author

This widget was created by Swarnima Gupta @Ray Business Technologies Pvt Ltd.

# License

This widget is provided under MIT license.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

This widget has been tested on Kentico 12.0.29 MVC and can be used on Kentico 12.0.29 MVC instance and higher.

# Uninstall instructions

After uninstalling this package from the solution, if you are still seeing the widget on the page tab in Kentico CMS then please follow the below steps.

Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.LazyLoading.dll) and delete
-> Rebuild the solution
