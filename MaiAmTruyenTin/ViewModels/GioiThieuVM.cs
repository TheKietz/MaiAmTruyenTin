using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;

namespace MaiAmTruyenTin.ViewModels
{
    public class GioiThieuVM
    {
        public List<Sponsor> AllSponsor { get; set; }
        public List<Founder> AllFounder { get; set; }
        public string AboutUs { get; set; }
        public string Vision { get; set; }
        public string VisionImage { get; set; }
    }
}
