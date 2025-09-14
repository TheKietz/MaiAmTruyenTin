using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MaiAmTruyenTin.Controllers
{
    public class GioiThieuController : Controller
    {
        private readonly IGioiThieuService _gioiThieuService;

        public GioiThieuController(IGioiThieuService gioiThieuService)
        {
            _gioiThieuService = gioiThieuService;
        }

        public IActionResult Index()
        {
            var vm = _gioiThieuService.GetGioiThieuData();
            return View(vm);
        }
    }
}
