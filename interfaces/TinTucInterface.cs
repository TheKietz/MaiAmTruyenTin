using MaiAmTruyenTin.ViewModels;

public interface ITinTucService
{
    TinTucVM GetPagedNews(int? page);
    NewsDetailVM GetNewsDetail(int id);
}