using MaiAmTruyenTin.Models;
using System;
using System.Collections.Generic;

namespace MaiAmTruyenTin.ViewModels
{
    public class NhaTaiTroVM
    {
        public List<SponsorVM> Sponsors { get; set; }
        public List<SponsorDonationVM> Donations { get; set; }
        public List<News> RelatedNews { get; set; }
    }
}
