using Kentico.PageBuilder.Web.Mvc;
using Raybiztech.Kentico12.MVC.Widgets.YouTubeVideo;
using System.Web.Mvc;
using System.Text;

[assembly: RegisterWidget("Raybiztech.Kentico12.MVC.Widgets.YouTubeVideo", typeof(YouTubeVideoWidgetController), "YouTube Video widget", Description = "Enables to insert the video from specified YouTube URL location.", IconClass = "icon-w-youtube-video")]
namespace Raybiztech.Kentico12.MVC.Widgets.YouTubeVideo
{
    public class YouTubeVideoWidgetController : WidgetController<YouTubeVideoWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            var viewModel = new YouTubeVideoWidgetViewModel
            {
                 VideoURL= (properties.VideoURL!=null)?properties.VideoURL.Replace("/watch?v=", "/embed/"):string.Empty,
                 Width=properties.Width,
                 Height=properties.Height,
                 VideoParameters= GetYouTubeVideo(properties.IsShowRelatedVideos,properties.IsFullScreen,properties.IsAutoPlay)
            };

            return PartialView("Widgets/YouTubeVideoWidget/_YouTubeVideoWidget", viewModel);
        }

        private string GetYouTubeVideo(bool relVideos,bool fullScreen, bool autoPlay)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(fullScreen ? "&fs=1" : "&fs=0");
            stringBuilder.Append(autoPlay ? "&autoplay=1" : string.Empty);
            stringBuilder.Append((!relVideos) ? "&rel=0" : string.Empty);
            stringBuilder.Append("&enablejsapi=1&version=3");
            return stringBuilder.ToString();
        }
    }
}
