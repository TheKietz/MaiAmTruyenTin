using MaiAmTruyenTin.Data;
using MaiAmTruyenTin.Models;
using System.ComponentModel.DataAnnotations;

namespace MaiAmTruyenTin.ViewModels
{
    public class GioiThieuVM
    {
        public IEnumerable<SponsorVM> AllSponsor { get; set; }
        public IEnumerable<FounderVM> AllFounder { get; set; }
        public string AboutUs { get; set; }
        public string Vision { get; set; }
        public string VisionImage { get; set; }
    }
}
