# Image Video Carousel

Displays Image and Video slides using pages.

# Installation

Install the Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel NuGet Package to your Kentico 12 MVC Site.

# Widget

User must create a page type to store data with the following mandatory fields:

- SlideType*
- Image*
- Video*
- Text
- TargetURL

- Create Image Video Carousel Pagetype field(SlideType) with drop-down list form control using image and video as fields.

This is a widget which allows you to add Image and Video slides to your screen with an attribute that can be configured while adding. The properties that can be configured are:

 - Image Video Carousel PageType*(specify the code name)
 - Path
 - TopN
 - OrderBy

*Required fields

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

 After uninstall this package from the solution still able to see the widget on page tab in Kentico CMS please follow the below steps.

 Go to Solution -> Select Bin folder -> Select the specific widget dll(Ex:Raybiztech.Kentico12.MVC.Widgets.ImageVideoCarousel.dll) and delete
 -> Rebuild the solution