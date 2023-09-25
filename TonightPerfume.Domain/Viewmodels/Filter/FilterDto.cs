using TonightPerfume.Domain.Models;

namespace TonightPerfume.Domain.Viewmodels.Filter
{
    public class FilterDto
    {
        public List<Brand> Brands { get; set; } = new List<Brand>();
        public List<AromaGroup> AromaGroups { get; set; } = new List<AromaGroup>();
    }
}
