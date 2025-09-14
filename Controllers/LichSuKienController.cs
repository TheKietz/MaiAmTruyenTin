using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

namespace MaiAmTruyenTin.Controllers
{
    public class LichSuKienController : Controller
    {
        private readonly ILichSuKienService _lichSuKienService;

        public LichSuKienController(ILichSuKienService lichSuKienService)
        {
            _lichSuKienService = lichSuKienService;
        }

        public IActionResult Index(string? keyword, int? categoryId)
        {
            var vm = _lichSuKienService.GetLichSuKienData(keyword, categoryId);
            return View(vm);
        }

        public IActionResult GetEvents()
        {
            var events = _lichSuKienService.GetEventsForCalendar();
            return Json(events);
        }
    }
}