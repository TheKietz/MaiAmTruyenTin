using System.ComponentModel;

namespace MaiAmTruyenTin.ViewModels
{
    public class SponsorVM
    {
        public int SponsorId { get; set; }
        [DisplayName("Tên nhà tài trợ")]
        public string Name { get; set; }
        [DisplayName("Logo")]
        public string Logo { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }
    }
}
