using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Viewmodels.Filter
{
    public class FilterDto
    {
        public List<Brand> Brands { get; set; }
        public List<AromaGroup> AromaGroups { get; set; }
        public List<Category> Categories { get; set; }
        public List<PerfumeNote> PerfumeNotes { get; set; }
        public List<string> Countries { get; set; }
    }
}
