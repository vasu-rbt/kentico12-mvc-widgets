# Image Card

Displays the ImageCards with Image, Caption and TargetUrl using Pages. 

# Installation

Install the Raybiztech.Kentico12.MVC.Widgets.ImageCard.12.0.29 NuGet Package to your Kentico 12 MVC Site. 

# Widget

This is a widget which allows you to add an ImageCard to your web page with certain properties that can be configured while adding. The properties that can be configured are:

- Image Card Page Type*(specify the page type code name)
- Path*
- TopN
- OrderBy
- Visible

*Required fields

In this ImageCard widget Properties it is mandatory to give Page type code name, create the ImageCard PageType.

# Page Type Creation

Need to Create the ImageCard Page Type with the following fields:

- Name* (Form control: Textbox)
- Image* (Form control: URL selector)
- Content*(Form control: TextArea)
- TargetUrl(Form control: URL selector)

*Required fields

# Image Card Pagetype Import

1) Download the latest export file from (PageType -> Data -> export_20191220_1125.zip )
2) In Kentico, go to the Sites application
3) Select "Import sites or objects"
4) Upload the package and import it (don't forget to check the "Import code files" checkbox)
5) Now you are ready to use it in the Pages application

# Author

This widget was created by Nikhitha Kundarapu @ Ray Business Technologies Pvt Ltd.

# License

This widget is provided under MIT license.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

This widget has been tested on Kentico 12.0.29 MVC and can be used on Kentico 12.0.29 MVC instance and higher

# Uninstall instructions

After uninstalling this package from the solution, if you are still able to see the widget on page tab in Kentico CMS then please follow the below steps.

Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.ImageCard.dll) and delete
-> Rebuild the solution
