using MaiAmTruyenTin.Data;
using X.PagedList;

namespace MaiAmTruyenTin.ViewModels
{
    public class TinTucVM
    {
        public IPagedList<News> AllNewsPaged { get; set; }
        public class NewsCategoryCountVM
        {
            public string CategoryName { get; set; }
            public int NewsCount { get; set; }
        }
        public List<News> RecentNews { get; set; }
        public IEnumerable<NewsCategoryCountVM> NewsCountByCategory { get; set; }
    }
}
