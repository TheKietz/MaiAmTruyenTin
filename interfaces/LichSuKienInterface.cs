using MaiAmTruyenTin.ViewModels;

public interface ILichSuKienService
{
    LichSuKienVM GetLichSuKienData(string? keyword, int? categoryId);
    List<object> GetEventsForCalendar();
}