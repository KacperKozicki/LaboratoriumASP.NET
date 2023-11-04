using System.ComponentModel.DataAnnotations;

namespace Laboratorium3___App.Models
{
    public enum AlbumChartRanking
    {
        [Display(Name = "Brak")] None,
        [Display(Name = "Top 10")] Top10,
        [Display(Name = "Top 20")] Top20,
        [Display(Name = "Top 50")] Top50,
        [Display(Name = "Inne")] Other
    }
}
