using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MaiAmTruyenTin.Helpers
{
    public class FileUploadHelper
    {
        private readonly IWebHostEnvironment _env;
        public FileUploadHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        /// <summary>
        /// Upload file, trả về đường dẫn relative để lưu DB
        /// </summary>
        public async Task<string?> UploadFile(IFormFile? file, string folder = "uploads")
        {
            if (file == null || file.Length == 0) return null;

            // Tạo thư mục nếu chưa tồn tại
            var uploadDir = Path.Combine(_env.WebRootPath, folder);
            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);

            // Tạo tên file duy nhất
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadDir, fileName);

            // Lưu file
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Trả về đường dẫn relative
            return "/" + folder + "/" + fileName;
        }
        public string GetFileUrl(string? relativePath)
        {
            if (string.IsNullOrEmpty(relativePath))
            {
                return "/images/mylogo.jpeg"; 
            }

            return relativePath.Replace("\\", "/");
        }
    }
}
