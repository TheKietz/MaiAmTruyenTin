using HtmlAgilityPack;
using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;
using MaiAmTruyenTin.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace MaiAmTruyenTin.Controllers
{
    public class GioiThieuController : Controller
    {
        private readonly MaiamtruyentinContext db;
        public GioiThieuController(MaiamtruyentinContext context)
        {
            db = context;
        }
        // GET: IntroductionController
        public async Task<ActionResult> Index()
        {
            // Lấy dữ liệu nhà sáng lập và nhà tài trợ
            var sponsor = db.Sponsors.ToList();
            var founder = db.Founders.ToList();
            var aboutUs = await db.StaticPages.FirstOrDefaultAsync(p => p.Title == "Về chúng tôi");
            var vision = await db.StaticPages.FirstOrDefaultAsync(p => p.Title == "Tầm nhìn của chúng tôi");
            if (aboutUs == null || vision == null)
            {
                return NotFound(); 
            }

            // Tạo ViewModel
            var vm = new GioiThieuVM
            {
                AboutUs = aboutUs.Content,
                Vision = vision.Content,
                VisionImage = vision.CoverImage,
                AllFounder = founder,
                AllSponsor = sponsor,
            };
            return View(vm);
        }
        
    }
}
