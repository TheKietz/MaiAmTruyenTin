namespace MaiAmTruyenTin.ViewModels
{
    public class SponsorDonationVM
    {
        public string SponsorName { get; set; }
        public decimal Amount { get; set; }
        public DateTime? DonationDate { get; set; }
        public string Purpose { get; set; }
        public string Note { get; set; }
    }
}
