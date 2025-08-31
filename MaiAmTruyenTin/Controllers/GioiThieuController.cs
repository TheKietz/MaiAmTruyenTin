using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaiAmTruyenTin.Controllers
{
    public class GioiThieuController : Controller
    {
        private readonly KrbltdhcMaiamtruyentinContext db;
        public GioiThieuController(KrbltdhcMaiamtruyentinContext context)
        {
            db = context;
        }
        // GET: IntroductionController
        public ActionResult Index()
        {
            // Lấy dữ liệu nhà sáng lập và nhà tài trợ
            var sponsor = db.Sponsors.ToList();
            var founder = db.Founders.ToList();
            // Tạo ViewModel
            var vm = new GioiThieuVM
            {
                AllFounder = founder,
                AllSponsor = sponsor,
            };
            return View(vm);
        }

    }
}
