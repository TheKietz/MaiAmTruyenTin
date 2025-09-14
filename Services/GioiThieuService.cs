using MaiAmTruyenTin.ViewModels;
using MaiAmTruyenTin.Data;

namespace YourProjectNamespace.Services
{
    public class GioiThieuService : IGioiThieuService
    {
        private readonly MaiamtruyentinContext _db;

        public GioiThieuService(MaiamtruyentinContext db)
        {
            _db = db;
        }

        public GioiThieuVM GetGioiThieuData()
        {
            var sponsor = _db.Sponsors.ToList();
            var founder = _db.Founders.ToList();

            return new GioiThieuVM
            {
                AllFounder = founder,
                AllSponsor = sponsor
            };
        }

        GioiThieuVM IGioiThieuService.GetGioiThieuData()
        {
            throw new NotImplementedException();
        }
    }
}