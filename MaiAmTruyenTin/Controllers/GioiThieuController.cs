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
            var sponsor = db.Sponsors.ToList();
            var founder = db.Founders.ToList();
            var vm = new GioiThieuVM
            {
                AllFounder = founder,
                AllSponsor = sponsor,
            };
            return View(vm);
        }

    }
}
