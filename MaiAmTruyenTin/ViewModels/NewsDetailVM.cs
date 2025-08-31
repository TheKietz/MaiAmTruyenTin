using MaiAmTruyenTin.Data;

namespace MaiAmTruyenTin.ViewModels
{
    public class NewsDetailVM
    {
        public News News { get; set; }
        public List<News> RelatedNews { get; set; }
    }
}
