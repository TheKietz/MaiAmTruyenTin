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

    public class SponsorVM
    {
        public int SponsorId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }
    }

    public class SponsorDonationVM
    {
        public string SponsorName { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DonationDate { get; set; }
        public string Purpose { get; set; }
        public string Note { get; set; }
    }
}
