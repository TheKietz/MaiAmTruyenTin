using Microsoft.AspNetCore.Mvc;

namespace MaiAmTruyenTin.Controllers
{
    public class NhaTaiTroController : Controller
    {
        private readonly INhaTaiTroService _nhaTaiTroService;
        public NhaTaiTroController(INhaTaiTroService nhaTaiTroService)
        {
            _nhaTaiTroService = nhaTaiTroService;
        }

        public IActionResult Index()
        {
            // 1. Lấy danh sách Sponsor (tên + logo + ghi chú)
            var vm = _nhaTaiTroService.GetNhaTaiTroData();
            return View(vm);
        }
    }
}
