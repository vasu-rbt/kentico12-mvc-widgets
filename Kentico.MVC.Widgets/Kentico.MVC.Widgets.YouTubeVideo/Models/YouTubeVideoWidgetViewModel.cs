namespace Kentico.MVC.Widgets.YouTubeVideo
{
    public class YouTubeVideoWidgetViewModel 
    {
        public string VideoURL { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public bool IsShowRelatedVideos { get; set; }
        public bool IsFullScreen { get; set; }
        public bool IsAutoPlay { get; set; }
        public string VideoParameters { get; set; }
    }
}
