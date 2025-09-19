using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;
namespace MaiAmTruyenTin.ViewModels
{
    public class NewsDetailVM
    {
        public NewsVM News { get; set; }
        public List<NewsVM> RelatedNews { get; set; } = new List<NewsVM>();
    }
}
