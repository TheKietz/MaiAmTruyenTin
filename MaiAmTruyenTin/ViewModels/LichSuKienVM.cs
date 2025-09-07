using MaiAmTruyenTin.Models;
using System.Collections.Generic;

namespace MaiAmTruyenTin.ViewModels
{
    public class LichSuKienVM
    {
        public List<Event> Events { get; set; } = new List<Event>();

        public string? Keyword { get; set; }

        public string? SelectedCategory { get; set; }

       
        public Dictionary<int, string> Categories { get; set; } = new Dictionary<int, string>();
    }
}
