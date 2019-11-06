using CMS.MediaLibrary;
using CMS.SiteProvider;
using Kentico.MVC.Widgets;
using Kentico.PageBuilder.Web.Mvc;
using System;
using System.Linq;
using System.Web.Mvc;

[assembly: RegisterWidget("EditableImage", typeof(EditableImageWidgetController), "EditableImage", Description = "It allows editors to add class, alt text, dimensions and redirection link to image", IconClass = "icon-picture")]
namespace Kentico.MVC.Widgets
{
    public class EditableImageWidgetController : WidgetController<EditableImageWidgetProperties>
    {

        public EditableImageWidgetController() { }

        /// <summary>
        /// Creates an instance of <see cref="EditableImageController"/> class.
        /// </summary>
        /// <param name="propertiesRetriever">Retriever for widget properties.</param>
        /// <param name="currentPageRetriever">Retriever for current page where is the widget used.</param>
        /// <remarks>Use this constructor for tests to handle dependencies.</remarks>
        public EditableImageWidgetController(IWidgetPropertiesRetriever<EditableImageWidgetProperties> propertiesRetriever,
                                        ICurrentPageRetriever currentPageRetriever) : base(propertiesRetriever, currentPageRetriever)
        {
        }

        public ActionResult Index()
        {
            var properties = GetProperties();

            if (properties.Image?.Count > 0)
            {
                var fileguid = properties.Image.FirstOrDefault()?.FileGuid ?? Guid.Empty;
                var fileInfo = MediaFileInfoProvider.GetMediaFileInfo(fileguid, SiteContext.CurrentSiteName);
                string fileURL = MediaFileURLProvider.GetMediaFileUrl(fileInfo.FileGUID, fileInfo.FileName) ?? string.Empty;

                return PartialView("Widgets/EditableImageWidget/_EditableImageWidget", new EditableImageWidgetViewModel()
                {
                    ImageURL = fileURL,
                    AlternateText = properties?.AlternateText,
                    ImageCSSClass = properties.ImagClass,
                    RenderAsLink = properties.ShowImageAsLink,
                    RedirectionURL = properties.RedirectionURL,
                    LinkCSSClass = properties.LinkClass,
                    Height = properties.Height > 0 ? properties.Height : fileInfo.FileImageHeight,
                    Width = properties.Width > 0 ? properties.Width : fileInfo.FileImageWidth
                });

            }
            else
            {
                return null;
            }
        }
    }

}

