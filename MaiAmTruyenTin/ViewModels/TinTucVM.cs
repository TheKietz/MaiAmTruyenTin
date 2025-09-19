using MaiAmTruyenTin.Models;
using X.PagedList;

namespace MaiAmTruyenTin.ViewModels
{
    public class TinTucVM
    {
        public IPagedList<NewsVM> AllNewsPaged { get; set; }
        public class NewsCategoryCountVM
        {
            public string CategoryName { get; set; }
            public int NewsCount { get; set; }
        }
        public List<NewsVM> RecentNews { get; set; } = new List<NewsVM>();
        public IEnumerable<NewsCategoryCountVM> NewsCountByCategory { get; set; }
        public List<NewsVM> EventNews { get; set; } = new List<NewsVM>();
        
    }
}
