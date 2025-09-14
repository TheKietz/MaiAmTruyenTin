using Microsoft.AspNetCore.Mvc;

namespace MaiAmTruyenTin.Controllers
{
    public class TinTucController : Controller
    {
        private readonly ITinTucService _tinTucService;
        public TinTucController(ITinTucService tinTucService)
        {
            _tinTucService = tinTucService;
        }

        // GET: NewsController
        public IActionResult Index(int? page)
        {

            var vm = _tinTucService.GetPagedNews(page);
            return View(vm);
        }

        public IActionResult Details(int id)
        {

            var vm = _tinTucService.GetNewsDetail(id);
            if (vm == null)
                return NotFound();
            return View(vm);
        }

    }
}
