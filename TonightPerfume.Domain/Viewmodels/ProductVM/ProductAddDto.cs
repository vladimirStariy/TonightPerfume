using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Viewmodels.ProductVM
{
    public class ProductAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Year { get; set; }
        public string Country { get; set; }

        public uint Brand_ID { get; set; }
        public uint Category_ID { get; set; }

        public ICollection<uint> AromaGroups { get; set; }
        public ICollection<uint> PerfumeNotes { get; set; }
        public ICollection<Price> Prices { get; set; }
    }
}
