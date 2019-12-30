# Image Video Carousel

Displays Image and Video slides using pages.

# Installation

Install the Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel NuGet Package to your Kentico 12 MVC Site.

# Widget

This is a widget which allows you to add Image and Video slides on the web page with configurable properties. The properties that can be configured are:

 - Image Video Carousel PageType*(specify the code name of the page type)
 - Path
 - TopN
 - OrderBy

*Required fields

In this Image Video Carousel widget Properties it is mandatory to give Page type code name, create the Image Video Carousel PageType.

# Page Type Creation

User must create a page type to store data with the following mandatory fields:

- SlideType*
- Image*
- Video*
- Text
- TargetURL

- Create Image Video Carousel Pagetype field(SlideType) with drop-down list form control with Image Slide and Video Slide as options.

# Image Card Pagetype Import

1) Download the latest export file from (PageType -> Data -> export_20191220_1529.zip )
2) In Kentico, go to the Sites application
3) Select "Import sites or objects"
4) Upload the package and import it (don't forget to check the "Import code files" checkbox)
5) Now you are ready to use it in the Pages application

# Author

This widget was created by Soundarya Aithu @ Ray Business Technologies Pvt Ltd.

# License

This widget is provided under MIT license.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

- This widget has been tested on Kentico 12 MVC version (12.0.29). 
- Must load jquery(3.3.1) before loading slick.min.js.

# Uninstall instructions

 After uninstalling this package from the solution, if you are still seeing the widget on page tab in Kentico CMS please follow the below steps.

 Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.RegistrationForm.dll) and delete
 -> Rebuild the solution