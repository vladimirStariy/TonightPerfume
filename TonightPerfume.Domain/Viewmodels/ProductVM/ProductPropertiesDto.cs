using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Viewmodels.ProductVM
{
    public class ProductPropertiesDto
    {
        public List<AromaGroup> aromaGroups { get; set; }
        public List<PerfumeNote> perfumeNotes { get; set; }
        public List<Category> categories { get; set; }
        public List<Brand> brands { get; set; }
    }
}
