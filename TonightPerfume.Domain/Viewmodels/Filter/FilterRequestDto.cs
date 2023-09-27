using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Viewmodels.Filter
{
    public class FilterRequestDto
    {
        public int[] Volumes { get; set; }
        public int[] Prices { get; set; }
        public int[] Brands { get; set; }
        public int[] AromaGroups { get; set; }
        public int[] Categories { get; set; }
        public int[] PerfumeNotes { get; set; }
        public int[] Countries { get; set; }
    }
}
