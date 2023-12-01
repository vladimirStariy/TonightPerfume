using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Viewmodels.ProductVM
{
    public class ProductDto
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Price> Prices { get; set; }
        public string Year { get; set; }
        public string Country { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<AromaGroup> AromaGroups { get; set; } = new List<AromaGroup>();
        public ICollection<PerfumeNote> PerfumeNotes { get; set; } = new List<PerfumeNote>();
    }
}
