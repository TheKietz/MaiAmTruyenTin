using Microsoft.AspNetCore.Mvc;
using MaiAmTruyenTin.Data;

namespace MaiAmTruyenTin.ViewModels
{
    public class LoaiBaiVietViewComponent : ViewComponent
    {
        private readonly KrbltdhcMaiamtruyentinContext db;
        public LoaiBaiVietViewComponent(KrbltdhcMaiamtruyentinContext context)
        {
            db = context;
        }


        public IViewComponentResult Invoke()
        {
            var data = db.Categories.Select( lo => new LoaiBaiVietVM
            {
                CategoryId= lo.CategoryId, Name= lo.Name
            }).ToList();
            return View(data);
        }
    }
}
