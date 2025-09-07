using MaiAmTruyenTin.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace MaiAmTruyenTin.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CkEditorController : Controller
    {
        private readonly IWebHostEnvironment _env;
        public CkEditorController(IWebHostEnvironment env) { _env = env; }
        private readonly FileUploadHelper _fileHelper;

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            if (upload != null && upload.Length > 0)
            {
                var uploadDir = Path.Combine(_env.WebRootPath, "uploads");
                if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

                var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName);
                var filePath = Path.Combine(uploadDir, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await upload.CopyToAsync(stream);
                }

                return Json(new { uploaded = 1, fileName, url = "/uploads/" + fileName });
            }

            return Json(new { uploaded = 0, error = new { message = "No file uploaded" } });

        }

        [HttpGet]
        public IActionResult UploadExplorer()
        {
            var uploadDir = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);

            var dir = new DirectoryInfo(uploadDir);
            ViewBag.fileInfo = dir.GetFiles();
            return View("FileExplorer");
        }
    }

}
